int MotorLValue;
int MotorRValue;

void ChangeMode(int givMode)
{
  if (givMode==0 && mymode>0) 
  {
    ManualMotorOffTimer=0;
    MotorsOff(); 
  }  
  mymode=givMode;
}

void navigate()
{ 
  int diff;
  if (mymode==0 || mymode >1)   {   //If Manual or Off/Test Mode is activated, do nothing
    ManualMotorOff();
    return;
  }           

  if (target_distance <=wp_radius)
  {
    reachedWaypoint();     
  }
  diff= abs(target_heading - heading);
  if (diff < FIRSTFACEITANGLE) {
    processSteering();
  }
  else
  {
    FirstFaceIt(); 
  }
  if (PowerSavingMode==0){
    analogWrite (MOTORLPIN, MotorLValue);
    analogWrite (MOTORRPIN, MotorRValue);
  }
  else
  {
    digitalWrite (MOTORLPIN, LOW);
    digitalWrite (MOTORRPIN, LOW);
  }
}

void processSteering()
{
  steer(target_heading - heading);
}

void steer(int offset)                         //Offset is between -360 to 360
{


  if (offset < -360) offset=-360;
  if (offset > 360) offset=360;

  if (offset < 0)                             //Is in Minus
  {
    MotorLValue = map(offset, -FIRSTFACEITANGLE, 0, 0, 255);
    MotorRValue = 255;
  }
  else if (offset > 0)                          //Is Positive
  {
    MotorLValue = 255;
    MotorRValue = map(offset, 0, FIRSTFACEITANGLE, 255, 0);
  }

  if (MotorLValue > 255) MotorLValue=255;
  if (MotorRValue > 255) MotorRValue=255;

  if (DEBUGMODE_STEERING)
  {

    Serial << endl <<"Offset: " << offset  << "\tMotor Left Value: " <<  MotorLValue << "\tMotor Right Value: " << MotorRValue << endl;

  }

}
void FirstFaceIt()
{
  int diff;
  diff= target_heading - heading;

  if (diff <0)
  {
    MotorLValue = 0;
    MotorRValue = 255;
  }
  else if (diff > 0)
  {   
    MotorLValue = 255;
    MotorRValue = 0;
  }  
  if (DEBUGMODE_STEERING)
  {
    Serial << endl << "First Face It called" << "\tMotor Left Value: " <<  MotorLValue << "\tMotor Right Value: " << MotorRValue << endl;
  }
}

void MotorsOff()
{
  digitalWrite (MOTORLPIN, LOW);
  digitalWrite (MOTORRPIN, LOW);
  Serial << endl << "All Motors Off" << endl;
}

void ManualMotorOff()
{

  currentMillis = millis();
  if(currentMillis - previousMillis > MANUALMODEDELAYTIMER) {
    if (ManualMotorOffTimer==1){
      digitalWrite (MOTORLPIN, LOW);
      digitalWrite (MOTORRPIN, LOW);
      Serial << endl << "Manual Motor Off" << endl;
      ManualMotorOffTimer = 0;
    }
  }

}

void ManualOnIt()
{
  ManualMotorOffTimer = 1;
  previousMillis = currentMillis;
}


