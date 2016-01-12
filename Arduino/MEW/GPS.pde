
void initGPS()
{

  GPS.Init();                           // GPS Initialization
  delay(1000);
}
void getGPS()
{

  GPS.Read();
  
  target_distance = calc_dist (current_loc.lat, current_loc.lng, current_WP.lat, current_WP.lng);
  target_heading = calc_bearing (current_loc.lat, current_loc.lng, current_WP.lat, current_WP.lng);
  
  if (GPS.NewData)  // New GPS data?
  {
    if (GPS.Fix >= 1)
    {      
    current_loc.lat =GPS.Lattitude/10000000.0;
    current_loc.lng = GPS.Longitude/10000000.0;
    speed= GPS.Ground_Speed/100.0;
    altitude = GPS.Altitude/1000.0;
    course = GPS.Ground_Course/100.0;
    
   
    
    if (homefixed==0)                          //Init home location where the GPS was first fixed
    {
      home = current_loc;
      homefixed=1;
    }
    
    }
    if (DEBUGMODE_GPS){
    Serial.print("GPS:");
    Serial.print(" Time:");
    Serial.print(GPS.Time);
    Serial.print(" Fix:");
    Serial.print((int)GPS.Fix);
    Serial.print(" Lat:");
    Serial.print(current_loc.lat,5);
    Serial.print(" Lon:");
    Serial.print(current_loc.lng,5);
    Serial.print(" Alt:");
    Serial.print(altitude,5);
    Serial.print(" Speed:");
    Serial.print(speed,5);
    Serial.print(" Course:");
    Serial.print(course,5);
    Serial.println();
    }
    GPS.NewData = 0; // We have readed the data

  }
}



