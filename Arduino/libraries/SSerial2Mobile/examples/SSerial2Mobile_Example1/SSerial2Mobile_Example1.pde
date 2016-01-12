/*
 Example of SSerial2Mobile libary 

Sends a SMS and an email
The SMS phone number and the email address need to be changed to something valid. 

 created 21 June 2008
 by Gustav von Roth 
*/

#include <SoftwareSerial.h>
#include <SSerial2Mobile.h>

#define RXpin 2
#define TXpin 3

SSerial2Mobile phone = SSerial2Mobile(RXpin,TXpin);

void setup() {
  phone.sendTxt("+12125550125","Lib SMS Test1");
  delay(3000);
  phone.sendEmail("SSerial2mobile@example.com", "Lib email test1");
}
void loop(){ }
