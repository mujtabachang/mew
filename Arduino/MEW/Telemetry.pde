void SendTelemetry()
{
  Serial<<endl;
  Serial << "T<";
  Serial.print (current_loc.lat,5);          //Latitude
  Serial << ",";
  Serial.print (current_loc.lng,5);          //Longitude
  Serial << ",";
  Serial << BatteryVolt;                     //Battery Voltage
  Serial << ",";
  Serial << WaterTemp;                       //Water Temp
  Serial << ",";
  Serial <<HullTemp;                         //Hull Temp
  Serial << ",";
  Serial << heading;                         //Current Heading
  Serial << ",";
  Serial << roll;                            //Roll
  Serial << ",";
  Serial << pitch;                           //Pitch
  Serial << ",";
  Serial << MotorLValue;                     //Left Motor Value
  Serial << ",";
  Serial << MotorRValue;                     //Right Motor Value
  Serial << ",";
  Serial << wpcurrent;                       //Curent Waypoint
  Serial << ",";
  Serial <<target_heading;                   //Target Heading
  Serial << ",";
  Serial.print(speed,5);                     //Speed
  Serial << ",";
  Serial<<course;                            //Course retrieved from the GPS
  Serial << ",";
  Serial << (int)PowerSavingMode;                 //Power Saving Mode
  Serial << ",";
  Serial << mymode;                          //Current Mode
  Serial << ",";
  Serial << SolarVolt;                       //Solar Volt
  Serial << ",";
  Serial <<"LAST DATA!";
  Serial << ">"<<endl;    
}
