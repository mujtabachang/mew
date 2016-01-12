

void initCommands()
{
  SCmd.addCommand("reset",cmd_reset);               // Reset Command [reset]
  SCmd.addCommand("setid",cmd_setid);               // Set MEW ID Command [setid (int givenewid)]
  SCmd.addCommand("getid",cmd_getid);               // Get MEW ID Command [getid]
  SCmd.addCommand("setwp",cmd_setwp);               // Set Individual Waypoint [setwp (int id, float lat, float lon, int command, int waittime)]
  SCmd.addCommand("heartbeat",cmd_heatbeat);        // Used for ping purposes [ heartbeat]
  SCmd.addCommand("settotalwp",cmd_settotalwp);     // Set the total number of waypoints used [ settotalwp (int no)]
  SCmd.addCommand("setcurrentwp",cmd_setcurrentwp); // Sets the current waypoint [ setcurrentwp (int no)]
  SCmd.addCommand("getcurrentwp",cmd_getcurrentwp); // Gets the current waypoint 
  SCmd.addCommand("clearwps",cmd_clearwps);         // Clears the waypoint data
  SCmd.addCommand("printwps",cmd_printwps);         // Prints the waypoints
  SCmd.addCommand("setmode",cmd_setmode);           // Sets the MyMode Variable [ setmode (int mode)]
  SCmd.addCommand("getmode",cmd_getmode);           // Gets the MyMode Variable 
  SCmd.addCommand("calcdistance",cmd_calcdistance); // Calculates the distance between waypoints [ calcdistance (float lat1, float lon1, float lat2, float lon2)]
  SCmd.addCommand("calcbearing",cmd_calcbearing);   // Calculates the bearing between waypoints [ calcbearing (float lat1, float lon1, float lat2, float lon2)]
  SCmd.addCommand("getgps", cmd_getgps);            // Gets the current GPS Info
  SCmd.addCommand("targets", cmd_targets);          // Gets the current location and current WP info
  SCmd.addCommand("cls", cmd_cls);                  // Clears the screen
  SCmd.addCommand("feventreachwp", cmd_feventreachwp);// Forces the Reach Waypoint Event
  SCmd.addCommand("debugmodecompass", cmd_debugmodecompass);// Toggles the Debug Mode for Compass
  SCmd.addCommand("debugmodegps", cmd_debugmodegps);// Toggles the Debug Mode for GPS
  SCmd.addCommand("debugmodesteering", cmd_debugmodesteering);// Toggles the Debug Mode for Steering
  SCmd.addCommand("debugmodetel", cmd_debugmodetel);// Toggles the Debug Mode for Telemetry
  SCmd.addCommand("getwpradius", cmd_getwpradius);// Gets the wp_radius
  SCmd.addCommand("setwpradius", cmd_setwpradius);// Sets the wp_radius [ setwpradius (int giv) ]
  SCmd.addCommand("goup", cmd_goup);              // Makes the MEW to go Up
  SCmd.addCommand("goright", cmd_goright);        // Makes the MEW to go Right
  SCmd.addCommand("goleft", cmd_goleft);          // Makes the MEW to go Left
  SCmd.addCommand("sendtel", cmd_sendtel);  // Sends the telemetry only once
  SCmd.addCommand("settelrate", cmd_settelrate);  // Sets the Telemetry Send Rate [ settelrate (int giv) ]
  SCmd.addCommand("togignorepowermode", cmd_togignorepowermode);  // Toggles the IgnorePowerSaving Mode


  SCmd.addDefaultHandler(cmd_unrecognized);         // Handler for command that is not listed
  printWelcome();
}
void cmd_getmode()
{
  Serial << "Current Mode is set to " << mymode << endl;
  printPrompt();   
}

void cmd_setmode()
{
  ChangeMode(getintArgument());
  Serial << "MyMode has been set to " << mymode << endl;
  printPrompt();
}

void cmd_printwps()
{
  Serial << endl;
  Serial << "Total Waypoints: " << wptotal << "\tCurrent:" << wpcurrent << endl;
  Serial << "-----------------------------------------------------------"<<endl;
  Serial << "Waypoint ID\tLatitude\tLongitude\tCommand\tWait Time\tName" << endl;

  for (int i=0; i<=wptotal;i++)
  {

    Serial << i <<"\t\t";
    Serial.print( wps[i].lat,5); 
    Serial << "\t";
    Serial.print (wps[i].lng, 5); 
    Serial << "\t";
    Serial << wp_command[i] << "\t\t";
    Serial << wp_waittime[i] << "\t\t";
    Serial.print(wp_name[i]);
    Serial  << "\t\t";
    Serial <<endl;
  }
  Serial << "-----------------------------------------------------------"<<endl;
  printPrompt();
}

void cmd_clearwps()
{
  clearwps();
  Serial.println ("Waypoints Cleared");
  setcurrentWp(0);
  printPrompt();
}

void cmd_settotalwp()
{
  int tmp = getintArgument();
  if (tmp > 16 || tmp < 0) 
  {
    Serial << "Error: Invalid Data or the total number of waypoints reached" << endl; 

  }
  else
  {
    wptotal = tmp; 
    Serial << "Total Number of Waypoints set to " << tmp;
  }
  printPrompt();
}

void cmd_heatbeat()
{
  Serial << "Alive" << "\tPower Saving Mode: " << (int)PowerSavingMode << endl;
  printPrompt();
}
void cmd_reset()
{
  Serial.println("");
  Serial.print("MEW Reseting"); 
  delay(500);
  Serial.print("."); 
  delay(500);
  Serial.print(".");  
  delay(500);
  Serial.print("."); 
  delay(500);
  Serial.println("Rebooting Now"); 
  delay(500);
  softReset();
}

void cmd_unrecognized()
{
  Serial.println("Unknown Command"); 
  printPrompt();
}
void printWelcome()
{
  Serial.println("");
  Serial.println ("|------------------------------------------------------------------|");
  Serial.println ("|              MULTIPURPOSE ENDURING WATERCRAFT                    |");
  Serial.println ("|           Coded by Ahmed Mujtaba Chang [08 ES 22]                |");
  Serial << "|                       Version: " << VERSION << "                          |" << endl;
  Serial.println ("|------------------------------------------------------------------|");
  Serial.println ("");
  Serial.println ("");
  Serial.println ("Ready");
  printPrompt();
}
void cmd_setid()
{
  char *arg;  
  arg = SCmd.next();    // Get the next argument from the SerialCommand object buffer
  mew_id = atoi(arg);
  Serial << "The MEW ID has been set to " << mew_id << endl;
  printPrompt();
}
void cmd_getid()
{
  Serial << "The MEW ID is " << mew_id << endl;
  printPrompt();
}
void cmd_setwp()
{
  int id= getintArgument();
  float lat= getfloatArgument();
  float lon=getfloatArgument();
  int command = getintArgument();
  int time = getintArgument();
  char *wpname = getStringArgument();
  if (id == -1000 || lat == -1000 || lon == -1000 || command ==-1000 || time == -1000 )
  {
    Serial.println ("Error: One or more arguments were not specified" );
    printPrompt();
    return;
  }
  wps[id].lat = lat;
  wps[id].lng = lon;
  wp_command[id] = command;
  wp_waittime[id]=time;
  wp_name[id]=wpname;

  Serial.println("");
  Serial.print ("Waypoint ID: ");
  Serial.print (id);
  Serial.print ("\t Latitude: ");
  Serial.print (lat,5);
  Serial.print ("\t Longitude: ");
  Serial.print (lon,5);
  Serial.print ("\t Command: ");
  Serial.print (command);
  Serial.print ("\t Wait Time: ");
  Serial.print (time);
  Serial.print ("\t WP Name: ");
  Serial.print (wp_name[id]);
  Serial.println ("");


  printPrompt();
}

int getintArgument ()
{
  char *arg;
  arg = SCmd.next(); 
  if (arg != NULL) 
  {
    return atoi(arg); 
  } 
  else {
    return -1000;
  }
}

char* getStringArgument ()
{
  char *arg;
  arg = SCmd.next(); 
  if (arg != NULL) 
  {
    return (arg); 
  } 
  else {
    return "";
  }
}

float getfloatArgument ()
{
  char *arg;
  arg = SCmd.next(); 
  if (arg != NULL) 
  {   
    return atof(arg);     
  } 
  else {
    return -1000;
  }
}

void printPrompt()
{
  if (PRINTPRMPT) Serial << endl << "MEW->"<<endl;    

}

void cmd_calcdistance()
{  
  float get1=getfloatArgument();
  float get2=getfloatArgument();
  float get3=getfloatArgument();
  ;
  float get4=getfloatArgument();
  ;
  float ans=calc_dist(get1, get2, get3, get4);
  ; 
  Serial.println("");
  Serial.print ("The Distance calculated turns out to be: ");
  Serial.print (ans);
  Serial.print (" meters");
  Serial.println(""); 
  printPrompt(); 
}

void cmd_calcbearing()
{ 
  float get1=getfloatArgument();
  float get2=getfloatArgument();
  float get3=getfloatArgument();
  ;
  float get4=getfloatArgument();
  ;
  float ans=calc_bearing(get1, get2, get3, get4);
  ;
  Serial.println("");
  Serial.print ("The Bearing turns out to be: ");
  Serial.print (ans);
  Serial.print (" degrees");
  Serial.println("");
  printPrompt();
}

void cmd_getgps()
{
  Serial << endl << "Latitude: ";
  Serial.print (current_loc.lat,5);
  Serial << "\tLongitude: ";
  Serial.print(current_loc.lng,5);
  Serial << "\tAltitude: " << altitude << "\tSpeed: " << speed << "\tCourse: " << course <<endl;
  printPrompt();
}
void cmd_targets()
{
  Serial << endl << "Current GPS Coordinates: ";  //<< current_WP.lat << ", " << current_WP.lng << endl;
  Serial.print (current_loc.lat, 5);
  Serial.print (", ");
  Serial.print (current_loc.lng,5);
  Serial << endl << "Target Coordinates: ";  //<< current_WP.lat << ", " << current_WP.lng << endl;
  Serial.print (current_WP.lat, 5);
  Serial.print (", ");
  Serial.print (current_WP.lng,5);
  Serial <<endl << "Target Distance : " << target_distance  << "\tTarget Heading : " << target_heading <<endl;

  printPrompt();
}
void cmd_setcurrentwp()
{
  setcurrentWp( getintArgument());
  Serial << endl << "The current waypoint has been set to: "<< wpcurrent << endl;
  Serial << "The coordinates are : " << current_WP.lat << ", " << current_WP.lng << endl;
  printPrompt();
}
void cmd_getcurrentwp()
{
  Serial << endl << "The Current Waypoint is: " << wpcurrent << endl; 
  printPrompt();
}
void cmd_cls()
{
  int a;
  for (a=0; a<100; a++)
  {
    Serial << endl;

  } 
  printPrompt();
}
void cmd_feventreachwp()
{ 
  reachedWaypoint(); 
  printPrompt();
}

void cmd_debugmodecompass()
{
  DEBUGMODE_COMPASS = !DEBUGMODE_COMPASS;
  Serial << endl << "Debug Mode for Compass : " << (int)DEBUGMODE_COMPASS<< endl;
  printPrompt();
}

void cmd_debugmodegps()
{
  DEBUGMODE_GPS = !DEBUGMODE_GPS;
  Serial << endl << "Debug Mode for GPS : " << (int)DEBUGMODE_GPS<< endl;
  printPrompt();
}

void cmd_debugmodesteering()
{
  DEBUGMODE_STEERING = !DEBUGMODE_STEERING;
  Serial << endl << "Debug Mode for STEERING : " << (int)DEBUGMODE_STEERING<< endl;
  printPrompt();
}

void cmd_debugmodetel()
{
  SENDTELEMETRY = !SENDTELEMETRY;
  Serial << endl << "Debug Mode for TELEMETRY : " << (int)SENDTELEMETRY<< endl;
  printPrompt();
}

void cmd_getwpradius()
{
  Serial<<endl << "Waypoint Radius is : " << wp_radius << endl;
  printPrompt();
}

void cmd_setwpradius()
{
  wp_radius = getintArgument();
  Serial<<endl << "Waypoint Radius is now set to : " << wp_radius << endl;
  printPrompt();
}
void cmd_goup()
{
  if (mymode== 0)  
  {
    Serial << endl << "Go Up called" << endl;
    digitalWrite (MOTORLPIN, HIGH);
    digitalWrite (MOTORRPIN, HIGH);
    //timer.setTimeout(MANUALMODEDELAYTIMER, MotorsOff);
    ManualOnIt();
  }
  else
  {
   Serial << endl << "MyMode is not set to 0 (Manual Mode)" << endl;
  }
}


void cmd_goright()
{
  if (mymode== 0)  
  {
    Serial << endl << "Go Right called" << endl;
    digitalWrite (MOTORLPIN, LOW);
    digitalWrite (MOTORRPIN, HIGH);
    //timer.setTimeout(MANUALMODEDELAYTIMER, MotorsOff);
    ManualOnIt();
  }
  else
  {
   Serial << endl << "MyMode is not set to 0 (Manual Mode)" << endl;
  }
}

void cmd_goleft()
{
  if (mymode== 0)  
  {
    Serial << endl << "Go Left called" << endl;
    digitalWrite (MOTORLPIN, HIGH);
    digitalWrite (MOTORRPIN, LOW);
    //timer.setTimeout(MANUALMODEDELAYTIMER, MotorsOff);
    ManualOnIt();
    
  }
  else
  {
   Serial << endl << "MyMode is not set to 0 (Manual Mode)" << endl;
  }
}
void cmd_sendtel()
{
 Serial << endl << "Sending the Telemetry" << endl;
 SendTelemetry();   
}
void cmd_settelrate()
{
  TelemetrySendRate= getintArgument();
  Serial <<  endl <<"Telemetry Send Rate set to " << TelemetrySendRate << " ms" << endl;
  timer.deleteTimer(TelemetryTimerID);
  TelemetryTimerID=timer.setInterval(TelemetrySendRate, TelemetrySendLoop);
}
void cmd_togignorepowermode()
{
  IgnorePowerSavingMode = !IgnorePowerSavingMode;
  Serial << endl << "Ignore Power Saving Mode set to " << (int)IgnorePowerSavingMode << endl;
}
