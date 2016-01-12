/*
  SSerial2Mobile.cpp - Software serial to Mobile phone library 
  Copyright (c) 2008 Gustav von Roth.  All right reserved.
  SSerial2Mobile@vonroth.com

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/


//this is only here to grab the constant for BYTE which is 0
#include "HardwareSerial.h"


#include "ATT.h"
#include "MOT-C168i.h"

extern "C" {
	 #include <SoftwareSerial.h>
}

#include "SSerial2Mobile.h"

 
SSerial2Mobile::SSerial2Mobile(int rx, int tx): _sSerial(rx, tx)
{
	  pinMode(rx, INPUT);
          pinMode(tx, OUTPUT);

	_sSerial.begin(PHONE_SERIAL_SPEED);
}

void SSerial2Mobile::println(const char c[])
{
	_sSerial.println(c);
}

void SSerial2Mobile::off(void)
{
	println(PHONE_TURN_OFF_COMMAND);
}

void SSerial2Mobile::on(void)
{
        println(PHONE_TURN_ON_COMMAND);
}

void SSerial2Mobile::reset(void)
{
        println(PHONE_RESET_COMMAND);
}

void SSerial2Mobile::sendTxt(const char number[],const char msg[])
{
	println(PHONE_SET_SMS_TXT_MODE_COMMAND);
	delay(PHONE_DELAY_AFTER_SENDING_COMMAND_VALUE);
	_sSerial.print(PHONE_SEND_MSG);
	 _sSerial.print("\"");
	_sSerial.print(number);
	_sSerial.print("\"");
	_sSerial.println();
	delay(PHONE_DELAY_AFTER_SENDING_COMMAND_VALUE);
	_sSerial.print(msg);
	// dec 26 is a <CTRL Z>
	_sSerial.println(26, BYTE);
	delay(PHONE_DELAY_AFTER_SENDING_COMMAND_VALUE);
}

void SSerial2Mobile::sendEmail(const char emailAddr[],const char msg[])
{
        println(PHONE_SET_SMS_TXT_MODE_COMMAND);
        delay(PHONE_DELAY_AFTER_SENDING_COMMAND_VALUE);
        _sSerial.print(PHONE_SEND_MSG);
        _sSerial.print("\"");
        _sSerial.print(CARRIER_EMAIL_GATEWAY_NUMBER);
        _sSerial.print("\"");
        _sSerial.println();
        delay(PHONE_DELAY_AFTER_SENDING_COMMAND_VALUE);
	 _sSerial.print(emailAddr);
	 _sSerial.print(" ");
        _sSerial.print(msg);
        // dec 26 is a <CTRL Z>
        _sSerial.println(26, BYTE);
	delay(PHONE_DELAY_AFTER_SENDING_COMMAND_VALUE);
}

