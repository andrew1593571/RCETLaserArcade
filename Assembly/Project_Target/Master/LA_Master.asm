;************************************************************************************
;										    *
;   Filename:	    LA_Master.asm						    *
;   Date:	    April 22, 2025						    *
;   File Version:   2								    *
;   Author:	    Alex Wheelock and Andrew Keller				    *
;   Company:	    Idaho State University					    *
;   Description:    Assembly file for the master controller for a laser shooting    *
;		    arcade. Includes the ability to communicate with a computer	    *
;		    via UART. Can control up to 8 targets simultaneously with	    *
;		    various target slots. Each slot can be changed to a different   *
;		    I2C address using UART commands.				    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	  Got everything for the gun working the way that I think it should with    *
;	  base features.							    *
;										    *
;   2:	  Added UART functionality, I2C capability to control up to 8 targets	    *
;										    *	
;************************************************************************************		
		
		#include "MASTER.inc"      		; processor specific variable definitions
		#INCLUDE <MASTER_SETUP.inc>		; Custom setup file for the PIC16F883 micro-controller
		#INCLUDE <MASTER_SUBROUTINES.inc>	; File containing all used subroutines

		LIST      p=16f1788		  	; list directive to define processor
		errorlevel -302,-207,-305,-206,-203	; suppress "not in bank 0" message,  Found label after column 1,
							; Using default destination of 1 (file),  Found call to macro in column 1

		; CONFIG1
; __config 0xC9A4
 __CONFIG _CONFIG1, _FOSC_INTOSC & _WDTE_OFF & _PWRTE_OFF & _MCLRE_ON & _CP_OFF & _CPD_OFF & _BOREN_OFF & _CLKOUTEN_OFF & _IESO_OFF & _FCMEN_OFF
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
		BTFSC	    PIR1, RCIF			;IF INTERRUPTED BY UART RECEIVE, GOTO UARTRECEIVE
		GOTO	    UARTRECEIVE
		BTFSC	    PIR1, TXIF			;IF INTERRUPTED BY UART TRANSMIT, GOTO UARTTRANSMIT
		GOTO	    UARTTRANSMIT
		GOTO	    GOBACK			;ELSE GOBACK
	UARTRECEIVE
		CALL	    UARTRX			;CALL THE UARTRX SUBROUTINE
		GOTO	    GOBACK
	UARTTRANSMIT
		CALL	    UARTTX			;CALL THE UARTTX SUBROUTINE
		GOTO	    GOBACK
	GOBACK
		BANKSEL	    PIR1
		CLRF	    PIR1			;CLEAR ALL PIR1 FLAGS
		RETFIE					;RETURN TO MAIN, RE-ENABLE GIE
		
;******************************************
;Main Code
;******************************************
MAIN	
		CALL	    UPDATETARGETONE		;UPDATE EACH TARGET INDIVIDUALLY
		CALL	    UPDATETARGETTWO
		GOTO	    MAIN		
END
		
;******************************************		
;END PROGRAM DIRECTIVE
;******************************************