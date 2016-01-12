/*
 Command Line Mode
 
 Recognizes command line input commands:
 SET LED ON;
 SET LED OFF;
 DELAY;
 PLAY;
 GET SENSOR VALUE;
 
 The circuit:
 * LED connected from digital pin 13 to ground.
 * Piezo speaker connected from digital pin 4 to ground (optional)
 * Potentiometer connected from analog pin 0 to ground (optional)
 
 * Note: On most Arduino boards, there is already an LED on the board
 connected to pin 13, so you don't need any extra components for this example.
  
 Created 19 December 2009
 By Yuriy Shcherbakov
 yshcherbakov@gmail.com
 
 */

#include <Cmd.h>

const int ledPin = 13;      // LED connected to digital pin 1
const int speakerPin = 4;   // Speaker
int sensorPin = 0;          // select the input pin for the potentiometer
int sensorValue = 0;        // variable to store the value coming from the sensor

//Command configuration------------------------------------------------------
  
// Define an output procedure that returns text string response. 
void client_print(char text[]) { 
   Serial.print(text); 
}

// Declare an instance of Cmd here.
Cmd cmd(client_print);

// Keywords definition. The last array element must be "".
const char keywords[][keywordMaxLen] PROGMEM = {"SET", "GET", "LED", "ON", "OFF", "DELAY", "PLAY", "SENSOR", "VALUE", ""};

// Keyword index definition. Assign a numeric index to each keyword above. 
#define kwdSET       1  
#define kwdGET       kwdSET+1
#define kwdLED       kwdGET+1
#define kwdON        kwdLED+1
#define kwdOFF       kwdON+1
#define kwdDELAY     kwdOFF+1
#define kwdPLAY      kwdDELAY+1  
#define kwdSENSOR    kwdPLAY+1
#define kwdVALUE     kwdSENSOR+1

// Specify keywords that are followed by one or more keywords
const prog_uchar processNextKeyword[] PROGMEM = {kwdSET, kwdGET, kwdLED, kwdSENSOR, 0};

// Create multi-word commands. The last array element must be zero.
const prog_uchar cmd_SET_LED_ON[] PROGMEM = {kwdSET, kwdLED, kwdON, 0};
const prog_uchar cmd_SET_LED_OFF[] PROGMEM = {kwdSET, kwdLED, kwdOFF, 0};
const prog_uchar cmd_DELAY[] PROGMEM = {kwdDELAY, 0};
const prog_uchar cmd_PLAY[] PROGMEM = {kwdPLAY, 0};
const prog_uchar cmd_GET_SENSOR_VALUE[] PROGMEM = {kwdGET, kwdSENSOR, kwdVALUE, 0};

// List of supported commands
const prog_uchar *mapCommands[] = {
  cmd_SET_LED_ON, 
  cmd_SET_LED_OFF, 
  cmd_DELAY, 
  cmd_PLAY,
  cmd_GET_SENSOR_VALUE
};

const int mapCommandsSize = 5;  // Size of the array above

// List of supported command procedures. Size of this array must be exactly the same as the aray above.
const CommandProc mapCommandProcs[] = {
  &set_led_on,                   // cmd_SET_LED_ON 
  &set_led_off,                  // cmd_SET_LED_OFF 
  &delay,                        // cmd_DELAY 
  &do_play_melody,               // cmd_PLAY
  &get_analaog_value             // cmd_GET_SENSOR_VALUE
};

// Stub procedure
void nothing() {}

// command procs

void set_led_on()
{
  digitalWrite(ledPin, HIGH);   // set the LED on
}

void set_led_off()
{
  digitalWrite(ledPin, LOW);    // set the LED off
}

void delay() { 
  delay(1000); 
}

void get_analaog_value()
{
  sensorValue = analogRead(sensorPin);    
  Serial.print("sensor = " );
  Serial.println(sensorValue);
}

void playTone(int tone, int duration) {
  for (long i = 0; i < duration * 1000L; i += tone * 2) {
    digitalWrite(speakerPin, HIGH);
    delayMicroseconds(tone);
    digitalWrite(speakerPin, LOW);
    delayMicroseconds(tone);
  }
}

void playNote(char note, int duration) {
  char names[] = { 'c', 'd', 'e', 'f', 'g', 'a', 'b', 'C' };
  int tones[] = { 1915, 1700, 1519, 1432, 1275, 1136, 1014, 956 };
  
  // play the tone corresponding to the note name
  for (int i = 0; i < 8; i++) {
    if (names[i] == note) {
      playTone(tones[i], duration);
    }
  }
}

void play_notes(int length, // the number of notes
                char notes[], // a space represents a rest
                int beats[],
                int tempo )
{
  for (int i = 0; i < length; i++) {
    if (notes[i] == ' ') {
      delay(beats[i] * tempo); // rest
    } else {
      playNote(notes[i], beats[i] * tempo);
    }
    
    // pause between notes
    delay(tempo / 2); 
  }
}

void do_play_melody() {
  int beats[] = { 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 4 };
  play_notes(15, "ccggaagffeeddc ", beats, 100);
}

void setup()
{
  Serial.begin(9600);

  pinMode(ledPin, OUTPUT);
  pinMode(speakerPin, OUTPUT);
}

void loop()
{  

  if(Serial.available()) 
  {
    cmd.addChar((char)Serial.read());
  } 
}

