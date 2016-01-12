void readSensors()
{
  float tempFHull;
  float tempFWater;
  
 
  for (int i = 0; i<=15;i++)
  {
    sensor[i] = analogRead(i);       
  }
  
    
  tempFHull= sensor[HULLTEMPPIN];
  tempFHull = (5.0 * tempFHull * 100.0)/1024.0;  //Convert the Analog Voltage to Temperature
  
  tempFWater= sensor[WATERTEMPPIN];
  tempFWater = (5.0 * tempFWater * 100.0)/1024.0;  //Convert the Analog Voltage to Temperature
  
  HullTemp = (tempFHull-32) * 5/9;
  WaterTemp = (tempFWater-32) * 5/9;
  
  BatteryVolt = (5.0 * sensor[BATTERYVOLTSENSORPIN]) /1024;
  BatteryVolt = (BatteryVolt * (10 + 2.2)) / 2.2;

  SolarVolt = (5.0 * sensor[SOLARVOLTSENSORPIN]) /1024;
  SolarVolt = (SolarVolt * (10 + 2.2)) / 2.2;

}
