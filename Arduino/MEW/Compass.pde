unsigned char ACC_Data[6];
unsigned char temp, MR_Data[6];
int Ax, Ay, Az; 
int Mx, My, Mz; 
float Mx2;   
float My2;  
float Mz2;
float pitch; 
float roll;
float heading;
float heading2;

float _declination= 0;

void initCompass()
{
  Wire.begin();
  compass_Write(0x18, 0x20, 0x27);//set CTRL_REG1_A register
  compass_Write(0x18, 0x23, 0x40);//set CTRL_REG4_A register

  compass_Write(0x1E, 0x00, 0x14);//set CRA_REG_M register
  compass_Write(0x1E, 0x02, 0x00);//set MR_REG_M register 
}

void readCompass()
{
  ACC_Data[0] = compass_Read(0x18, 0x28);//read OUT_X_L_A (MSB)
  ACC_Data[1] = compass_Read(0x18, 0x29);//read OUT_X_H_A (LSB)
  ACC_Data[2] = compass_Read(0x18, 0x2A);//read OUT_Y_L_A (MSB)
  ACC_Data[3] = compass_Read(0x18, 0x2B);//read OUT_Y_H_A (LSB)
  ACC_Data[4] = compass_Read(0x18, 0x2C);//read OUT_Z_L_A (MSB)
  ACC_Data[5] = compass_Read(0x18, 0x2D);//read OUT_Z_H_A (LSB)
  Ax = (int) (ACC_Data[0] << 8) + ACC_Data[1];
  Ay = (int) (ACC_Data[2] << 8) + ACC_Data[3];
  Az = (int) (ACC_Data[4] << 8) + ACC_Data[5];

  //Ax = map(Ax, 16700, -16700, 0, 360);
  //Ay = map(Ay, 16700, -16700, 0, 360);
  //Az = map(Az, 16700, -16700, 0, 360);

  temp = compass_Read(0x1E, 0x02); //read MR_REG_M
  MR_Data[0] = compass_ReadCurrentAddress(); //read OUT_X_H_M (MSB)
  MR_Data[1] = compass_ReadCurrentAddress(); //read OUT_X_L_M (LSB)
  MR_Data[2] = compass_ReadCurrentAddress(); //read OUT_Y_H_M (MSB)
  MR_Data[3] = compass_ReadCurrentAddress(); //read OUT_Y_L_M (LSB)
  MR_Data[4] = compass_ReadCurrentAddress();//read OUT_Z_H_M (MSB)
  MR_Data[5] = compass_ReadCurrentAddress(); //read OUT_Z_L_M (LSB)
  Mx = (int) (MR_Data[0] << 8) + MR_Data[1];
  My = (int) (MR_Data[2] << 8) + MR_Data[3];
  Mz = (int) (MR_Data[4] << 8) + MR_Data[5];



  pitch = atan( Ax / ( sqrt ( pow(Ay,2) + pow (Az,2) ) ) );        //WORKING BUT DISABLED FOR TRYING NEW THING
   
  roll = atan ( Ay / ( sqrt ( pow(Ax,2) + pow (Az,2) ) ) );        //WORKING BUT DISABLED FOR TRYING NEW THING
  
  //pitch =asin (-Ax);
  //roll = asin (Ay/cos(pitch));


  Mx2 = Mx * cos(pitch) + Mz * sin (pitch);
  My2 = Mx * sin(roll)*sin(pitch) + My *cos(roll) - Mz * sin(roll) * cos(pitch);
  Mz2 = - Mx * cos (roll) * sin (pitch) + My * sin(roll) + Mz * cos(roll)* cos (pitch);


  heading = ToDeg(atan(My2/Mx2));

  

  if (Mx2 >= 0 && My2 >=0)
  { 
    if (DEBUGMODE_COMPASS){
    Serial.println("QUARDRANT 1");
    }
  }
  
  else if (Mx2 < 0 && My2>=0)
  {
    heading =  heading + 180;
    if (DEBUGMODE_COMPASS){
    Serial.println("QUARDRANT 2");
    }
  }
  else if (Mx2 <0 && My2<0)
  {
    if (DEBUGMODE_COMPASS){
    Serial.println("QUARDRANT 3");
    }
    heading =  heading + 180; 
  }
  else if (Mx2>=0 && My2 <=0)
  {
    if (DEBUGMODE_COMPASS){
    Serial.println("QUARDRANT 4");
    }
    heading =  heading + 360;  
  }


  float a= abs ( sqrt (   pow(Mx2, 2) + pow (My2,2) +pow(Mz2,2)               )             );
  if (DEBUGMODE_COMPASS){
  
  Serial.println("Debug: Displaying Compass Data");
  Serial.print("MX2: ");
  Serial.print(Mx2);
  Serial.print("\tMY2: ");

  Serial.print(My2);
  Serial.print("\tMZ2: ");

  Serial.print(Mz2);
  Serial.print("\t");


  //Serial.print("X: ");
  //Serial.print(Ax);
  //Serial.print("\tY: ");

  //Serial.print(Ay);
  //Serial.print("\tZ: ");

  //Serial.print(Az);
  //Serial.print("\t");


  Serial.print("Pitch: ");
  Serial.print(ToDeg(pitch));
  Serial.print("\tRoll: ");
  Serial.print(ToDeg(roll));
  Serial.print("\tHeading: ");
  Serial.print(heading);
  Serial.print("\tTotal Magnitude : ");
  Serial.print(a);
  Serial.println("");
    
  }


}

void compass_Write (int a, int address, byte value)
{
  Wire.beginTransmission(a);
  Wire.send(address);
  Wire.send(value);
  Wire.endTransmission();
  delay(10);
}

byte compass_Read(int a, int address)
{
  byte result;
  byte buff[1];
  Wire.beginTransmission(a);
  Wire.send(address);     //sends address to read from
  Wire.endTransmission(); //end transmission

    Wire.requestFrom(a, 1);    // request 1 byte from device
  if( Wire.available() )
    result = Wire.receive();  // receive one byte
  Wire.endTransmission(); //end transmission

    return result; 
}


byte compass_ReadCurrentAddress()
{
  byte result;
  byte buff[1];
  Wire.beginTransmission(0x1E);
  //Wire.send(address);     //sends address to read from
  Wire.endTransmission(); //end transmission

    Wire.requestFrom(0x1E, 1);    // request 1 byte from device
  if( Wire.available() )
    result = Wire.receive();  // receive one byte
  Wire.endTransmission(); //end transmission

    return result; 
}

float compass_Calculate()
{

  float headX;
  float headY;
  float cos_roll;
  float sin_roll;
  float cos_pitch;
  float sin_pitch;
  cos_roll = cos(roll);  
  sin_roll = sin(roll);
  cos_pitch = cos(pitch);
  sin_pitch = sin(pitch);

  // Tilt compensated magnetic field X component:
  headX = Mx *cos_pitch + My*sin_roll*sin_pitch + Mz*cos_roll*sin_pitch;
  // Tilt compensated magnetic field Y component:
  headY = Mx*cos_roll - Mz*sin_roll;
  
  
  
  // magnetic heading
  heading2 = atan2(-headY,headX);

  // Declination correction (if supplied)
  if( fabs(_declination) > 0.0 )
  {
    heading2 = heading2 + _declination;
    if (heading2 > M_PI)    // Angle normalization (-180 deg, 180 deg)
      heading2 -= (2.0 * M_PI);
    else if (heading2 < -M_PI)
      heading2 += (2.0 * M_PI);
  }

  // Optimization for external DCM use. Calculate normalized components
  //heading_x = cos(heading);
  //heading_y = sin(heading);
  return heading2;
}




