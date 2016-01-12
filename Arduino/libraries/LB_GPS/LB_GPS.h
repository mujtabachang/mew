/*
 * LB_GPS.h - Communicating through the GPS port for Arduino
 * Copyright (c) 2009 Libelium Comunicaciones Distribuidas 
 * http://libelium.com
 *
 * Coded by D. Cuartielles aka BlushingBoy 
 * http://blushingboy.net
 *
 * Please read the README.txt file coming with this library for
 * any known issues, release notes, etc.
 *
 * Running on:
 * - Modified Software serial library
 *   Copyright (c) 2006 David A. Mellis.
 * 
 * - Modified code for string parsing from the TinyGPS library
 *   Copyright (C) 2008-9 Mikal Hart
 *
 * LICENSE
 *
 *  Copyright (C) 2009 Libelium Comunicaciones Distribuidas S.L.
 *  http://www.libelium.com
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 */

/******************************************************************************
 * Includes
 ******************************************************************************/

#include <stdio.h>
#include "WProgram.h"
#ifndef Wiring_h
  #include "wiring.h"
#endif

/******************************************************************************
 * Definitions & Declarations
 ******************************************************************************/

// the library flag
#ifndef LB_GPS_h
#define LB_GPS_h

// version control
#define VERSION "LB_GPS 01a, (c) 2009 Cuartielles for Libelium.com\n"

// Serial communication types
#define SOFTWARE 0      // select software serial port
#define HARDWARE 1	// the serial port by default both on Arduino USB and Mega
#define HW_0 1		// the serial port #0 in Mega (default)
#define HW_1 2		// the serial port #1 in Mega
#define HW_2 3		// the serial port #2 in Mega
#define HW_3 4		// the serial port #3 in Mega

// GPS power saving modes
#define GPS_ON 0
#define GPS_OFF 1
#define GPS_SLEEP 2
#define GPS_HIBERNATE 3

// GPS waking up modes
#define HOT 0 	// (default)
#define WARM 1
#define COLD 2

// GPS sentence types
#define GPGGA 1		// 3D location and accuracy data 
#define GPGSA 4		// DOP and active satellites
#define GPGSV 8		// satellites that the unit might be able to find
#define GPVTG 16	// Velocity made good, both in knots and Km/h
#define GPRMC 64	// essential gps pvt (position, velocity, time) data

// GPS Software Serial pins
#define GPS_RX 18	// default RX pin for the software serial method
#define GPS_TX 19	// default TX pin for the software serial method

// buffer sizes
#define MAX_ARG_LENGTH 10    // maximum length for an argument delivered by GPSExplode
#define GPS_BUFFER_SIZE 128  // size for the internal inBuffer

//#include <inttypes.h>

/******************************************************************************
 * Class
 ******************************************************************************/

class LB_GPS
{
  private:
    // variables, GPS related
    bool fixValid;      // determines whether the last reading was valid or not

    // SoftwareSerial port related
    uint8_t _receivePin;
    uint8_t _transmitPin;
    long _baudRate;
    int _bitPeriod;
    void printNumber(unsigned long, uint8_t);
    
    // string manipulation
    int size_of(const char*);
    long parse_decimal(char *str);
    unsigned long parse_degrees(char *str);
    long gpsatol(char *str);
    bool gpsisdigit(char c) { return c >= '0' && c <= '9'; }

    // GPS internal 
    void configureGPS(void);
    
  public:
    // variables, GPS related
    char inBuffer[GPS_BUFFER_SIZE];	// buffer where to store data coming in
    char arguments[13][11];  // array of arguments in every GPS raw string
    uint8_t commMode;	// communication mode: software or hardware serial
    uint8_t pwrMode;	// power mode for the GPS
    uint8_t wakeMode;   // waking up mode
    uint8_t sentences;	// variable containing the sentences to be used
    char* timeGPS;	// time on the GPS as a string
    char* dateGPS;	// date on the GPS as a string
    char* coordinates;	// coordinates as a string
    float latitude;	// latitude according to last measurement
    float longitude;	// longitude according to last measurement
    float speed;	// speed according to last measurement
    float altitude;	// altitude according to last measurement
    float course;	// course (angle) according to last measurement
    LB_GPS();		// object containing the whole GPS information

    //GPS related functions
    void init(void);		// init the GPS using the default coordinates, date and time
    void init(const char*, const char*, const char*);	// init the GPS using your own coordinates, date and time
    void setCommMode(uint8_t);	// define if you will use the software or hardware serial port
    uint8_t getCommMode(void);  // get the type of port in use
    void setGPSMode(uint8_t);	// define the power mode for the device
    char* getTime(void);	// get the device's time
    void setTime(char*);	// define the time
    char* getDate(void);        // get the device's date
    void setDate(char*);	// define the date
    uint8_t getGPSMode(void);	// get the device's power mode
    void getLocation(void);	// gets the current location and stores it in the corresponding variables
    float getLatitude(void);	// forces getLocation and responds the current value of the latitude variable
    float getLongitude(void);	// forces getLocation and responds the current value of the longitude variable
    float getSpeed(void);	// forces getLocation and responds the current value of the speed variable
    float getAltitude(void);	// forces getLocation and responds the current value of the altitude variable
    char* getRaw(int);		// print XX bytes from the current NMEA sentences sent by the GPS to the serial port
    void setSentences(int);	// set the NMEA sentences we want to get from the GPS
    uint8_t getSentences();     // get the NMEA sentences we are currently getting from the GPS
    bool dataValid(void) {return fixValid;};  // answers if the last reading of data was valid
    void GPSStringExplode(const char*, char);

    // general functions
    const char* getLibVersion(void) {return VERSION;};  // get the library's version

    // Serial port related functions
    // these functions can be used both from the hardware serial port or from the
    // hardware one, it is just a matter of defining the serial port mode
    void begin(void);	// start the communication at a predetermined speed of 4800bps
    void begin(long);	// start the communication at the speed given as parameter
    int read();		// read a byte from the GPS
    void print(char);
    void print(const char[]);
    void print(uint8_t);
    void print(int);
    void print(unsigned int);
    void print(long);
    void print(unsigned long);
    void print(long, int);
    void println(void);
    void println(char);
    void println(const char[]);
    void println(uint8_t);
    void println(int);
    void println(long);
    void println(unsigned long);
    void println(long, int);
};

extern LB_GPS GPS;	// declare the object to be used outside the methods

#endif

