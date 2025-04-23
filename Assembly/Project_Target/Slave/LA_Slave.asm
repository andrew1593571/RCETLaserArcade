;************************************************************************************
;										    *
;   Filename:	    LA_Slave.asm						    *
;   Date:	    April 23, 2025						    *
;   File Version:   2								    *
;   Author:	    Alex Wheelock and Andrew Keller				    *
;   Company:	    Idaho State University					    *
;   Description:    Assembly file for the target slave for a laser shooting arcade. *
;		    Communicates with the Master via I2C. May be enabled or	    *
;		    disabled using I2C commands. When an I2C read is executed, the  *
;		    slave responds with the current status of the target. The I2C   *
;		    address is set during PIC setup utilizing switches connected    *
;		    to PORTA.							    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	  Got everything for the gun working the way that I think it should with    *
;	  base features.							    *
;										    *
;   2:	  I2C communications for enabling/disabling the target as well as reporting *
;          any player hits to the target when the target is enabled.		    *
;										    *
;************************************************************************************
		
		#include "SLAVE.inc"      		; processor specific variable definitions
		#INCLUDE <SLAVE_SETUP.inc>		; Custom setup file for the PIC16F883 micro-controller
		#INCLUDE <SLAVE_SUBROUTINES.inc>	; File containing all used subroutines
		LIST      p=16f1788		  	; list directive to define processor
		errorlevel -302,-207,-305,-206,-203	; suppress "not in bank 0" message,  Found label after column 1,
							; Using default destination of 1 (file),  Found call to macro in column 1

		; CONFIG1
; __config 0xC9A4
 __CONFIG _CONFIG1, _FOSC_INTOSC & _WDTE_OFF & _PWRTE_OFF & _MCLRE_OFF & _CP_OFF & _CPD_OFF & _BOREN_OFF & _CLKOUTEN_OFF & _IESO_OFF & _FCMEN_OFF
; CONFIG2
; __config 0xDFFF
 __CONFIG _CONFIG2, _WRT_OFF & _PLLEN_OFF & _STVREN_ON & _BORV_LO & _LPBOR_OFF & _LVP_OFF


		
;******************************************		
;Interrupt Vectors
;******************************************
		ORG	    H'000'			;BEGINNING OF CODE
		GOTO	    SETUP			;
		ORG	    H'004'			;INTERRUPT LOCATION
		GOTO	    INTERRUPT			;INTERRUPT OCCURRED, RUN THROUGH ISR

;******************************************
;SETUP ROUTINE
;******************************************
SETUP
		CALL	    INITIALIZE			;CALL SETUP INCLUDE FILE TO INITIALIZE PIC
		GOTO	    MAIN			;START MAIN CODE
		
;******************************************
;INTERRUPT SERVICE ROUTINE
;******************************************
INTERRUPT
		BANKSEL	    PIR1
		BTFSC	    PIR1,3			;CHECK SSPIF FLAG TO SEE IF DATA WAS RECIEVED FROM MASTER
		CALL	    RECEIVE			;CALL THE RECEIVE SUBROUTINE IF DATA WAS RECEIVED
		BANKSEL	    PORTA
		BANKSEL	    IOCBF
		BTFSC	    IOCBF,1			;IF THE PLAYER 2 IR RECEIVER IS TRIGGERED (FALLING EDGE INTERRUPT ON CHANGE)
		GOTO	    RECORD_PLAYER2_HIT		;CALL RECORD_PLAYER2_HIT SUBROUTINE
		BTFSC	    IOCBF,0			;IF THE PLAYER 1 IR RECEIVER IS TRIGGERED (FALLING EDGE INTERRUPT ON CHANGE)
		GOTO	    RECORD_PLAYER1_HIT		;CALL RECORD_PLAYER1_HIT SUBROUTINE
	GOBACK
		BANKSEL	    PIR1			;NOTE: GOBACK ONLY USED IN I2C INTERRUPTS. IF USED FOR IOCBF, MISSES I2C REQUESTS AND MASTER CRASHES
		BCF	    PIR1,3			;CLEAR SSP1IF
		RETFIE					;RETURN TO MAIN, RE-ENABLE GIE
;Main Code
;******************************************
		
MAIN	
		BANKSEL	    PORTA
		BTFSS	    ACTIVE, 0			;IF THE TARGET IS NOT ACTIVE, TURN OFF THE LEDS
		CALL	    TURN_OFF_LEDS
		BTFSC	    ACTIVE, 0			;IF THE TARGET IS ACTIVE, TURN ON THE LEDS
		CALL	    TURN_ON_LEDS		
		GOTO	    MAIN			
END
		
;******************************************		
;END PROGRAM DIRECTIVE
;******************************************