/*
 * LB_GPS.cpp - Communicating through the GPS port for Arduino
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

#include "LB_GPS.h"

/******************************************************************************
 * Definitions & Declarations
 ******************************************************************************/

/******************************************************************************
 * Constructors
 ******************************************************************************/

LB_GPS::LB_GPS()
{
  _receivePin = GPS_RX;
  _transmitPin = GPS_TX;
  pinMode(_receivePin, INPUT);
  pinMode(_transmitPin, OUTPUT);
  _baudRate = 115200;  	// by default we choose NMEA's speed for the port

  // set up the serial port and start it up
  begin();

  // basic GPS configuration
  commMode = SOFTWARE;		// communication mode: software or hardware serial
  pwrMode = GPS_ON;		// power on the GPS
  wakeMode = HOT;   		// wake up without erasing any internal data
  sentences = GPGGA;	        // we want mostly location and speed from the GPS
  timeGPS = (char*) "06,56,00";		// initialization time by default
  dateGPS = (char*) "08,04,2009";	// initialization date by default
  coordinates = (char*) "5535.620,N,01257.330,E,0020"; // Malmo, Sweden, coordinates for a weather station
}

/******************************************************************************
 * User API
 ******************************************************************************/

/******************************************************************************
 * GPS functions
 ******************************************************************************/

// initialize the GPS on default parms
void LB_GPS::init()
{
  init(coordinates, dateGPS, timeGPS);
}

// initialize the GPS with grouped parameters
void LB_GPS::init(const char* _coordinates, const char* _date, const char* _time)
{
  setSentences(sentences);
  sprintf(inBuffer,"$PSTMINITGPS,%s,%s,%s", _coordinates, _date, _time);
  println(inBuffer);
}

// internal function to reflash time, date, and current coordinates
void LB_GPS::configureGPS(void)
{
  char* theTime;
  char* theDate;
  
  // we call this function either with timeGPS or dateGPS as input strings
  // inputStr include commas (',') separating the chuncks of data. If there are
  // no commas, then we need to parse that data and transform it into data valid
  // for the PSTMINITGPS command
  int maxCount = size_of(timeGPS);

  // maxCount == 10 means that the time is stored in the format hhmmss.mmm, and
  // that such a string is 10 chars long, we transfer it to hh,mm,ss
  if (maxCount == 10) {
    char outStr[9];
    int j = 0;
    for (int i = 0; i < maxCount; i++)
    {
      outStr[j] = timeGPS[i];
      j++;
      if (i == 1 || i == 3) 
      {
        outStr[j] = ',';
        j++;
      }
      if (timeGPS[i] == '.') 
      {
        i = maxCount;
        outStr[j-1] = '\0';
      }
    } 
    theTime = outStr;
  } else theTime = timeGPS;

  // repeat the operation for the date
  maxCount = size_of(dateGPS);

  // maxCount == 6 means that the date is stored in the format ddmmyy, and
  // that such a string is 6 chars long, we transfer it to dd,mm,yyyy
  if (maxCount == 6) {
    char outStr[11];
    int j = 0;
    for (int i = 0; i < maxCount; i++)
    {
      outStr[j] = dateGPS[i];
      j++;
      if (i == 1 || i == 3) 
      {
        outStr[j] = ',';
        j++;
      }
      if (i == 3) 
      {
        outStr[j] = '2';
        j++;
        outStr[j] = '0';
        j++;
      }
    } 
    outStr[j] = '\0';
    theDate = outStr;
  } else theDate = dateGPS;
  
  // in the datasheet there is no information about how to configure altitudes that are
  // either negative numbers, or floats. Therefore we choose to make the altitude zero
  // if negative and round it up to an integer if positive
  if (altitude > 0)
    sprintf(inBuffer, "$PSTMINITGPS,%s,%s,%s,%s,%04d,%s,%s",arguments[2],arguments[3],arguments[4],arguments[5],(int) altitude,theDate,theTime);
  else
    sprintf(inBuffer, "$PSTMINITGPS,%s,%s,%s,%s,%04d,%s,%s",arguments[2],arguments[3],arguments[4],arguments[5],0,theDate,theTime);

  println(inBuffer);
}

// define if you will use the software or hardware serial port
// NOT IMPLEMENTED - YET
void LB_GPS::setCommMode(uint8_t mode)
{
  commMode = mode;
}

// get the type of port in use
// so far only softwareserial port	
uint8_t LB_GPS::getCommMode(void)
{
  return commMode;
}

// define a time
// the format for the time is a string like "06,56,00" - hh,mm,ss
void LB_GPS::setTime(char* time)
{
  getLocation();
  timeGPS = time;
  configureGPS();
}

// get the time, send a string back	
char* LB_GPS::getTime(void)
{
  getLocation();
  return timeGPS;
}

// define a date
// the format for the date is a string like "08,04,2009" - dd,mm,yyyy
void LB_GPS::setDate(char* date)
{
  getLocation();
  dateGPS = date;
  configureGPS();
}

// get the type of port in use	
char* LB_GPS::getDate(void)
{
  getLocation();
  return dateGPS;
}

// define the power mode for the device
void LB_GPS::setGPSMode(uint8_t mode)
{
  pwrMode = mode;

  // set the GPS in the defined power mode
  switch (pwrMode)
  {
  case GPS_ON:
    // here there are many different ways of
    // calling the GPS up: COLD, HOT, WARM
    // we don't care, just call restart
    println("$PSTMGPSRESTART");
    break;

  case GPS_OFF:
    // stop the GPS
    println("$PSTMSTOP");
    break;

  case GPS_SLEEP:
    // sleep and hibernate are the same for us
    // we just call standby
    println("$PSTMSTBY");
    break;

  case GPS_HIBERNATE:
    // sleep and hibernate are the same for us
    // we just call standby
    println("$PSTMSTBY");
    break;

  default:
    break;
  }
}

// get the device's power mode
uint8_t LB_GPS::getGPSMode(void)
{
  return pwrMode;
}

// gets the current location and stores it in the corresponding variables
void LB_GPS::getLocation(void)
{
  // store current state to return to it later
  uint8_t currentSentences = getSentences();

  // get Date information
  setSentences(GPRMC);
  getRaw(100);                           // reads the GPS string and stores it in inBuffer
  GPSStringExplode(inBuffer, ',');       // separates all the subarrays from inBuffer into the arguments array
  sprintf(dateGPS, "%s", arguments[9]);  // we use sprintf to copy strings, empirically tested

  // get latitude, longitude, altitude, time
  setSentences(GPGGA);
  getRaw(100);                           // reads the GPS string and stores it in inBuffer
  GPSStringExplode(inBuffer, ',');       // separates all the subarrays from inBuffer into the arguments array
  sprintf(timeGPS, "%s", arguments[1]);  // we use sprintf to copy strings, empirically tested
  latitude =  parse_degrees(arguments[2]) / 100000.0;
  longitude = parse_degrees(arguments[4]) / 100000.0;
  altitude =  parse_decimal(arguments[9]) / 100.0;
  fixValid = (arguments[6][0] - '0');  // the data is valid only if the GPGGA position 7 is 1

  // return to previous state
  setSentences(currentSentences);
}

// forces getLocation and responds the current value of the latitude variable
float LB_GPS::getLatitude(void)
{
  getLocation();
  return latitude;
}

// forces getLocation and responds the current value of the longitude variable
float LB_GPS::getLongitude(void)
{
  getLocation();
  return longitude;
}

// forces getLocation and responds the current value of the speed variable
float LB_GPS::getSpeed(void)
{
  uint8_t currentSentences = getSentences();
  setSentences(GPVTG);
  getRaw(100);                      // reads the GPS string and stores it in inBuffer
  GPSStringExplode(inBuffer, ',');  // separates all the subarrays from inBuffer into the arguments array
  speed = parse_decimal(arguments[7]) / 100.0;
  course = parse_decimal(arguments[1]) / 100.0;
  setSentences(currentSentences);
  return speed;
}

// forces getLocation and responds the current value of the altitude variable
float LB_GPS::getAltitude(void)
{
  getLocation();
  return altitude;
}

// store the next consisten NMEA sentence in the internal buffer inBuffer
// if the input is 0, continue until the end of the GPS sentence or up to
// the max buffer size (GPS_BUFFER_SIZE)
char* LB_GPS::getRaw(int byteAmount)
{
  uint8_t byteGPS = 0;
  int i = 0;
  if (byteAmount == 0) byteAmount = GPS_BUFFER_SIZE;
  while(byteGPS != '$')                   // flush the port
    byteGPS = read();         
  while(byteGPS != '*' && i < byteAmount){ // read the GPS sentence
    byteGPS = read();         
    if (i < byteAmount) inBuffer[i]=byteGPS;               
    i++;                      
  }
  if (byteGPS == '*' || i == byteAmount) inBuffer[i-1] = '\0';  // get rid of the end of string symbol '*'
  else inBuffer[i] = '\0';

  return inBuffer; 
}

// set the NMEA sentences we want to get from the GPS
void LB_GPS::setSentences(int theSentence)
{
  // store it internally
  sentences = theSentence;
  // send it to the port
  //FIXME          sprintf(inBuffer,"$PSTMNMEACONFIG,0,%d,%d,1", _baudRate, theSentence);
  sprintf(inBuffer,"$PSTMNMEACONFIG,0,4800,%d,1", sentences);  // this will work only at 4800
  println(inBuffer);

}

// get the NMEA sentences we are currently getting from the GPS
uint8_t LB_GPS::getSentences()
{
  return sentences;
}
/******************************************************************************
 * Serial communication functions
 ******************************************************************************/

void LB_GPS::begin(void)
{
  begin(4800);
}

void LB_GPS::begin(long speed)
{
  _baudRate = speed;
  _bitPeriod = 1000000 / _baudRate;

  digitalWrite(_transmitPin, HIGH);
  delayMicroseconds( _bitPeriod); // if we were low this establishes the end
}

int LB_GPS::read()
{
  int val = 0;
  int bitDelay = _bitPeriod - clockCyclesToMicroseconds(50);

  // one byte of serial data (LSB first)
  // ...--\    /--\/--\/--\/--\/--\/--\/--\/--\/--...
  //	 \--/\--/\--/\--/\--/\--/\--/\--/\--/
  //	start  0   1   2   3   4   5   6   7 stop

  while (digitalRead(_receivePin));

  // confirm that this is a real start bit, not line noise
  if (digitalRead(_receivePin) == LOW) {
    // frame start indicated by a falling edge and low start bit
    // jump to the middle of the low start bit
    delayMicroseconds(bitDelay / 2 - clockCyclesToMicroseconds(50));

    // offset of the bit in the byte: from 0 (LSB) to 7 (MSB)
    for (int offset = 0; offset < 8; offset++) {
      // jump to middle of next bit
      delayMicroseconds(bitDelay);

      // read bit
      val |= digitalRead(_receivePin) << offset;
    }

    delayMicroseconds(_bitPeriod);

    return val;
  }

  return -1;
}

void LB_GPS::print(uint8_t b)
{
  if (_baudRate == 0)
    return;

  int bitDelay = _bitPeriod - clockCyclesToMicroseconds(50); // a digitalWrite is about 50 cycles
  byte mask;

  digitalWrite(_transmitPin, LOW);
  delayMicroseconds(bitDelay);

  for (mask = 0x01; mask; mask <<= 1) {
    if (b & mask){ // choose bit
      digitalWrite(_transmitPin,HIGH); // send 1
    }
    else{
      digitalWrite(_transmitPin,LOW); // send 1
    }
    delayMicroseconds(bitDelay);
  }

  digitalWrite(_transmitPin, HIGH);
  delayMicroseconds(bitDelay);
}

void LB_GPS::print(const char *s)
{
  while (*s)
    print(*s++);
}

void LB_GPS::print(char c)
{
  print((uint8_t) c);
}

void LB_GPS::print(int n)
{
  print((long) n);
}

void LB_GPS::print(unsigned int n)
{
  print((unsigned long) n);
}

void LB_GPS::print(long n)
{
  if (n < 0) {
    print('-');
    n = -n;
  }
  printNumber(n, 10);
}

void LB_GPS::print(unsigned long n)
{
  printNumber(n, 10);
}

void LB_GPS::print(long n, int base)
{
  if (base == 0)
    print((char) n);
  else if (base == 10)
    print(n);
  else
    printNumber(n, base);
}

void LB_GPS::println(void)
{
  print('\r');
  print('\n');  
}

void LB_GPS::println(char c)
{
  print(c);
  println();  
}

void LB_GPS::println(const char c[])
{
  print(c);
  println();
}

void LB_GPS::println(uint8_t b)
{
  print(b);
  println();
}

void LB_GPS::println(int n)
{
  print(n);
  println();
}

void LB_GPS::println(long n)
{
  print(n);
  println();  
}

void LB_GPS::println(unsigned long n)
{
  print(n);
  println();  
}

void LB_GPS::println(long n, int base)
{
  print(n, base);
  println();
}

// Private Methods /////////////////////////////////////////////////////////////

void LB_GPS::printNumber(unsigned long n, uint8_t base)
{
  unsigned char buf[8 * sizeof(long)]; // Assumes 8-bit chars. 
  unsigned long i = 0;

  if (n == 0) {
    print('0');
    return;
  } 

  while (n > 0) {
    buf[i++] = n % base;
    n /= base;
  }

  for (; i > 0; i--)
    print((char) (buf[i - 1] < 10 ? '0' + buf[i - 1] : 'A' + buf[i - 1] - 10));
}

// Preinstantiate Objects //////////////////////////////////////////////////////

LB_GPS GPS = LB_GPS();

// Experimental Area ///////////////////////////////////////////////////////////

int LB_GPS::size_of(const char* str) 
{
  int count = 0;
  while (*str++)
  {
    count ++;
  }
  return count;
}

void LB_GPS::GPSStringExplode(const char* str, char separator){
  int count = 0, index = 0, sIndex = 0;
  int theSize = size_of(str);
  arguments[index][count] = '\0';  // clear first argument before starting
  while (theSize > sIndex + 1){
     if (*str != separator) 
    {
      arguments[index][count] = *str;
    } 
    else {
      arguments[index][count] = '\0';
    }
    *str++;
    count++;
    sIndex++;
    if (*str == separator)
    {
      *str++; // jump over the separator
      count = 0;
      index++;
      arguments[index][count] = '\0';  // clear argument before starting
    }
  }
}

long LB_GPS::parse_decimal(char *str)
{
  bool isneg = *str == '-';
  if (isneg) *str++;
  unsigned long ret = 100UL * gpsatol(str);
  while (gpsisdigit(*str)) ++str;
  if (*str == '.')
  {
    if (gpsisdigit(str[1]))
    {
      ret += 10 * (str[1] - '0');
      if (gpsisdigit(str[2]))
        ret += str[2] - '0';
    }
  }
  return isneg ? -ret : ret;
}

unsigned long LB_GPS::parse_degrees(char *str)
{
  unsigned long left = gpsatol(str);
  unsigned long tenk_minutes = (left % 100UL) * 10000UL;
  while (gpsisdigit(*str)) ++str;
  if (*str == '.')
  {
    unsigned long mult = 1000;
    while (gpsisdigit(*++str))
    {
      tenk_minutes += mult * (*str - '0');
      mult /= 10;
    }
  }
  return (left / 100) * 100000 + tenk_minutes / 6;
}

long LB_GPS::gpsatol(char *str)
{
  long ret = 0;
  while (gpsisdigit(*str))
    ret = 10 * ret + *str++ - '0';
  return ret;
}
