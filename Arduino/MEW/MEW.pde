/*

 MultiPurpose Enduring Watercraft
 
 
 -Ahmed Mujtaba [08 ES 22]
 http://mujtabachang.com
 Email: mujtabachang@gmail.com
 
 */
#define VERSION "ALPHA0.3"

//Included Libraries


// AVR runtime
#include <avr/io.h>
#include <avr/eeprom.h>
#include <avr/pgmspace.h>
#include <math.h>

//**********************


//**********************

// Other Libraries


#include <Streaming.h>
#include <SerialCommand.h>
#include <Wire.h>
#include <GPS_NMEA.h>           // NMEA GPS Library
#include <SimpleTimer.h>
#include "Configuration.h"



//Functions
void (*softReset) (void) = 0;                                           //Declare reset function @ address 0 (can be called using softReset(); )

#define ToRad(x) (x*0.01745329252)  // *pi/180
#define ToDeg(x) (x*57.2957795131)  // *180/pi

//Variables
float speed;
float altitude;
float course;

boolean homefixed=0;

int mymode = 0;                                                         // 0 = Manual Mode
// 1 = Auto Mode
// 2 = Hold Position Mode
// 3 = Return to Home Mode



SerialCommand SCmd;                                                     // The SerialCommand object

SimpleTimer timer;                                                      // Timer Object

//Waypoints
// --------------

struct Location2 {
  float lat;
  float lng;
};

float target_heading= 0;
float target_distance =0;

int wptotal=0;
int wpcurrent=0;
int wp_command[MAXWAYPOINTS];
int wp_last[MAXWAYPOINTS];
int wp_waittime[MAXWAYPOINTS];
String wp_name[MAXWAYPOINTS];

struct Location2 wps[MAXWAYPOINTS];


struct Location2 home                            = {
  0,0};              // Home Location
struct Location2 prev_WP                         = {
  0,0};              // Last Waypoint
struct Location2 current_loc                     = {
  0,0};              // Current Location
struct Location2 current_WP                      = {
  0,0};              // Next Waypoint
struct Location2 hold_pos                        = {
  0,0};              // Hold Position

// Sensor Variables
int sensor[15];                        //sensor[1]  = Hull Temperature Sensor
//sensor[2]  = Water Temperature Sensor


float HullTemp;
float WaterTemp;
float BatteryVolt;
float SolarVolt;
float DayNightSensor;

boolean PowerSavingMode=0;
boolean ManualMotorOffTimer=0;

long previousMillis = 0;
unsigned long currentMillis=0;

int TelemetryTimerID;

void setup()
{
  initMEW();
}


void loop()
{
  timer.run();
  fast_loop();
  processSerial();                                                      //Serial Commands
}


void doSomething()
{

  digitalWrite (13,!digitalRead(13));
}

void initMEW()
{
  pinMode(LED1Pin, OUTPUT);
  pinMode(LED2Pin, OUTPUT);

  pinMode(MOTORLPIN, OUTPUT);
  pinMode(MOTORRPIN, OUTPUT);

  digitalWrite (MOTORLPIN, LOW);
  digitalWrite (MOTORRPIN, LOW);

  setcurrentWp(0);
  clearwps();
  randomSeed(analogRead(0));                                            //Randomize 
  Serial.begin(SDATARATE);                                              //Main Serial (Console)  
  Serial3.begin (XBEEDATARATE);                                         //Xbee Data Rate

  timer.setInterval(1000, one_second_loop);
  timer.setInterval(500, half_second_loop);

  initBlinky();

  TelemetryTimerID=timer.setInterval(TelemetrySendRate, TelemetrySendLoop);

  initGPS();  
  initCompass();
  initCommands();
}

void processSerial()
{
  SCmd.readSerial();                                                    // Just process serial commands
}
void fast_loop()
{
  PowerManagement();
  readSensors();
  processInput();
  getGPS();
  readCompass(); 
  navigate();

}
void half_second_loop()
{
  doSomething();

}
void one_second_loop()
{

}

void TelemetrySendLoop()
{
  if (SENDTELEMETRY ==0) { 
    return; 
  }
  SendTelemetry();
}





