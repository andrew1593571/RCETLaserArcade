;************************************************************************************
;										    *
;   Filename:	    LA_BLASTER.asm						    *
;   Date:	    November 5, 2024						    *
;   File Version:   2								    *
;   Author:	    Alex Wheelock						    *
;   Company:	    Idaho State University					    *
;										    *
;   Description:    Assembly file for Laser Arcade blaster. A gun that can fire     *
;		    a laser at two frequencies (38kHz & 56kHz), with firing mode    *
;		    select (single-shot, three round burst, continuous). Different  *
;		    frequencies will be used to determine between player 1 (38kHz)  *
;		    and 2 (56kHz) for scoring.					    *
;										    *
;		    Uses CCP1 (RC2) for laser PWM, RC3 for solenoid control. RB0 for*
;		    trigger, RB1 for frequency select and RB4:2 used to select from *
;		    the firing modes. PORTA is used for trigger pins on the audio   *
;		    board, as are RC6, & RC1:0. RC7 continuously toggles in main to *
;		    ensure that the volume on the audio board is maxed out.	    *
;										    *		
;		    The PWM output driver is enabled when the gun is fire, and	    *
;		    disabled when not, or when cycling between "rounds/shots".	    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	  (NOV 2024) Got everything for the gun working the way that I think it     *
;	  should with base features.						    *
;										    *		
;   2:	  (APRIL 3, 2025) Added an audio board, and connected all of PORTA, and	    *
;	  RC7,6,1, & 0 as triggers for the audio board, only RA0 & RA1 are being    *
;	  used as triggers currently, RC7 toggles in MAIN to ensure the volume is   *
;	  maxed out.								    *
;										    *
;	  Code was also updated to work properly with the fire select switch that   *
;	  will be used in the final product.					    *
;										    *	
;************************************************************************************		
		
		#include "BLASTER.inc"      		; processor specific variable definitions
		#INCLUDE <BLASTER_SETUP.inc>		; Custom setup file for the PIC16F883 micro-controller
		#INCLUDE <BLASTER_SUBROUTINES.inc>		; File containing all used subroutines
		LIST      p=16f1788		  	; list directive to define processor
		errorlevel -302,-207,-305,-206,-203	; suppress "not in bank 0" message,  Found label after column 1,
							; Using default destination of 1 (file),  Found call to macro in column 1

		; CONFIG1
; __config 0xC9A4
 __CONFIG _CONFIG1, _FOSC_INTOSC & _WDTE_OFF & _PWRTE_OFF & _MCLRE_OFF & _CP_OFF & _CPD_OFF & _BOREN_OFF & _CLKOUTEN_OFF & _IESO_OFF & _FCMEN_OFF
; CONFIG2
; __config 0xDFFF
 __CONFIG _CONFIG2, _WRT_OFF & _PLLEN_ON & _STVREN_ON & _BORV_LO & _LPBOR_OFF & _LVP_OFF


		
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
		BANKSEL	    PORTB		
		BTFSC	    PORTB,1			;TEST FREQUENCY SELECT SWITCH
		GOTO	    SET_56KHZ			;RB1 IS HIGH, SET PWM FREQUENCY TO 56kHz
		GOTO	    SET_38KHZ			;RB1 IS LOW, SET PWM FREQUENCY TO 38kHz
		
	TEST_MODE	
		BANKSEL	    PORTB		
		BTFSC	    PORTB,2			;DETERMINE IF IN CONTINUOUS/FULL-AUTO MODE
		GOTO	    FIRE_CONTINUOUS		;GUN IS IN CONTINOUS/FULL-AUTO MODE, CHECK IF READY TO FIRE
		BTFSC	    PORTB,3			;GUN IS NOT IN CONTINUOUS/FULL-AUTO MODE, TEST IF IT IS IN BURST-FIRE MODE
		GOTO	    FIRE_BURST			;GUN IS IN BURST-FIRE MODE, CHECK IF READY TO FIRE
		BTFSC	    PORTB,4			;GUN IS IN NEITHER FULL-AUTO OR BURST-FIRE MODES, DETERMINE IF IT IS IN SEMI-AUTO MODE
		GOTO	    FIRE_SEMI			;GUN IS NOT IN CONTINUOUS OR BURST-FIRE MODE, DEFAULT TO SEMI-AUTO MODE, TEST IF READY TO FIRE
	GOBACK
		BANKSEL	    IOCBF
		CLRF	    IOCBF			;CLEAR PORTB IOC FLAGS
		BCF	    INTCON,IOCIF		;CLEAR IOCIF
		BANKSEL	    PIR1
		BCF	    PIR1,0			;CLEAR TMR1IF
		RETFIE					;RETURN TO MAIN, RE-ENABLE GIE
		
;******************************************
;Main Code
;******************************************
MAIN							;CONSTANTLY PULSE THE VOL+ WHILE IN MAIN TO ENSURE THE VOLUME IS MAXED OUT
		BANKSEL	    PORTC
		BTFSC	    PORTC,7			;DETERMINE IF THE VOL+ OUTPUT IS HIGH OR LOW
		GOTO	    _CLEAR			;OUTPUT IS HIGH
	_SET						;OUTPUT IS LOW
		BSF	    PORTC,7			;OUTPUT IS LOW, SET VOL+
		GOTO	    WAIT
	_CLEAR
		BCF	    PORTC,7			;OUTPUT IS HIGH, CLEAR VOL+
	WAIT						;\
		MOVLW	    0x7F			;\\
		MOVWF	    VOLUME_COUNT		;\\\
	    VOLUME_LOOP1				;\\\\
		CLRF	    VOLUME_COUNT2		;\\\\\ GIVE A DELAY ON THE PW/PS TO ENSURE THAT THE AUDIO BOARD HAS TIME
	    VOLUME_LOOP2				;///// TO TRIGGER OFF OF IT, BECAUSE IT IS VERY SLOW.
		DECFSZ	    VOLUME_COUNT2		;////
		GOTO	    VOLUME_LOOP2		;///
		DECFSZ	    VOLUME_COUNT		;//
		GOTO	    VOLUME_LOOP1		;/
		GOTO	    MAIN		
END
		
;******************************************		
;END PROGRAM DIRECTIVE
;******************************************