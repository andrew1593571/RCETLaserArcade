
; PIC16F1788 Configuration Bit Settings

; Assembly source line config statements

; CONFIG1
  CONFIG  FOSC = INTOSC         ; Oscillator Selection (INTOSC oscillator: I/O function on CLKIN pin)
  CONFIG  WDTE = OFF            ; Watchdog Timer Enable (WDT disabled)
  CONFIG  PWRTE = OFF           ; Power-up Timer Enable (PWRT disabled)
  CONFIG  MCLRE = ON            ; MCLR Pin Function Select (MCLR/VPP pin function is MCLR)
  CONFIG  CP = OFF              ; Flash Program Memory Code Protection (Program memory code protection is disabled)
  CONFIG  CPD = OFF             ; Data Memory Code Protection (Data memory code protection is disabled)
  CONFIG  BOREN = OFF           ; Brown-out Reset Enable (Brown-out Reset disabled)
  CONFIG  CLKOUTEN = ON         ; Clock Out Enable (CLKOUT function is enabled on the CLKOUT pin)
  CONFIG  IESO = OFF            ; Internal/External Switchover (Internal/External Switchover mode is disabled)
  CONFIG  FCMEN = OFF           ; Fail-Safe Clock Monitor Enable (Fail-Safe Clock Monitor is disabled)

; CONFIG2
  CONFIG  WRT = OFF             ; Flash Memory Self-Write Protection (Write protection off)
  CONFIG  VCAPEN = OFF          ; Voltage Regulator Capacitor Enable bit (Vcap functionality is disabled on RA6.)
  CONFIG  PLLEN = ON            ; PLL Enable (4x PLL enabled)
  CONFIG  STVREN = OFF          ; Stack Overflow/Underflow Reset Enable (Stack Overflow or Underflow will not cause a Reset)
  CONFIG  BORV = LO             ; Brown-out Reset Voltage Selection (Brown-out Reset Voltage (Vbor), low trip point selected.)
  CONFIG  LPBOR = OFF           ; Low Power Brown-Out Reset Enable Bit (Low power brown-out is disabled)
  CONFIG  DEBUG = OFF           ; In-Circuit Debugger Mode (In-Circuit Debugger disabled, ICSPCLK and ICSPDAT are general purpose I/O pins)
  CONFIG  LVP = OFF             ; Low-Voltage Programming Enable (High-voltage on MCLR/VPP must be used for programming)

// config statements should precede project file includes.
#include <xc.inc>
#include "pic16f1788.inc"
#include "SLAVE_SETUP.inc"
#include "SLAVE_SUBROUTINES.inc"
#include "SendLED.inc"
PSECT resetVect,class=CODE,delta=2
   CALL    Setup
   BSF	   GIE
   GOTO	   MAIN

PSECT isrVect,class=CODE,delta=2
   GOTO    isr_Vect
  
PSECT code
isr_Vect:
  BANKSEL   PIR1
  CLRF	    PIR1
  BANKSEL   PIR2
  CLRF	    PIR2
  BANKSEL   PIR3
  CLRF	    PIR3
  BANKSEL   PIR4
  CLRF	    PIR4
    Retfie
;    BANKSEL	PIR1
;    BTFSC	PIR1,3
;    CALL	RECEIVE
 
MAIN:
    BANKSEL	PORTA
    BTFSS	ACTIVE,0
    CALL	TURN_OFF_LEDS
    BTFSC	ACTIVE,0
    CALL	TURN_ON_LEDS
    GOTO	MAIN
  END