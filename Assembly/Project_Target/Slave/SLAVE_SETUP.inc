;************************************************************************************
;										    *
;   Filename:	    SLAVE_SETUP.inc						    *
;   Date:	    Novemeber 17, 2025						    *
;   File Version:   3								    *
;   Author:	    Andrew Keller, Rudy Earnest, Angel Nava, and Alex Villagran	    *
;   Company:	    Idaho State University					    *
;   Description:    Firmware for setting up a PIC16F1788 for the target slave of    *
;		    the Laser Shooting Game project.				    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	Iniitialize file, setup how I think it should be setup for the project.	    *
;										    *
;   2:	I2C communications for enabling/disabling the target as well as reporting   *
;       any player hits to the target when the target is enabled.		    *
;										    *
;   3:	Converting to new assembler and changing some setup.			    *
;************************************************************************************
		
;===============================================================================================================================*
;							   PORTA BITMAP								*
;===============================================================================================================================*		
;		|		|		|		|		|		|		|		*
;	7	|	6	|	5	|	4	|	3	|	2	|	1	|	0	*
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*	
;DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	*
;INPUT		|INPUT		|INPUT		|INPUT		|INPUT		|INPUT		|INPUT		|INPUT		*
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*		
;I2C Address	|I2C Address	|I2C Address	|I2C Address	|I2C Address	|I2C Address	|I2C Address	|I2C Address	*
;Switch		|Switch		|Switch		|Switch		|Switch		|Switch		|Switch		|Switch		*
;		|		|		|		|		|		|		|(Ignored in	*
;		|		|		|		|		|		|		|7-bit address)	*		
;-------------------------------------------------------------------------------------------------------------------------------*
		
;===============================================================================================================================*
;							   PORTB BITMAP								*
;===============================================================================================================================*		
;		|		|		|		|		|		|		|		*
;	7	|	6	|	5	|	4	|	3	|	2	|	1	|	0	*
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*	
;DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	*
;INPUT		|INPUT		|INPUT		|OUTPUT		|OUTPUT		|OUTPUT		|INPUT		|INPUT		*
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*		
;UNUSED		|UNUSED		|UNUSED		|RGB LEDS BLUE	|RGB LEDS RED	|RGB LEDS GREEN	|56kHz IR Input	|38kHz IR Input	*
;		|		|		|		|		|		|		|		*
;		|		|		|		|		|		|		|		*
;		|		|		|		|		|		|		|		*		
;-------------------------------------------------------------------------------------------------------------------------------*
		
;===============================================================================================================================*
;							   PORTC BITMAP								*
;===============================================================================================================================*		
;		|		|		|		|		|		|		|		*
;	7	|	6	|	5	|	4	|	3	|	2	|	1	|	0	*
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*	
;DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	|DIGITAL	*
;OUTPUT		|OUTPUT		|OUTPUT		|OUTPUT		|OUTPUT		|OUTPUT		|OUTPUT		|OUTPUT		*
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*		
;UNUSED		|UNUSED		|UNUSED		|I2C SDA	|I2C SCL	|UNUSED		|UNUSED		|UNUSED		*
;		|		|		|		|		|		|		|		*
;		|		|		|		|		|		|		|		*
;		|		|		|		|		|		|		|		*		
;-------------------------------------------------------------------------------------------------------------------------------*

;EEPROM Memory Map
     ;**** Do not under any circumstances ****
     ;**** Use EEPROM row 0 it is evil ****
    
;The byte at address 0x10 is used to store the I2C address of the target slave device.
;The byte at address 0x11 is used to store the static red value
;The byte at address 0x12 is used to store the static green value
;The byte at address 0x13 is used to store the static blue value
     
;The byte at address 0x20 is used to store the player 1 red value.
;The byte at address 0x21 is used to store the player 1 green value.
;The byte at address 0x22 is used to store the player 1 blue value.
;The byte at address 0x23 is used to store the player 2 red value.
;The byte at address 0x24 is used to store the player 2 green value.
;The byte at address 0x25 is used to store the player 2 blue value.
;The byte at address 0x26 is used to store the player 3 red value.
;The byte at address 0x27 is used to store the player 3 green value.
;The byte at address 0x28 is used to store the player 3 blue value.
;The byte at address 0x29 is used to store the player 4 red value.
;The byte at address 0x2A is used to store the player 4 green value.
;The byte at address 0x2B is used to store the player 4 blue value.

#include <xc.inc>
    
;RAM Variables
  ;EEPROM Variables
  EEPROM_ADDR   EQU 0x20
  EEPROM_DATA   EQU 0x21
  EEPROM_SAVE   EQU 0x22
  ;Status Registers
  TARGET_STATUS EQU 0x23
  ACTIVE        EQU 0x24
  ;I2C Variables
  RECEIVED_DATA EQU 0x25
  I2C_Color_Count   EQU 0x37
   // For the flags bit 0 means that I2C color protocol is enabled
   // Bit 1 means that Player 1's color is being changed
   // Bit 2 means that Player 2's color is being changed
   // Bit 3 means that Player 3's color is being changed
   // Bit 4 means that Player 4's color is being changed
  I2C_ColorFlag EQU 0x38
  ;Player Variables
  P1_R          EQU 0x26
  P2_R          EQU 0x27
  P3_R          EQU 0x28
  P4_R          EQU 0x29
  P1_G          EQU 0x2A
  P2_G          EQU 0x2B
  P3_G          EQU 0x2C
  P4_G          EQU 0x2D
  P1_B          EQU 0x2E
  P2_B          EQU 0x2F
  P3_B          EQU 0x30
  P4_B          EQU 0x31
  ;LED Variables
  _SENDLEDRED   EQU 0x32
  _SENDLEDBLUE  EQU 0x33
  _SENDLEDGREEN EQU 0x34
  _LEDNUMBER    EQU 0x35
  _LEDCOUNTER   EQU 0x36
PSECT code
 global Setup
Setup:
;*** INTOSC SETUP ***
  BANKSEL   OSCCON
  MOVLW	    0xF8
  MOVWF	    OSCCON
  BANKSEL   CLKRCON
  CLRF	    CLKRCON
  
;*** OPTION_REG SETUP ***  
  BANKSEL   OPTION_REG
  MOVLW	    0x48
  MOVWF	    OPTION_REG
  
;*** INTCON REG SETUP ***
  BANKSEL   INTCON
  BCF	    INTCON,3
  BCF	    INTCON,4
  BSF	    INTCON,6
  BCF	    INTCON,7
  
;*** PIE1-4 SETUP ***
  BANKSEL   PIE1
  MOVLW	    0X08
  MOVWF	    PIE1
  BANKSEL   PIE2
  CLRF	    PIE2
  BANKSEL   PIE3
  CLRF	    PIE3
  BANKSEL   PIE4
  CLRF	    PIE4
  
;*** CLEAR INTERUPT FLAGS ***
  BANKSEL   PIR1
  CLRF	    PIR1
  BANKSEL   PIR2
  CLRF	    PIR2
  BANKSEL   PIR3
  CLRF	    PIR3
  BANKSEL   PIR4
  CLRF	    PIR4
  
;*** ALTERNATE PIN FUNCTION ***
  BANKSEL   APFCON1
  CLRF	    APFCON1
  CLRF	    APFCON2
  
;*** TMR1 SETUP ***
  BANKSEL   T1CON
  MOVLW	    0XA8
  MOVWF	    T1CON
  BANKSEL   T1GCON
  CLRF	    T1GCON
  
;*** PORTA SETUP ***
  BANKSEL   PORTA
  CLRF	    PORTA
  BANKSEL   LATA
  CLRF	    LATA
  BANKSEL   TRISA
  MOVLW	    0XF0
  MOVWF	    TRISA
  BANKSEL   ODCONA
  CLRF	    ODCONA
  BANKSEL   ANSELA
  CLRF	    ANSELA
  BANKSEL   SLRCONA
  CLRF	    SLRCONA
  BANKSEL   IOCAP
  CLRF	    IOCAP
  BANKSEL   IOCAN
  CLRF	    IOCAN
  
;*** PORTB SETUP ***
  BANKSEL   PORTB
  CLRF	    PORTB
  BANKSEL   LATB
  CLRF	    LATB
  BANKSEL   TRISB
  MOVLW	    0X3F
  MOVWF	    TRISB
  BANKSEL   ODCONB
  CLRF	    ODCONB
  BANKSEL   ANSELB
  CLRF	    ANSELB
  BANKSEL   SLRCONB
  CLRF	    SLRCONB
  BANKSEL   INLVLB
  CLRF	    INLVLB
  
;*** PORTC SETUP ***
  BANKSEL   PORTC
  CLRF	    PORTC
  BANKSEL   LATC
  CLRF	    LATC
  BANKSEL   TRISC
  MOVLW	    0X9A
  MOVWF	    TRISC
  BANKSEL   ODCONC
  CLRF	    ODCONC
  BANKSEL   ANSELC
  CLRF	    ANSELC
  BANKSEL   SLRCONC
  CLRF	    SLRCONC
  BANKSEL   IOCCP
  CLRF	    IOCCP
  BANKSEL   IOCCN
  CLRF	    IOCCN
  BANKSEL   INLVLC
  CLRF	    INLVLC
  
;*** I2C SETUP ***
    BANKSEL	PORTA
    MOVLW	0x10
    MOVWF	EEPROM_ADDR
    CALL	Read_EEPROM
    BANKSEL	PORTA
    MOVF	EEPROM_SAVE,0
    XORLW	0XFF
    BTFSC	ZERO
    CALL	_FIRSTTIMESETUP
    MOVLW	0x10
    MOVWF	EEPROM_ADDR
    CALL	Read_EEPROM
    MOVF	EEPROM_SAVE,0
    MOVLW	0x20
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P1_R
    MOVLW	0x21
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P1_G
    MOVLW	0x22
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P1_B
    MOVLW	0x23
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P2_R
    MOVLW	0x24
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P2_G
    MOVLW	0x25
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P2_B
    MOVLW	0x26
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P3_R
    MOVLW	0x27
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P3_G
    MOVLW	0x28
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P3_B
    MOVLW	0x29
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P4_R
    MOVLW	0x2A
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P4_G
    MOVLW	0x2B
    MOVWF	EEPROM_ADDR
    MOVF	EEPROM_SAVE,0
    MOVWF	P4_B
    BANKSEL	SSP1ADD
    MOVWF	SSP1ADD
    BANKSEL	SSP1STAT
    BSF		SSP1STAT,7
    BCF		SSP1STAT,6
    BANKSEL	SSP1CON1
    MOVLW	0x26
    MOVWF	SSP1CON1
    BANKSEL	SSP1CON2
    BSF		SSP1CON2,7
    BCF		SSP1CON2,0

;*** UART SETUP ***
  BANKSEL   TRISB
  BCF	    TRISB,6
  BSF	    TRISB,7
  BANKSEL   APFCON1
  BSF	    TXSEL	;Maps TX to RB6
  BSF	    RXSEL	;Maps Rx to RB7
  BANKSEL   BAUD1CON
  BCF	    BRG16	;8-bit baud rate
  BANKSEL   TX1STA
  BCF	    BRGH	;low speed baud rate
  BCF	    SYNC	;Asynch mode
  BANKSEL   SP1BRGL
  MOVLW	    207		;Calculated value for 2400 baud
  MOVWF	    SP1BRGL	;Moves it to the baud gen
  BANKSEL   RC1STA
  BSF	    SPEN	;Serial Port Enable
  BCF	    RX9		;Select 8-bit operation
  BSF	    CREN	;Enables Continuous Receive
  BANKSEL   PIE1
  BSF	    RCIE	;Enables EUSART Receive Interrupts
  
  RETURN