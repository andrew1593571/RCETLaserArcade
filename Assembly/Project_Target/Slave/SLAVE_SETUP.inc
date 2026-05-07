;************************************************************************************
;										    *
;   Filename:	    SLAVE_SUBROUTINES.inc					    *
;   Date:	    December 13, 2025						    *
;   File Version:   3								    *
;   Author:	    Andrew Keller and Rudy Earnest		                    *
;   Company:	    Idaho State University					    *
;   Description:    Contains all subroutines needed for the Laser Shooting Game     *
;		    target slave. Subroutines include I2C communications, recording *
;		    player hits, and enabling/disabling the target. The I2C	    *
;		    communications includes the ability to both receive data from   *
;		    the master as well as the ability to respond to read requests   *
;		    from the master. When a hit is detected, the LED is flashed.    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	Initialize file, get everything working the way that I thought it should    *
;	work.									    *
;										    *
;   2:	  I2C communications for enabling/disabling the target as well as reporting *
;          any player hits to the target when the target is enabled.		    *
;                                                                                   *
;   3:  Update to V2 of the slave                                                   *
;										    *
;************************************************************************************		
		
;===============================================================================================================================*
;                                                          PORTA BITMAP                                                         *
;===============================================================================================================================*		
;       7       |       6       |       5       |       4       |       3       |       2       |       1       |       0       *
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*	
;    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    *
;     INPUT     |    OUTPUT     |     INPUT     |     INPUT     |    Output     |    Output     |    Output     |    Output     *
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*		
;  PSMC CLKIN   |    CLKOUT     |      N/C      |      N/C      |  STEPPER DIR  |    ENABLE     | HIT INDICATOR |  WS2812B LED  *
;               |               |               |               |               | INDICATOR LED |      LED      |  DATA INPUT   *		
;-------------------------------------------------------------------------------------------------------------------------------*
		
;===============================================================================================================================*
;                                                          PORTB BITMAP                                                         *
;===============================================================================================================================*		
;       7       |       6       |       5       |       4       |       3       |       2       |       1       |       0       *
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*	
;    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    *
;     INPUT     |    OUTPUT     |     INPUT     |     INPUT     |     INPUT     |     INPUT     |     INPUT     |     INPUT     *
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*		
;    UART RX    |    UART TX    |      N/C      |      N/C      |      N/C      |      N/C      |      N/C      |      N/C      *
;               |               |               |               |               |               |               |               *		
;-------------------------------------------------------------------------------------------------------------------------------*
		
;===============================================================================================================================*
;                                                          PORTC BITMAP                                                         *
;===============================================================================================================================*		
;       7       |       6       |       5       |       4       |       3       |       2       |       1       |       0       *
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*	
;    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    |    DIGITAL    *
;     INPUT     |    OUTPUT     |    OUTPUT     |     INPUT     |     INPUT     |    OUTPUT     |     INPUT     |    OUTPUT     *
;---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------*		
;      N/C      |    SERVO 2    |    SERVO 3    |    I2C SDA    |    I2C SCL    | STEPPER STEP  |      N/C      |    SERVO 1    *
;               |               |               |               |               |               |               |               *		
;-------------------------------------------------------------------------------------------------------------------------------*
	
;EEPROM Memory Map
     ;**** Do not under any circumstances ****
     ;**** Use EEPROM row 0 it is evil ****
    
;The byte at address 0x10 is used to store the I2C address of the target slave device.
;The byte at address 0x14 is used to store the LED number value
     
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
     
;The byte at address 0x31 is used to store the high byte of servo 1 enabled
;The byte at address 0x32 is used to store the low byte of servo 1 enabled
;The byte at address 0x33 is used to store the high byte of servo 1 disabled
;The byte at address 0x34 is used to store the low byte of servo 1 disabled
;The byte at address 0x35 is used to store the high byte of servo 2 enabled
;The byte at address 0x36 is used to store the low byte of servo 2 enabled
;The byte at address 0x37 is used to store the high byte of servo 2 disabled
;The byte at address 0x38 is used to store the low byte of servo 2 disabled
;The byte at address 0x39 is used to store the high byte of servo 3 enabled
;The byte at address 0x3A is used to store the low byte of servo 3 enabled
;The byte at address 0x3B is used to store the high byte of servo 3 disabled
;The byte at address 0x3C is used to store the low byte of servo 3 disabled
;The byte at address 0x3D is used to store the flag for the stepper motor
		
  
    
  EEPROM_ADDR   EQU 0x20
  EEPROM_DATA   EQU 0x21
  EEPROM_SAVE   EQU 0x22
  ;Status Registers
  TARGET_STATUS EQU 0x23
  ACTIVE        EQU 0x24
  ;I2C Variables
  RECEIVED_DATA EQU 0x25
  I2C_Color_Count   EQU 0x37
   ; For the flags bit 0 means that I2C color protocol is enabled
   ; Bit 1 means that Player 1's color is being changed
   ; Bit 2 means that Player 2's color is being changed
   ; Bit 3 means that Player 3's color is being changed
   ; Bit 4 means that Player 4's color is being changed
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
   ;EUSART VARIABLES
   EU_RX	EQU 0X39
   EU_TX	EQU 0X3A
   ;BIT 0 USED FOR THE W (0X57) COMMAND
   ;BIT 1 USED FOR THE R (0X52) COMMAND
   ;BIT 2 USED FOR THE C (0X43) COMMAND
   ;BIT 3 USED FOR THE BLASTER FIRE COMMAND
   ;BIT 4 USED FOR THE P (0X50) COMMAND
   ;BIT 5 USED FOR THE L (0X4C) COMMAND
   ;BIT 7 SAYS DOLLAR WAS RECEIVED
   EU_FLAG	EQU 0X3B
   EU_COUNTER	EQU 0X3C
   EU_TXFLAG	EQU 0X3D
   PLAYER_HIT	EQU 0X4B
   ;MOTOR VARIABLES
   CAL_POS	EQU 0X3E
   S1E_PH	EQU 0X3F
   S1E_PL	EQU 0X40
   S1D_PH	EQU 0X41
   S1D_PL	EQU 0X42
   S2E_PH	EQU 0X43
   S2E_PL	EQU 0X44
   S2D_PH	EQU 0X45
   S2D_PL	EQU 0X46
   S3E_PH	EQU 0X47
   S3E_PL	EQU 0X48
   S3D_PH	EQU 0X49
   S3D_PL	EQU 0X4A
   CAL_PH	EQU 0x4B
   CAL_PL	EQU 0x4C
   ;Color Update Variables
   UPDATE_R	EQU 0x4D
   UPDATE_G	EQU 0x4E
   UPDATE_B	EQU 0x4F
   UPDATE_P	EQU 0x50
		
INITIALIZE_CODE	CODE		
INITIALIZE	
	
;*** INTOSC SETUP *******
	
		BANKSEL	    OSCCON
		MOVLW	    0xF8			;ENABLE INTOSC, SET TO 16MHz
		MOVWF	    OSCCON
		BANKSEL	    CLKRCON
		CLRF	    CLKRCON			;DISABLE CLOCK REFERENCE
		
;*** SET OPTION_REG: ****
		
		BANKSEL	    OPTION_REG
		MOVLW	    0x48
		MOVWF	    OPTION_REG
		
;*** SET INTCON REG: ****
		
		BANKSEL INTCON
		BSF	    INTCON, IOCIE		;ENABLE IOC INTERUPT
		BCF	    INTCON, INTE		;DISABLE INT EXTERNAL INTERUPT
		BSF	    INTCON, PEIE		;ENABLE PERIPHERAL INTERUPTS
		BSF	    INTCON, GIE			;ENABLE ALL UNMASKED INTERUPTS
		
;*** SET PIE1-4 REG: *****
		
		BANKSEL	    PIE1
		MOVLW	    0x28
		MOVWF	    PIE1			;DISABLE ALL PIE1 INTERUPTS, EXCEPT SSP1F AND RCIE
		BANKSEL	    PIE2
		CLRF	    PIE2			;DISABLE ALL PIE2 INTERUPTS
		BANKSEL	    PIE3
		CLRF	    PIE3			;DISABLE ALL PIE3 INTERUPTS
		BANKSEL	    PIE4
		CLRF	    PIE4			;DISABLE ALL PIE4 INTERUPTS
		
;*** CLEAR INTERUPT FLAGS ***
		
		BANKSEL	    PIR1
		CLRF	    PIR1			;CLEAR ALL PIR1 INTERUPT FLAGS
		BANKSEL	    PIR2
		CLRF	    PIR2			;CLEAR ALL PIR2 INTERUPT FLAGS
		BANKSEL	    PIR3
		CLRF	    PIR3			;CLEAR ALL PIR3 INTERUPT FLAGS
		BANKSEL	    PIR4
		CLRF	    PIR4			;CLEAR ALL PIR4 INTERUPT FLAGS			
		
;*** ALTERNATE PIN FUNCTION *****
		
		BANKSEL	    APFCON1
		MOVLW	    0x06
		MOVWF	    APFCON1			;SELECTS PORT MAPPING
		CLRF	    APFCON2			;SEE DATASHEET (pg 132-133) FOR MAPPING WITH BOTH CLEARED
		
;*** TMR1 SETUP ****
		
		BANKSEL	    T1CON
		MOVLW	    0x30			;ENABLE & SELECT TMR1 INSTRUCTION CLOCK (FOSC/4), SET PRESCALE TO 1:8, DISABLE TMR1 AT THIS POINT
		BANKSEL	    T1GCON
		CLRF	    T1GCON			;DISABLE TMR1 GATE
 
;*** PORT A SETUP **** PORT A SET AS LOGIC INPUT (I2C ADDRESS)

		BANKSEL	    PORTA
		MOVLW	    0x00
		MOVWF	    PORTA			;CLEAR PORTA
		BANKSEL	    LATA
		MOVLW	    0x00			;CLEAR LATA
		MOVWF	    LATA
		BANKSEL	    TRISA
		MOVLW	    0xF0  
		MOVWF	    TRISA			;SET PORTA ALL AS INPUTS
		BANKSEL	    ODCONA
		CLRF	    ODCONA			;DISABLE PORTA OPEN-DRAIN		
		BANKSEL	    ANSELA			
		CLRF	    ANSELA			;SET PORTA ALL AS DIGITAL INPUT
		BANKSEL	    SLRCONA
		CLRF	    SLRCONA			;SET THE SLEW RATE FOR PORT A TO MAXIMUM
		BANKSEL	    IOCAP
		MOVLW	    0x00
		MOVWF	    IOCAP
		BANKSEL	    IOCAN
		CLRF	    IOCAN
		
;*** PORT B SETUP **** PORT B USED AS LOGIC INPUT AND OUTPUT
		
		BANKSEL	    PORTB
		MOVLW	    0x00
		MOVWF	    PORTB			;CLEAR PORTB	
		BANKSEL	    LATB
		CLRF	    LATB			;CLEAR LATB
		BANKSEL	    TRISB
		MOVLW	    0xFF				
		MOVWF	    TRISB			;SET PORTB ACCORDING TO BITMAP
		BANKSEL	    ODCONB
		CLRF	    ODCONB			;DISABLE PORTB OPEN-DRAIN
		BANKSEL	    ANSELB
		CLRF	    ANSELB			;MAKE PORTB DIGITAL INPUTS
		BANKSEL	    SLRCONB
		CLRF	    SLRCONB			;SET THE SLEW RATE FOR PORT B TO MAXIMUM
		BANKSEL	    IOCBP
		MOVLW	    0x00			;DISABLE PORTB IOC FOR POSITIVE EDGES
		MOVWF	    IOCBP
		BANKSEL	    IOCBN
		MOVLW	    0x00			;ENABLE PORTB IOC FOR NEGATIVE EDGES ON RB0 AND RB1
		MOVWF	    IOCBN
		BANKSEL	    INLVLB
		CLRF	    INLVLB			;SET PORTB INPUT THRESHOLD TO TTL (IGNORED NOISE BETTER FOR TRIGGER INPUT)	    	    
		
;*** PORT C SETUP **** 
		
		BANKSEL	    PORTC
		CLRF	    PORTC			;CLEAR PORTC
		BANKSEL	    LATC
		CLRF	    LATC			;CLEAR LATC
		BANKSEL	    TRISC
		MOVLW	    0x9A				
		MOVWF	    TRISC			;SET PORTC ALL AS INPUTS
		BANKSEL	    ODCONC
		CLRF	    ODCONC			;DISABLE PORTC OPEN-DRAIN
		BANKSEL	    ANSELC
		CLRF	    ANSELC			;MAKE PORTC ALL DIGITAL I/O
		BANKSEL	    SLRCONC
		CLRF	    SLRCONC			;SET THE SLEW RATE FOR PORT C TO MAXIMUM
		BANKSEL	    IOCCP
		MOVLW	    0x00			;DISALBE PORTC IOC FOR POSITIVE EDGES
		MOVWF	    IOCCP
		BANKSEL	    IOCCN
		MOVLW	    0x00			;DISABLE PORTC IOC FOR NEGATIVE EDGES
		MOVWF	    IOCCN
		BANKSEL	    INLVLC
		CLRF	    INLVLC			;SET PORTC INPUT THRESHOLD TO TTL (IGNORED NOISE BETTER FOR TRIGGER INPUT)
		
;*** I2C SETUP ****
		BANKSEL	    PORTA
		MOVLW	    0x10
		MOVWF	    EEPROM_ADDR
		;MOVLW	    0x04			;The I2C Target of what we want
		;MOVWF	    EEPROM_DATA
		;CALL	    Write_EEPROM
		;MOVLW	    0x10			;Where the data is Stored
		;MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		BANKSEL	    PORTA
		MOVFW	    EEPROM_SAVE
		BANKSEL	    SSPADD		
		MOVWF	    SSPADD			;SET I2C ADDRESS
		BANKSEL	    SSPCON
		MOVLW	    0x16			;SET TO I2C 7-BIT ADDRESS SLAVE MODE
		MOVWF	    SSPCON			;
		BSF	    SSPCON,5			;ENABLE SERIAL PORT FOR I2C
		BANKSEL	    SSPCON2
		MOVLW	    0x80
		MOVWF	    SSPCON2
		BANKSEL	    SSPCON3
		CLRF	    SSPCON3
		BANKSEL	    SSPSTAT
		MOVLW	    0xC0
		MOVWF	    SSPSTAT
		
		
;*** UART SETUP ***
		BANKSEL	    SP1BRGH
		MOVLW	    0x03			;SET UART BAUD RATE TO 9600 W/ 16MHz OSCILLATOR
		MOVWF	    SP1BRGH
		BANKSEL	    SP1BRGL
		MOVLW	    0x40
		MOVWF	    SP1BRGL
		BANKSEL	    BAUD1CON
		MOVLW	    0x08			;00001000 CONFIGURE FOR 16-BIT BAUD RATE GENERATOR
		MOVWF	    BAUD1CON
		BANKSEL	    RC1STA
		MOVLW	    0x90			;10010000 ENABLE UART PORT, ENABLE RECEIVER
		MOVWF	    RC1STA
		BANKSEL	    TX1STA
		MOVLW	    0x20			;00100110 ENABLE TRANSMITTER, HIGH SPEED MODE, ASYNCHRONOUS
		MOVWF	    TX1STA
  
		
;*** BOOT CODE ****
		
		BANKSEL	    PORTA
		CLRF	    TARGET_STATUS		;CLEAR TARGET_STATUS TO PREVENT INACCURATE SCORE
		CLRF	    ACTIVE			;ENSURE TARGET STARTS DISABLED	    
		BANKSEL	    INTCON  
		BCF	    INTCON,0
		BANKSEL	    IOCAF
		CLRF	    IOCAF
		BCF	    INTCON,IOCIF		;CLEAR IOCIF
		BANKSEL	    PORTA
		
;*** LOAD FROM EEPROM ***
		BANKSEL	    PORTA			;RETRIEVE THE _LEDNUMBER FROM EEPROM
		MOVLW	    0x14
		MOVWF	    EEPROM_ADDR
		;MOVLW	    0x0D
		;MOVWF	    EEPROM_DATA
		;CALL	    Write_EEPROM
		;MOVLW	    0x14
		;MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    _LEDNUMBER
		
		BANKSEL	    PORTA			;RETRIEVE THE P1_R FROM EEPROM
		MOVLW	    0x20
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P1_R
		
		BANKSEL	    PORTA			;RETRIEVE THE P1_G FROM EEPROM
		MOVLW	    0x21
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P1_G
		
		BANKSEL	    PORTA			;RETRIEVE THE P1_B FROM EEPROM
		MOVLW	    0x22
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P1_B
		
		
		BANKSEL	    PORTA			;RETRIEVE THE P2_R FROM EEPROM
		MOVLW	    0x23
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P2_R
		
		BANKSEL	    PORTA			;RETRIEVE THE P2_G FROM EEPROM
		MOVLW	    0x24
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P2_G
		
		BANKSEL	    PORTA			;RETRIEVE THE P2_B FROM EEPROM
		MOVLW	    0x25
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P2_B
		
		BANKSEL	    PORTA			;RETRIEVE THE P3_R FROM EEPROM
		MOVLW	    0x26
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P3_R
		
		BANKSEL	    PORTA			;RETRIEVE THE P3_G FROM EEPROM
		MOVLW	    0x27
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P3_G
		
		BANKSEL	    PORTA			;RETRIEVE THE P3_B FROM EEPROM
		MOVLW	    0x28
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P3_B
		
		BANKSEL	    PORTA			;RETRIEVE THE P4_R FROM EEPROM
		MOVLW	    0x29
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P4_R
		
		BANKSEL	    PORTA			;RETRIEVE THE P4_G FROM EEPROM
		MOVLW	    0x2A
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P4_G
		
		BANKSEL	    PORTA			;RETRIEVE THE P4_B FROM EEPROM
		MOVLW	    0x2B
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    P4_B
		
		BANKSEL	    PORTA			;RETRIEVE THE S1E_PH FROM EEPROM
		MOVLW	    0x31
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S1E_PH
		BANKSEL	    PORTA			;RETRIEVE THE S1E_PL FROM EEPROM
		MOVLW	    0x32
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S1E_PL
		BANKSEL	    PORTA			;RETRIEVE THE S1D_PH FROM EEPROM
		MOVLW	    0x33
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S1D_PH
		BANKSEL	    PORTA			;RETRIEVE THE S1D_PL FROM EEPROM
		MOVLW	    0x34
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S1D_PL
		
		BANKSEL	    PORTA			;RETRIEVE THE S2E_PH FROM EEPROM
		MOVLW	    0x35
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S2E_PH
		BANKSEL	    PORTA			;RETRIEVE THE S2E_PL FROM EEPROM
		MOVLW	    0x36
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S2E_PL
		BANKSEL	    PORTA			;RETRIEVE THE S2D_PH FROM EEPROM
		MOVLW	    0x37
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S2D_PH
		BANKSEL	    PORTA			;RETRIEVE THE S2D_PL FROM EEPROM
		MOVLW	    0x38
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S2D_PL
		
		BANKSEL	    PORTA			;RETRIEVE THE S3E_PH FROM EEPROM
		MOVLW	    0x39
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S3E_PH
		BANKSEL	    PORTA			;RETRIEVE THE S3E_PL FROM EEPROM
		MOVLW	    0x3A
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S3E_PL
		BANKSEL	    PORTA			;RETRIEVE THE S3D_PH FROM EEPROM
		MOVLW	    0x3B
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S3D_PH
		BANKSEL	    PORTA			;RETRIEVE THE S3D_PL FROM EEPROM
		MOVLW	    0x3C
		MOVWF	    EEPROM_ADDR
		CALL	    Read_EEPROM
		MOVFW	    EEPROM_SAVE
		MOVWF	    S3D_PL
		
  ;*** PSMC SETUP ***
		BANKSEL	    PSMC1OEN
		MOVLW	    0X01
		MOVWF	    PSMC1OEN
		BSF	    PSMC1PRS, P1PRST
		BSF	    PSMC1PHS,P1PHST
		BSF	    PSMC1DCS,P1DCST
		MOVLW	    0X32
		MOVWF	    PSMC1CLK
		CLRF	    PSMC1PHH
		CLRF	    PSMC1PHL
		MOVLW	    0X20
		MOVWF	    PSMC1PRL
		MOVLW	    0X4E
		MOVWF	    PSMC1PRH
		BANKSEL	    PORTA
		MOVFW	    S1D_PH
		BANKSEL	    PSMC1DCH
		MOVWF	    PSMC1DCH
		BANKSEL	    PORTA
		MOVFW	    S1D_PL
		BANKSEL	    PSMC1DCL
		MOVWF	    PSMC1DCL
		MOVLW	    0XC0
		MOVWF	    PSMC1CON
		
		BANKSEL	    PSMC2OEN
		MOVWF	    PSMC2OEN
		BSF	    PSMC2PRS,P2PRST
		BSF	    PSMC2PHS,P2PHST
		BSF	    PSMC2DCS,P2DCST
		MOVLW	    0X32
		MOVWF	    PSMC2CLK
		CLRF	    PSMC2PHH
		CLRF	    PSMC2PHL
		MOVLW	    0X20
		MOVWF	    PSMC2PRL
		MOVLW	    0X4E
		MOVWF	    PSMC2PRH
		BANKSEL	    PORTA
		MOVFW	    S2D_PH
		BANKSEL	    PSMC2DCH
		MOVWF	    PSMC2DCH
		BANKSEL	    PORTA
		MOVFW	    S2D_PL
		BANKSEL	    PSMC2DCL
		MOVWF	    PSMC2DCL
		MOVLW	    0XC0
		MOVWF	    PSMC2CON
		
		BANKSEL	    PSMC3OEN
		MOVWF	    PSMC3OEN
		BSF	    PSMC3PRS,P3PRST
		BSF	    PSMC3PHS,P3PHST
		BSF	    PSMC3DCS,P3DCST
		MOVLW	    0X32
		MOVWF	    PSMC3CLK
		CLRF	    PSMC3PHH
		MOVWF	    PSMC3PHL
		MOVLW	    0X20
		MOVWF	    PSMC3PRL
		MOVLW	    0X4E
		MOVWF	    PSMC3PRH
		BANKSEL	    PORTA
		MOVFW	    S3D_PH
		BANKSEL	    PSMC3DCH
		MOVWF	    PSMC3DCH
		BANKSEL	    PORTA
		MOVFW	    S3D_PL
		BANKSEL	    PSMC3DCL
		MOVWF	    PSMC3DCL
		MOVLW	    0XC0
		MOVWF	    PSMC3CON
		
		BANKSEL	    TRISC
		BCF	    TRISC,0
		BCF	    TRISC,5
		BCF	    TRISC,6

		BANKSEL	    PORTA
		CLRF	    EU_FLAG
		CLRF	    PLAYER_HIT
		CALL	    DISABLE_TARGET

		RETURN					;RETURN TO .asm FILE