 /*
  * LB_GPS Medium Example
  * ---------------------
  *
  * Example showing how to print GGA sentences from a GPS shield by Libelium
  * and dumping the raw data to the serial port if valid, also shows how to 
  * address data as variables. 
  *
  * The LB_GPS is a library that masks the commands to be sent to a GPS module
  * by Tyco Electronics (GPS Firmware A1037-A). These GPS modules can send 5
  * types of GPS sentences. They operate over serial port and run a series of
  * proprietary commands. The library tries to simplify the access to those,
  * but also allows for full control for experts.
  *
  * Get the datasheet here: http://www.libelium.com/squidbee/upload/7/75/GPS-Firmware.pdf
  *
  * This example uses the following functions and variables:
  *
  * - the GPS object: it represents your GPS module, you can read/send data from/to it, but also
  *                   use other commands to put it to sleep, initialize it, etc
  * - GPS.init(): boots up the GPS, opens a communication port to it at 4800bps (default for NMEA)
  *                   initializes the GPS with all the default data, it will start thinking that it is
  *                   located in Malmo, Sweden, and that it is 6:56AM, April 8th, 2009
  * - GPS.setSentences(): configures the type of data to read from the GPS, we start with GGA, which
  *                   contains both the location, date, and time of the module
  * - GPS.getRaw(XX): gets XX bytes of the data stream, use 0 to read until the end of line command
  * - GPS.getLibVersion(): prints out some information about the library
  * - GPS.dataValid(): function answering "true" if the data at the port is a valid GPS sentence, updated 
  *                   by a call to GPS.getLocation() only!!
  * - GPS.getLocation(): function updating the values for the time, date, altitude, longitude, latitude - variables
  * - GPS.timeGPS, GPS.dateGPS, GPS.altitude, GPS.longitude, GPS.latitude: some of the GPS variables
  * - GPS.setTime("hh,mm,ss"): function setting up the time to the one given as parameter in the form of a string
  * - GPS.setDate("dd,mm,yyyy"): function setting up the date to the one given as parameter in the form of a string
  * - GPS.getSpeed(): function updating the values for the speed, course - variables
  * - GPS.speed, GPS.course: some more GPS variables
  *
  * Types of GPS sentences:
  *
  * - GPGGA: 3D location and accuracy data 
  * - GPGSA: DOP and active satellites
  * - GPGSV: satellites that the unit might be able to find
  * - GPVTG: Velocity made good, both in knots and Km/h
  * - GPRMC: essential gps pvt (position, velocity, time) data
  *
  * Connection mode & variable space:
  *
  * The GPS shield should be connected on pins 8 (GPS_TX) and 9 (GPS_RX) of your Arduino 
  * board. It is possible to connect it anywhere else, but you should change LB_GPS. The
  * library is allocating over 300 bytes of variable space mostly for string-handling.
  * It makes massive use of an array called inBuffer of 128 bytes of size, but also
  * an array of strings called arguments[] that contains the different comma-separated
  * arguments in every GPS sentence
  *
  * Credits:
  *
  * - designed and coded by D. Cuartielles for Libelium, 2009
  *   http://blushingboy.net
  *
  * - thanks to Dave Mellis for Software Serial in Arduino's core library system
  *   http://dam.mellis.org
  *
  * - based on basic example by Marcos Yarza 
  *   m.yarza [at] libelium [dot] com
  *
  *  Copyright (C) 2009 Libelium Comunicaciones Distribuidas S.L.
  *  http://www.libelium.com
  *
  *  This program is free software: you can redistribute it and/or modify
  *  it under the terms of the GNU General Public License as published by
  *  the Free Software Foundation, either version 3 of the License, or
  *  (at your option) any later version.
  * 
  *  This program is distributed in the hope that it will be useful,
  *  but WITHOUT ANY WARRANTY; without even the implied warranty of
  *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  *  GNU General Public License for more details.
  * 
  *  You should have received a copy of the GNU General Public License
  *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
  *
  */

#include "LB_GPS.h"

void setup(){
  //setup for Serial port
  Serial.begin(19200);

  // print some info and ego boost
  Serial.println(GPS.getLibVersion());
  
  // setup the GPS module
  Serial.print("Setting up GPS...");
  
  // GPS warm-up time
  delay(1000);
  
  // configure NMEA sentences to show only GGA sentence
  // it is anyway the one coming by default
  GPS.setSentences(GPGGA);        
  delay(100);
  
  // command initializing the GPS, by default it is preconfigured to be the 
  // weather station at central Malmo, Sweden, April 8th, 2009, 6:56AM
  GPS.init();    

  // configure your own time and date
  GPS.setDate("18,04,2009");
  GPS.setTime("19,55,00");
  
  // done!
  Serial.println(" done!");
}

void loop(){

  // Part 1: print a GPGGA sentence raw as it comes from the GPS
  
  // print the raw data string arriving from the GPS 
  GPS.getRaw(100);
  Serial.println(GPS.inBuffer);

  delay(1000);

  // Part 2: print a parsed information about location, time, and date
  
  // to work with the variables, you need to
  // flush the raw data into them, use GPS.getLocation for that
  GPS.getLocation();
 
  // now format the data and print it on the serial port
  if (GPS.dataValid())
  {
    Serial.print("Lat: "); Serial.println(GPS.latitude);
    Serial.print("Lon: "); Serial.println(GPS.longitude);
    Serial.print("Alt: "); Serial.println(GPS.altitude);
    Serial.print("Tim: "); Serial.println(GPS.timeGPS);
    Serial.print("Dat: "); Serial.println(GPS.dateGPS);
  } else
    Serial.println("invalid data");  // you might be indoors, bring your device out in the wild!

  delay(1000);

  // Part 3: print parsed information about speed, and course
  
  // to work with the variables, you need to
  // flush the raw data into them, use GPS.getSpeed for that
  GPS.getSpeed();
 
  // now format the data and print it on the serial port
  // note that getSpeed is NOT updating GPS.dataValid(),
  // only GPS.getLocation() is updating it, therefore if
  // the location data is wrong, so will be the speed related one
  if (GPS.dataValid())
  {
    Serial.print("Spe: "); Serial.println(GPS.speed);
    Serial.print("Cou: "); Serial.println(GPS.course);
  } else
    Serial.println("invalid data");  // you might be indoors, bring your device out in the wild!

  delay(1000);
}

