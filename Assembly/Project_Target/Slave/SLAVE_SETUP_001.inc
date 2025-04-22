;************************************************************************************
;										    *
;   Filename:	    16LF1788_SETUP.inc						    *
;   Date:	    November 5, 2024						    *
;   File Version:   1								    *
;   Author:	    Alex Wheelock						    *
;   Company:	    Idaho State University					    *
;   Description:    Firmware for setting up a PIC16LF1788 for the laser gun of the  *
;		    Laser Shooting Game project.				    *
;										    *
;************************************************************************************

;************************************************************************************
;										    *
;   Revision History:								    *
;										    *
;   1:	Iniitialize file, setup how I think it should be setup for the project.	    *
;										    *
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
;		|		|		|		|		|		|		|		*
;		|		|		|		|		|		|		|		*		
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
		
INITIALIZE_CODE	CODE		
INITIALIZE	
	
;*** INTOSC SETUP *******
	
		BANKSEL	    OSCCON
		MOVLW	    0x7A			;ENABLE INTOSC, SET TO 16MHz
		MOVWF	    OSCCON
		BANKSEL	    CLKRCON
		CLRF	    CLKRCON			;DISABLE CLOCK REFERENCE
	
		
;*** SFR SETUP **********
 
		
;*** SET OPTION_REG: ****
		
		BANKSEL	    OPTION_REG
		BCF	    OPTION_REG, PS0		;\\
		BCF	    OPTION_REG, PS1		; >>PRESCALER RATIO SET 1:1
		BCF	    OPTION_REG, PS2		;//
		BSF	    OPTION_REG, PSA		;PRESCALER ASSIGNED TO WDT 
		BCF	    OPTION_REG, TMR0SE		;TMR0 EDGE SET RISING
		BCF	    OPTION_REG, TMR0CS		;TMR0 CLOCK SOURCE SET TO INTERNAL
		BSF	    OPTION_REG, INTEDG		;RB0/INT SET TO RISING EDGE
		BSF	    OPTION_REG, NOT_WPUEN	;WEAK PULLUP ENABLED
		
;*** SET INTCON REG: ****
		
		BANKSEL INTCON
		BSF	    INTCON, IOCIE		;ENABLE IOC INTERUPT
		BCF	    INTCON, INTE		;DISABLE INT EXTERNAL INTERUPT
		BSF	    INTCON, PEIE		;ENABLE PERIPHERAL INTERUPTS
		BSF	    INTCON, GIE			;ENABLE ALL UNMASKED INTERUPTS
		
;*** SET PIE1-4 REG: *****
		
		BANKSEL	    PIE1
		MOVLW	    0x08
		MOVWF	    PIE1			;DISABLE ALL PIE1 INTERUPTS, EXCEPT SSP1F
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
		CLRF	    APFCON1			;SELECTS PORT MAPPING
		CLRF	    APFCON2			;SEE DATASHEET (pg 132-133) FOR MAPPING WITH BOTH CLEARED
		
;*** TMR1 SETUP ****
		
		BANKSEL	    T1CON
		MOVLW	    0xA8			;ENABLE & SELECT TMR1 LP OSCILLATOR, SET PRESCALE TO 1:4, DISABLE TMR1 AT THIS POINT
		BANKSEL	    T1GCON
		CLRF	    T1GCON			;DISABLE TMR1 GATE
 
;*** PORT A SETUP **** PORT A SET AS LOGIC INPUT (I2C ADDRESS)

		BANKSEL	    PORTA
		MOVLW	    0xFF
		MOVWF	    PORTA			;CLEAR PORTA
		BANKSEL	    LATA
		MOVLW	    0xFF			;CLEAR LATA
		MOVWF	    LATA
		BANKSEL	    TRISA
		MOVLW	    0xFF  
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
		MOVLW	    B'00011100'
		MOVWF	    PORTB			;CLEAR PORTB	
		BANKSEL	    LATB
		CLRF	    LATB			;CLEAR LATB
		BANKSEL	    TRISB
		MOVLW	    B'00000011'				
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
		MOVLW	    0x03			;ENABLE PORTB IOC FOR NEGATIVE EDGES ON RB0 AND RB1
		MOVWF	    IOCBN
		BANKSEL	    INLVLB
		CLRF	    INLVLB			;SET PORTB INPUT THRESHOLD TO TTL (IGNORED NOISE BETTER FOR TRIGGER INPUT)	    	    
		
;*** PORT C SETUP **** 
		
		BANKSEL	    PORTC
		CLRF	    PORTC			;CLEAR PORTC
		BANKSEL	    LATC
		CLRF	    LATC			;CLEAR LATC
		BANKSEL	    TRISC
		MOVLW	    0xFF				
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
		MOVFW	    PORTA
		ANDLW	    B'11111110'			;IGNORE RA0 VALUE
		BANKSEL	    SSPADD		
		MOVWF	    SSPADD			;SET I2C ADDRESS ACCORDING TO SWITCHES
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
		
;*** BOOT CODE ****
		
		BANKSEL	    PORTA
		CLRF	    TARGET_STATUS
		CLRF	    ACTIVE
		BANKSEL	    INTCON
		BCF	    INTCON,0
		BANKSEL	    IOCAF
		CLRF	    IOCAF
		BCF	    INTCON,IOCIF		;CLEAR IOCIF
		BANKSEL	    PORTA
		CLRF	    ACTIVE
		CLRF	    TARGET_STATUS
		
		
		RETURN					;RETURN TO .asm FILE