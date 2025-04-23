;************************************************************************************
;										    *
;   Filename:	    SUBROUTINES.inc						    *
;   Date:	    November 5, 2024						    *
;   File Version:   1								    *
;   Author:	    Alex Wheelock						    *
;   Company:	    Idaho State University					    *
;   Description:    Contains all subroutines needed for the Laser Shooting Game     *
;		    project. Subroutines include the ability to swap between the    *
;		    two player PWM frequencies of 56kHz and 38kHz, and the ability  *
;		    to shoot in three different modes (single-shot, burst,	    *
;		    & continuous), to move a solenoid and shoot	the laser with the  *
;		    press of a button.						    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	Initialize file, get everything working the way that I thought it should    *
;	work.									    *								    *
;										    *
;************************************************************************************		
	    
SUBROUTINES_CODE CODE
  
   RECEIVE 
	    BANKSEL	PIR1
	    BCF		PIR1, SSP1IF		;IMMEDIATELY CLEAR INTERRUPT FLAG
	    BANKSEL	SSP1BUF			;\READ BYTE FROM MASTER
	    MOVFW	SSP1BUF			;/
	    MOVWF	RECEIVED_DATA
	    BANKSEL	SSP1STAT			;DETERMINE IF THE RECEIVED BYTE WAS DATA OR ADDRESS
	    BTFSS	SSP1STAT,5		;1=DATA, 0=ADDRESS
	    GOTO	CHECK_READ_OR_WRITE	;BYTE RECEIVED WAS ADDRESS, CHECK IF R/W
	    GOTO	SAVE_DATA		;BYTE RECEIVED WAS DATA, SAVE BYTE
	    
    CHECK_READ_OR_WRITE	
	    BTFSS	SSP1STAT,2		;TEST IF ADDRESS BYTE WAS R/W: R = 1, W = 0
	    GOTO	SAVE_DATA		;MASTER WRITE: SAVE DATA OR INDICATE THAT THE SLAVE IS READY TO SAVE THE NEXT BYTE
	    GOTO	TRANSMIT_STATUS		;MASTER READ: TRANSMIT THE TARGET STATUS
	
    SAVE_DATA
	    BANKSEL	PORTA
	    MOVWF	RECEIVED_DATA
	    XORLW	0X45
	    BTFSC	STATUS, Z	    ;IF RECEIVED BYTE IS ENABLE COMMAND, SET TARGET TO ACTIVE
	    BSF		ACTIVE, 0	    
	    MOVFW	RECEIVED_DATA
	    XORLW	0X44
	    BTFSC	STATUS, Z	    ;IF RECEIVED BYTE IS DISABLE COMMAND, SET TARGET TO INACTIVE
	    BCF		ACTIVE, 0
	    RETURN
    
    TRANSMIT_STATUS
	    BANKSEL	PORTA
	    MOVFW	TARGET_STATUS
	    BANKSEL	SSP1BUF
	    MOVWF	SSP1BUF
	    BANKSEL	SSP1CON1
	    BSF		SSP1CON1, CKP
	    BANKSEL	PORTA
	    BTFSC	TARGET_STATUS,3
	    CALL	RESET_TARGET
	    BTFSC	TARGET_STATUS,7
	    CALL	RESET_TARGET
	    
	    RETURN
	    
	RESET_TARGET
	    CLRF	ACTIVE
	    CLRF	TARGET_STATUS
	    RETURN
	    
    RECORD_PLAYER1_HIT
	    BANKSEL	PORTB
	    BTFSS	ACTIVE, 0
	    GOTO	RETURNFROMHIT
	    BSF		PORTB,2
	    BCF		PORTB,3
	    BSF		PORTB,4
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BCF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BCF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTB,2
	    BCF		ACTIVE,0
	    MOVLW	0x0F
	    MOVWF	TARGET_STATUS
	    GOTO	RETURNFROMHIT
	    
	    
    RECORD_PLAYER2_HIT
	    BANKSEL	PORTB
	    BTFSS	ACTIVE, 0
	    GOTO	RETURNFROMHIT
	    BSF		PORTB,2
	    BCF		PORTB,3
	    BSF		PORTB,4
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BCF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BCF		PORTB,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTB,2
	    BCF		ACTIVE,0
	    MOVLW	0xF0
	    MOVWF	TARGET_STATUS
	    GOTO	RETURNFROMHIT
	    
    RETURNFROMHIT
	    BANKSEL	IOCBF
	    CLRF	IOCBF			;CLEAR THE INTERRUPT ON CHANGE PORTB FLAGS
	    RETFIE
	    
    WAIT_FOR_TMR1
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
	    BCF		T1CON,0			;ENABLE TIMER 1
	    RETURN
	    
	    
    TURN_OFF_LEDS:
	    BANKSEL	PORTB
	    BSF		PORTB, RB2
	    BSF		PORTB, RB3
	    BSF		PORTB, RB4
	    RETURN
	    
    TURN_ON_LEDS:
	    BANKSEL	PORTB
	    BCF		PORTB, RB2
	    BCF		PORTB, RB3
	    BCF		PORTB, RB4
	    RETURN
	    