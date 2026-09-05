/*
   Filename:        main.c                                                          
   Date:            November 18, 2025                                                    
   File Version:    1                                                               
   Author:          Andrew Keller                                                       
   Company:         Idaho State University					    
   Description:     Laser Arcade Blaster main source code
*/

// PIC16LF1788 Configuration Bit Settings
// 'C' source line config statements
// CONFIG1
#pragma config FOSC = INTOSC    // Oscillator Selection (INTOSC oscillator: I/O function on CLKIN pin)
#pragma config WDTE = OFF       // Watchdog Timer Enable (WDT disabled)
#pragma config PWRTE = OFF      // Power-up Timer Enable (PWRT disabled)
#pragma config MCLRE = ON       // MCLR Pin Function Select (MCLR/VPP pin function is MCLR)
#pragma config CP = OFF         // Flash Program Memory Code Protection (Program memory code protection is disabled)
#pragma config CPD = OFF        // Data Memory Code Protection (Data memory code protection is disabled)
#pragma config BOREN = OFF      // Brown-out Reset Enable (Brown-out Reset disabled)
#pragma config CLKOUTEN = OFF   // Clock Out Enable (CLKOUT function is disabled. I/O or oscillator function on the CLKOUT pin)
#pragma config IESO = OFF       // Internal/External Switchover (Internal/External Switchover mode is disabled)
#pragma config FCMEN = OFF      // Fail-Safe Clock Monitor Enable (Fail-Safe Clock Monitor is disabled)
// CONFIG2
#pragma config WRT = OFF        // Flash Memory Self-Write Protection (Write protection off)
#pragma config PLLEN = OFF       // PLL Enable (4x PLL enabled)
#pragma config STVREN = OFF     // Stack Overflow/Underflow Reset Enable (Stack Overflow or Underflow will not cause a Reset)
#pragma config BORV = LO        // Brown-out Reset Voltage Selection (Brown-out Reset Voltage (Vbor), low trip point selected.)
#pragma config LPBOR = OFF      // Low Power Brown-Out Reset Enable Bit (Low power brown-out is disabled)
#pragma config LVP = OFF        // Low-Voltage Programming Enable (High-voltage on MCLR/VPP must be used for programming)

//Include Statements
#include <xc.h>
#include "BlasterSetup.h"
#include "BlasterSubroutines.h"

//General Register Declarations
volatile unsigned char PlayerNumber __at(RAMPlayerNumber);
volatile unsigned char PlayerRed __at(RAMPlayerRed);
volatile unsigned char PlayerGreen __at(RAMPlayerGreen);
volatile unsigned char PlayerBlue __at(RAMPlayerBlue);
volatile unsigned char Mode __at(RAMMode);
/*MODE Types
 * 1 = Single Fire
 * 2 = three round burst
 * 3 = full auto
 */

void __interrupt() ISR(void){
    //if Interrupt on Change
    if(INTCONbits.IOCIF == 1){
        if(TriggerButtonFlag == 1){ //if trigger was released
            if (Mode == 1){ //single fire mode
                SingleFireBlaster(PlayerNumber); //fire the blaster
            }
            
            if (Mode == 2){ //three round burst mode
                PORTA = 0b01111101; //enable speaker, trigger audio TRIG1
                FireBlaster(PlayerNumber); //fire the blaster
                FireBlaster(PlayerNumber); //fire the blaster
                FireBlaster(PlayerNumber); //fire the blaster
                PORTA = 0b00111111; //disable everything
            }
            
            if (Mode == 3){ //full auto fire mode
                PORTA = 0b01111101; //enable speaker, trigger audio TRIG1
                while (TriggerButton == 0){
                    FireBlaster(PlayerNumber); //fire the blaster
                }
                PORTA = 0b00111111; //disable everything
            }
            
            TriggerButtonFlag = 0; //clear interrupt flag
        }
        
        if(SingleButtonFlag == 1){ //if single mode button was pressed
            //change to single fire mode, turn on Green LED
            Mode = 1;
            ModeBlue = 1;
            ModeRed = 1;
            ModeGreen = 0;
            SingleButtonFlag = 0; //clear interrupt flag
        }
        
        if(BurstButtonFlag == 1){ //if burst mode button was pressed
            //change to three round burst mode, turn on Blue LED
            Mode = 2;
            ModeBlue = 0;
            ModeRed = 1;
            ModeGreen = 1;
            BurstButtonFlag = 0; //clear interrupt flag
        }
        
        if(AutoButtonFlag == 1){ //if auto mode button was pressed
            //change to three round burst mode, turn on Blue LED
            Mode = 3;
            ModeBlue = 1;
            ModeRed = 0;
            ModeGreen = 1;
            AutoButtonFlag = 0; //clear interrupt flag
        }
        
        INTCONbits.IOCIF = 0; //clear Interrupt on change flag
    }
    
    if(PIR1bits.RCIF == 1){ //UART byte received
        if(RCREG == 0x24){ //handshake byte received, do something            
            while (PIR1bits.RCIF == 0){} //wait for next RX
            
            if(RCREG == 0x56){ //device verification command received
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x24; //send ASCII $
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x4c; //send ASCII L
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x41; //send ASCII A
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x42; //send ASCII B
                
            } else if(RCREG == 0x53) { //read settings command received
                //load saved values from EEPROM
                PlayerNumber = LoadFromEEPROM(EEPROMPlayerNumber);
                PlayerRed = LoadFromEEPROM(EEPROMPlayerRed);
                PlayerGreen = LoadFromEEPROM(EEPROMPlayerGreen);
                PlayerBlue = LoadFromEEPROM (EEPROMPlayerBlue);
                
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x24; //send ASCII $
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = PlayerNumber; //send saved player number
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = PlayerGreen; //send saved green value
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = PlayerRed; //send saved red value
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = PlayerBlue; //send saved blue value
                
                
            } else if(RCREG == 0x43) { //update player color and number command received
                while (PIR1bits.RCIF == 0){} //wait for next RX
                PlayerNumber = RCREG; //received byte is player number
                while (PIR1bits.RCIF == 0){} //wait for next RX
                PlayerGreen = RCREG; //received byte is player Green
                while (PIR1bits.RCIF == 0){} //wait for next RX
                PlayerRed = RCREG; //received byte is player Red
                while (PIR1bits.RCIF == 0){} //wait for next RX
                PlayerBlue = RCREG; //received byte is player Blue
                
                //save received values to EEPROM
                SaveToEEPROM(EEPROMPlayerNumber, PlayerNumber);
                SaveToEEPROM(EEPROMPlayerGreen, PlayerGreen);
                SaveToEEPROM(EEPROMPlayerRed, PlayerRed);
                SaveToEEPROM(EEPROMPlayerBlue, PlayerBlue);
                
                //respond with an acknowledge
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x24; //send ASCII $
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x41; //send ASCII A
                
            } else { //unknown command received, respond unable
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x24; //send ASCII $
                while (TXSTAbits.TRMT == 0){} //wait for TX to be available
                TXREG = 0x55; //send ASCII U
            }
        }
        
    }
    
    //INTCONbits.GIE = 1; enable global interrupts
}

void main(void){
    //Setup the Blaster PIC
    Setup_ConfigureOscillator();
    Setup_ConfigureOptions();
    Setup_ConfigurePinFunctions();
    Setup_ConfigurePortA();
    Setup_ConfigurePortB();
    Setup_ConfigurePortC();
    Setup_ConfigureLasers();
        
    //load saved values from EEPROM
    PlayerNumber = LoadFromEEPROM(EEPROMPlayerNumber);
    PlayerRed = LoadFromEEPROM(EEPROMPlayerRed);
    PlayerGreen = LoadFromEEPROM(EEPROMPlayerGreen);
    PlayerBlue = LoadFromEEPROM (EEPROMPlayerBlue);
    
    //Configure Audio and Play Startup
    Setup_ConfigureAudio(PlayerNumber);
    
    //start in single fire mode
    Mode = 1;
    ModeBlue = 1; //turn off blue LED
    ModeRed = 1; //turn off red LED
    ModeGreen = 0; //turn on green LED
    
    Setup_ConfigureInterrupts();
    ConfigurePlayerLED(PlayerRed, PlayerGreen, PlayerBlue); //set the player color LED
    
    //sit and do nothing
    while(1==1){
    }
    
    return;
}
