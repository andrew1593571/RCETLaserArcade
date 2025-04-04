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
	    BANKSEL	SSPBUF			;\READ BYTE FROM MASTER
	    MOVFW	SSPBUF			;/
	    BANKSEL	SSPSTAT			;DETERMINE IF THE RECEIVED BYTE WAS DATA OR ADDRESS
	    BTFSS	SSPSTAT,5		;1=DATA, 0=ADDRESS
	    GOTO	CHECK_READ_OR_WRITE	;BYTE RECEIVED WAS ADDRESS, CHECK IF R/W
	    GOTO	SAVE_DATA		;BYTE RECEIVED WAS DATA, SAVE BYTE
	    
    CHECK_READ_OR_WRITE	
	    BTFSS	SSPSTAT,2		;TEST IF ADDRESS BYTE WAS R/W: R = 1, W = 0
	    GOTO	SAVE_DATA		;MASTER WRITE: SAVE DATA OR INDICATE THAT THE SLAVE IS READY TO SAVE THE NEXT BYTE
	    GOTO	TRANSMIT_STATUS		;MASTER READ: TRANSMIT THE TARGET STATUS
	
    SAVE_DATA
	    BANKSEL	PORTA
	    BTFSS	ADDRESS_RECEIVED,0
	    GOTO	SET_ADDRESS_RECEIVED
	    MOVWF	RECEIVED_DATA
	    BSF		NEW_DATA,0
	    BCF		ADDRESS_RECEIVED,0
	    RETURN
	    
    SET_ADDRESS_RECEIVED
	    BSF		ADDRESS_RECEIVED,0
	    RETURN
    
    TRANSMIT_STATUS
	    BANKSEL	SSPCON
	    BCF		SSPCON,4
	    BANKSEL	PORTA
	    BSF		ACTIVE,0
	    BCF		PORTA,0
	    MOVFW	TARGET_STATUS
	    BANKSEL	SSPBUF
	    MOVWF	SSPBUF
	    BANKSEL	SSPCON
	    BSF		SSPCON,4
	    BANKSEL	PORTA
	    BTFSC	TARGET_STATUS,3
	    CALL	DEACTIVATE_TARGET
	    BTFSC	TARGET_STATUS,7
	    CALL	DEACTIVATE_TARGET
	    RETURN
	    
	DEACTIVATE_TARGET
	    CLRF	ACTIVE
	    MOVLW	0xFF
	    MOVWF	PORTA
	    CLRF	TARGET_STATUS
	    RETURN
	    
    RECORD_PLAYER1_HIT
	    BANKSEL	PORTA
	    BSF		PORTA,0
	    BCF		PORTA,1
	    BSF		PORTA,2
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTA,1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BCF		PORTA,1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTA,1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BCF		PORTA,1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    CALL	WAIT_FOR_TMR1
	    BSF		PORTA,1
	    BCF		ACTIVE,0
	    MOVLW	0x0F
	    MOVWF	TARGET_STATUS
	    GOTO	GOBACK
	    
	    
    RECORD_PLAYER2_HIT
	    BANKSEL	PORTA
	    BSF		PORTA,0
	    BSF		PORTA,1
	    BSF		PORTA,2
	    
	    BCF		ACTIVE,0
	    MOVLW	0xF0
	    MOVWF	TARGET_STATUS
	    GOTO	GOBACK
	    
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