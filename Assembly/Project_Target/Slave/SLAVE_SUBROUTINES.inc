;************************************************************************************
;										    *
;   Filename:	    SLAVE_SUBROUTINES.inc					    *
;   Date:	    November 19, 2025						    *
;   File Version:   2								    *
;   Author:	    Rudy Earnest				                    *
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
;										    *
;************************************************************************************		
    
#include <xc.inc>

    
//SUBROUTINES_CODE CODE
    PSECT code
    ;RECEIVES AND INTERPRETS I2C DATA, RESPONDS TO I2C READ REQUESTS
RECEIVE: 
	    BANKSEL	PIR1
	    BCF		SSP1IF		;IMMEDIATELY CLEAR INTERRUPT FLAG
	    BANKSEL	SSP1BUF			;\READ BYTE FROM MASTER
	    MOVF	SSP1BUF,0		;/
	    MOVWF	RECEIVED_DATA
	    BANKSEL	SSP1STAT		;DETERMINE IF THE RECEIVED BYTE WAS DATA OR ADDRESS
	    BTFSS	SSP1STAT,5		;1=DATA, 0=ADDRESS
	    GOTO	CHECK_READ_OR_WRITE	;BYTE RECEIVED WAS ADDRESS, CHECK IF R/W
	    GOTO	SAVE_DATA		;BYTE RECEIVED WAS DATA, SAVE BYTE
	    
	CHECK_READ_OR_WRITE:
	    BTFSS	SSP1STAT,2		;TEST IF ADDRESS BYTE WAS R/W: R = 1, W = 0
	    GOTO	SAVE_DATA		;MASTER WRITE: SAVE DATA
	    GOTO	TRANSMIT_STATUS		;MASTER READ: TRANSMIT THE TARGET STATUS
	
	;TESTS THE RECEIVED DATA AGAINST THE KNOWN ENABLE AND DISABLE COMMANDS
	SAVE_DATA:
	    BANKSEL	PORTA
	    BTFSC	I2C_ColorFlag,0
	    CALL	CHANGE_COLOR
	    MOVF	RECEIVED_DATA,0
	    XORLW	0X45
	    BTFSC	ZERO	    ;IF RECEIVED BYTE IS ENABLE COMMAND, SET TARGET TO ACTIVE
	    BSF		ACTIVE, 0	    
	    MOVF	RECEIVED_DATA,0
	    XORLW	0X44
	    BTFSC	ZERO	    ;IF RECEIVED BYTE IS DISABLE COMMAND, SET TARGET TO INACTIVE
	    BCF		ACTIVE, 0
	    MOVF	RECEIVED_DATA,0
	    XORLW	0X43
	    BTFSC	ZERO
	    CALL	CHANGE_COLOR
	    RETURN
	    
	CHANGE_COLOR:
	    BSF		I2C_ColorFlag,0
	    INCF	I2C_Color_Count
	    MOVF	I2C_Color_Count,0
	    XORLW	0X01
	    BTFSC	ZERO
	    RETURN
	    MOVF	I2C_Color_Count,0
	    XORLW	0X02
	    BTFSC	ZERO
	    GOTO	Player_Number
	    MOVF	I2C_Color_Count,0
	    XORLW	0x03
	    BTFSC	ZERO
	    GOTO	Green
	    MOVF	I2C_Color_Count,0
	    XORLW	0x04
	    BTFSC	ZERO
	    GOTO	Red
	    MOVF	I2C_Color_Count,0
	    XORLW	0x05
	    BTFSC	ZERO
	    GOTO	Blue
	    BCF		I2C_ColorFlag,0
	    CLRF	I2C_Color_Count
	    RETURN
	    
	    //Sets the flag in accordance
	    //to what player color is being changed
	    Player_Number:
	    MOVF	RECEIVED_DATA,0
	    XORLW	0x01
	    BTFSC	ZERO
	    BSF		I2C_ColorFlag,1
	    MOVF	RECEIVED_DATA,0
	    XORLW	0x02
	    BTFSC	ZERO
	    BSF		I2C_ColorFlag,2
	    MOVF	RECEIVED_DATA,0
	    XORLW	0x03
	    BTFSC	ZERO
	    BSF		I2C_ColorFlag,3
	    MOVF	RECEIVED_DATA,0
	    XORLW	0x04
	    BTFSC	ZERO
	    BSF		I2C_ColorFlag,4
	    RETURN
	    
	    //For changing Green color based
	    //off of player number
	    Green:
	    BTFSC	I2C_ColorFlag,1
	    GOTO	Player1_Green
	    BTFSC	I2C_ColorFlag,2
	    GOTO	Player2_Green
	    BTFSC	I2C_ColorFlag,3
	    GOTO	Player3_Green
	    BTFSC	I2C_ColorFlag,4
	    GOTO	Player4_Green
	    RETURN
	    Player1_Green:
	    MOVLW	0x21
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P1_G
	    Call	Write_EEPROM
	    RETURN
	    Player2_Green:
	    MOVLW	0x24
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P2_G
	    Call	Write_EEPROM
	    RETURN
	    Player3_Green:
	    MOVLW	0x27
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P3_G
	    Call	Write_EEPROM
	    RETURN
	    Player4_Green:
	    MOVLW	0x2A
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P4_G
	    Call	Write_EEPROM
	    RETURN
	    
	    //For changing the red color based off of
	    //Player number
	    Red:
	    BTFSC	I2C_ColorFlag,1
	    GOTO	Player1_RED
	    BTFSC	I2C_ColorFlag,2
	    GOTO	Player2_RED
	    BTFSC	I2C_ColorFlag,3
	    GOTO	Player3_RED
	    BTFSC	I2C_ColorFlag,4
	    GOTO	Player4_RED
	    RETURN
	    Player1_RED:
	    MOVLW	0x20
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P1_R
	    Call	Write_EEPROM
	    RETURN
	    Player2_RED:
	    MOVLW	0x23
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P2_R
	    Call	Write_EEPROM
	    RETURN
	    Player3_RED:
	    MOVLW	0x26
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P3_R
	    Call	Write_EEPROM
	    RETURN
	    Player4_RED:
	    MOVLW	0x29
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P4_R
	    Call	Write_EEPROM
	    RETURN
	    
	    //For changing the Blue color
	    //based off of player number
	    Blue:
	    BTFSC	I2C_ColorFlag,1
	    GOTO	Player1_Blue
	    BTFSC	I2C_ColorFlag,2
	    GOTO	Player2_Blue
	    BTFSC	I2C_ColorFlag,3
	    GOTO	Player3_Blue
	    BTFSC	I2C_ColorFlag,4
	    GOTO	Player4_Blue
	    RETURN
	    Player1_Blue:
	    MOVLW	0x22
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P1_B
	    Call	Write_EEPROM
	    RETURN
	    Player2_Blue:
	    MOVLW	0x25
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P2_B
	    Call	Write_EEPROM
	    RETURN
	    Player3_Blue:
	    MOVLW	0x28
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P3_B
	    Call	Write_EEPROM
	    RETURN
	    Player4_Blue:
	    MOVLW	0x2B
	    MOVWF	EEPROM_ADDR
	    MOVF	RECEIVED_DATA,0
	    MOVWF	EEPROM_DATA
	    MOVWF	P4_B
	    Call	Write_EEPROM
	    RETURN
	    
    
	;TRANSMIT THE CURRENT TARGET STATUS BACK TO THE MASTER IF A READ WAS RECEIVED
	TRANSMIT_STATUS:
	    BANKSEL	PORTA
	    MOVF	TARGET_STATUS,0	    ;RETREIVE THE CURRENT TARGET STATUS
	    BANKSEL	SSP1BUF
	    MOVWF	SSP1BUF		    ;MOVE THE TARGET STATUS INTO THE I2C BUFFER
	    BANKSEL	SSP1CON1
	    BSF		CKP	    ;START THE CLOCK TO BEGIN DATA TRANSMISSION
	    BANKSEL	PORTA
	    BTFSC	TARGET_STATUS,3	    ;IF THE TARGET_STATUS IS 0X0F, RESET THE TARGET
	    CALL	RESET_TARGET
	    BTFSC	TARGET_STATUS,7	    ;IF THE TARGET_STATUS IS 0XF0, RESET THE TARGET
	    CALL	RESET_TARGET
	    RETURN
	    
	;CLEARS THE ACTIVE FLAG AND THE TARGET_STATUS REGISTER
	;PREPARES THE TARGET TO BE ENABLED AGAIN
	RESET_TARGET:
	    CLRF	ACTIVE
	    CLRF	TARGET_STATUS
	    RETURN
	    
EUSART_RX:
	    BANKSEL	PIR1
	    BCF		RCIF
	    BANKSEL	RC1STA
	    MOVF	RC1STA,0
	    MOVWF	EU_RX
	    BTFSC	EU_FLAG,0
	    GOTO	WRITE_I2C
	    BTFSC	EU_FLAG,1
	    GOTO	READ_I2C
	    BTFSC	EU_FLAG,2
	    GOTO	PLAYER_COLOR
	    BTFSC	EU_FLAG,3
	    GOTO	BLASTER
	    BTFSC	EU_FLAG,4
	    GOTO	POSITION
	    BTFSC	EU_FLAG,5
	    GOTO	UPDATE_LED
	    MOVF	EU_RX,0
	    XORLW	0X3C
	    BTFSC	ZERO
	    GOTO	BLASTER
	    MOVF	EU_RX,0
	    XORLW	0X24
	    BTFSC	ZERO
	    GOTO	DOLLAR
	    MOVF	EU_RX,0
	    XORLW	0X56
	    BTFSC	ZERO
	    GOTO	DEVICE_VERIFICATION
	    MOVF	EU_RX,0
	    XORLW	0X57
	    BTFSC	ZERO
	    GOTO	WRITE_I2C
	    MOVF	EU_RX,0
	    XORLW	0X52
	    BTFSC	ZERO
	    GOTO	READ_I2C
	    MOVF	EU_RX,0
	    XORLW	0X53
	    BTFSC	ZERO
	    GOTO	READ_SETTINGS
	    MOVF	EU_RX,0
	    XORLW	0X43
	    BTFSC	ZERO
	    GOTO	PLAYER_COLOR
	    MOVF	EU_RX,0
	    XORLW	0X50
	    BTFSC	ZERO
	    GOTO	POSITION
	    MOVF	EU_RX,0
	    XORLW	0X4C
	    BTFSC	ZERO
	    GOTO	UPDATE_LED
	    GOTO	NULL
	    RETURN
	    
    BLASTER:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_FLAG,3
	    BCF		EU_FLAG,7
	    BCF		EU_FLAG,3
	    RETURN
	    
    DOLLAR:
	    BSF		EU_FLAG,7
	    RETURN
	    
    DEVICE_VERIFICATION:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_TXFLAG,0
	    BANKSEL	PIE1
	    BSF		TXIE
	    BCF		EU_FLAG,7
	    RETURN
	    
    WRITE_I2C:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_FLAG,0
	    INCF	EU_COUNTER
	    MOVF	EU_COUNTER,0
	    XORLW	0X03
	    BTFSS	ZERO
	    RETURN
	    CLRF	EU_COUNTER
	    BSF		EU_TXFLAG,7
	    BANKSEL	PIE1
	    BSF		TXIE
	    BCF		EU_FLAG,7
	    BCF		EU_FLAG,0
	    RETURN
	    
    READ_I2C:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_FLAG,1
	    INCF	EU_COUNTER
	    MOVF	EU_COUNTER
	    XORLW	0X02
	    BTFSS	ZERO
	    RETURN
	    BSF		EU_TXFLAG,7
	    BANKSEL	PIE1
	    BSF		TXIE
	    CLRF	EU_COUNTER
	    BCF		EU_FLAG,7
	    BCF		EU_FLAG,1
	    RETURN
	    
    READ_SETTINGS:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_TXFLAG,2
	    BANKSEL	PIE1
	    BSF		TXIE
	    BCF		EU_FLAG,7
	    RETURN
	    
    PLAYER_COLOR:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_FLAG,2
	    MOVF	EU_RX,0
	    MOVWF	RECEIVED_DATA
	    INCF	EU_COUNTER
	    MOVF	EU_COUNTER,0
	    XORLW	0X01
	    BTFSC	ZERO
	    RETURN
	    MOVF	EU_COUNTER,0
	    XORLW	0X02
	    BTFSC	ZERO
	    GOTO	Player_Number
	    MOVF	EU_COUNTER,0
	    XORLW	0X03
	    BTFSC	ZERO
	    GOTO	Green
	    MOVF	EU_COUNTER,0
	    XORLW	0X04
	    BTFSC	ZERO
	    GOTO	Red
	    MOVF	EU_COUNTER,0
	    XORLW	0X05
	    BTFSC	ZERO
	    CALL	Blue
	    BSF		EU_TXFLAG,1
	    BANKSEL	PIE1
	    BSF		TXIE
	    CLRF	EU_COUNTER
	    BCF		EU_FLAG,7
	    BCF		EU_FLAG,2
	    RETURN
	    
    POSITION:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_FLAG,4
	    INCF	EU_COUNTER
	    MOVF	EU_COUNTER,0
	    XORLW	0X01
	    BTFSC	ZERO
	    RETURN
	    MOVF	EU_COUNTER,0
	    XORLW	0X02
	    BTFSC	ZERO
	    GOTO	OUTPUT
	    MOVF	EU_COUNTER,0
	    XORLW	0X03
	    BTFSC	ZERO
	    GOTO	POS_H
	    MOVF	EU_COUNTER,0
	    XORLW	0X04
	    BTFSC	ZERO
	    CALL	POS_L
	    BSF		EU_TXFLAG,1
	    BANKSEL	PIE1
	    BSF		TXIE
	    CLRF	EU_COUNTER
	    BCF		EU_FLAG,7
	    BCF		EU_FLAG,4
	    RETURN
	    
    UPDATE_LED:
	    BTFSS	EU_FLAG,7
	    RETURN
	    BSF		EU_FLAG,5
	    INCF	EU_COUNTER
	    MOVF	EU_COUNTER,0
	    XORLW	0X01
	    BTFSC	ZERO
	    RETURN
	    MOVF	EU_COUNTER,0
	    XORLW	0X02
	    BTFSC	ZERO
	    CALL	LED_NUMBER
	    BSF		EU_TXFLAG,1
	    BANKSEL	PIE1
	    BSF		TXIE
	    CLRF	EU_COUNTER
	    BCF		EU_FLAG,7
	    BCF		EU_FLAG,5
	    RETURN
	    
    NULL:
	    BANKSEL	PIE1
	    BSF		TXIE
	    BSF		EU_TXFLAG,7
	    RETURN
	    
	    
	    
EUSART_TX:
	    BANKSEL	PIR1
	    BCF		TXIF
	    BANKSEL	PORTA
	    
	    
    ;LOOPS UNTIL TMR1 OVERFLOW
WAIT_FOR_TMR1:
	    BCF		PIR1,0			;CLEAR TMR1IF
	    BANKSEL	T1CON
	    BSF		T1CON,0			;ENABLE TIMER 1
	    BANKSEL	TMR1L
	    CLRF	TMR1L			;/RESET TMR1 FOR FULL TIMING
	    CLRF	TMR1H			;\
	    BCF		PIR1,0			;CLEAR TMR1IF
	    BTFSS	PIR1,0			;POLL TMR1IF UNTIL COMPLETE
	    GOTO	$-1			;TMR1 NOT DONE
	    BANKSEL	T1CON
	    BCF		T1CON,0			;DISABLE TIMER 1
	    RETURN
	    
    ;TURNS OFF ALL LEDS ON THE TARGET
TURN_OFF_LEDS:
	    BANKSEL	_LEDNUMBER
	    MOVLW	0X01
	    MOVWF	_LEDNUMBER
	    MOVLW	0X00
	    MOVWF	_SENDLEDRED
	    MOVWF	_SENDLEDGREEN
	    MOVWF	_SENDLEDBLUE
	    BCF		GIE
	    CALL	_SENDLED
	    BSF		GIE
	    RETURN
	    
    ;TURNS ON THE LEDS ASSOCIATED WITH AN ACTIVE TARGET
TURN_ON_LEDS:
	    BANKSEL	PORTA
	    MOVLW	0X11
	    MOVWF	EEPROM_ADDR
	    CALL	Read_EEPROM
	    BANKSEL	PORTA
	    MOVF	EEPROM_SAVE,0
	    MOVWF	_SENDLEDRED
	    MOVLW	0X12
	    MOVWF	EEPROM_ADDR
	    CALL	Read_EEPROM
	    BANKSEL	PORTA
	    MOVF	EEPROM_SAVE,0
	    MOVWF	_SENDLEDGREEN
	    MOVLW	0X13
	    MOVWF	EEPROM_ADDR
	    CALL	Read_EEPROM
	    BANKSEL	PORTA
	    MOVF	EEPROM_SAVE,0
	    MOVWF	_SENDLEDBLUE
	    BCF		GIE
	    CALL	_SENDLED
	    BSF		GIE
	    RETURN

	;Writes to EEPROM
	;**** Do not under any circumstances ****
	;**** Use EEPROM row 0 it is evil ****
Write_EEPROM:
	    BANKSEL	PORTA
	    MOVF	EEPROM_ADDR,0
	    BANKSEL	EEADRL
	    MOVWF	EEADRL
	    BANKSEL	PORTA
	    MOVF	EEPROM_DATA,0
	    BANKSEL	EEDATL
	    MOVWF	EEDATL
	    BCF		EECON1,6
	    BCF		EECON1,7
	    BSF		EECON1,2

	    BCF		INTCON,7
	    MOVLW	0x55
	    MOVWF	EECON2
	    MOVLW	0xAA
	    MOVWF	EECON2
	    BSF		WR
    Loop:   BSF		GIE
	    BCF		WREN
	    BTFSC	WR
	    GOTO	Loop
	    RETURN

	;Reads from EEPROM
	;**** Do not under any circumstances ****
	;**** Use EEPROM row 0 it is evil ****
Read_EEPROM:
	    BANKSEL	PORTA
	    MOVF	EEPROM_ADDR,0
	    BANKSEL	EEADRL
	    MOVWF	EEADRL
	    BANKSEL	EECON1
	    BCF		EECON1,6
	    BCF		EECON1,7
	    BSF		EECON1,0
	    MOVF	EEDATL,0
	    BANKSEL	PORTA
	    MOVWF	EEPROM_SAVE
	    RETURN
	    
	    
_FIRSTTIMESETUP:
           ;**** Do not under any circumstances ****
	   ;**** Use EEPROM row 0 it is evil ****
	    ;This runs the first time address setup of 1
	    BANKSEL	PORTA
	    MOVLW	0x10
	    MOVWF	EEPROM_ADDR
	    MOVLW	0x01
	    MOVWF	EEPROM_DATA
	    CALL	Write_EEPROM
	    ;This runs setup for the red value for init target of 0
	    BANKSEL	PORTB
	    MOVLW	0X11
	    MOVWF	EEPROM_ADDR
	    MOVLW	0X00
	    MOVWF	EEPROM_DATA
	    CALL	Write_EEPROM
	    ;This runs setup for the green value for init target of 255
	    BANKSEL	PORTA
	    MOVLW	0X12
	    MOVWF	EEPROM_ADDR
	    MOVLW	0XFF
	    MOVWF	EEPROM_DATA
	    CALL	Write_EEPROM
	    ;This runs setup for the blue value for init target of 0
	    BANKSEL	PORTA
	    MOVLW	0X13
	    MOVWF	EEPROM_ADDR
	    MOVLW	0X00
	    MOVWF	EEPROM_DATA
	    CALL	Write_EEPROM
	    BANKSEL	PORTA
	    ;All player colors will initally be white because the EEPROM inits
	    ;to FF in all registers when programming the pic with
	    ;clear memory enabled
	    
	    RETURN
	    
	