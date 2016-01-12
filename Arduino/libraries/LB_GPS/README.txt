Release Notes:

** Version 01a, better known as 0001-alpha **

Features:

- allows running Libelium's GPS module on Arduino and Arduino compatible boards

- runs on a modified and integrated version of software serial

- depending on the amount of functions included in your code, it compiles
  at sizes between 4KB and 8KB

- uses about 300bytes of memory space

- allows easy acces to data both as integers and strings

- includes a very powerfull GPSStringExplode function that you could use
  for other purposes easily

- includes code by D. Cuartielles, D. Mellis, and M. Hart

- allows low level control of GPS' power modes

- list of functions and use:

    //GPS related functions
    void init(void);		// init the GPS using the default 
					// coordinates, date and time
    void init(const char*, const char*, const char*);	
					// init the GPS using your own 
					// coordinates, date and time
    void setCommMode(uint8_t);// define if you will use the 
					// software or hardware serial port
    uint8_t getCommMode(void);// get the type of port in use
    void setGPSMode(uint8_t);	// define the power mode for the device
    char* getTime(void);	// get the device's time
    void setTime(char*);	// define the time
    char* getDate(void);      // get the device's date
    void setDate(char*);	// define the date
    uint8_t getGPSMode(void);	// get the device's power mode
    void getLocation(void);	// gets the current location and stores 
					// it in the corresponding variables
    float getLatitude(void);	// forces getLocation and responds the 
					// current value of the latitude variable
    float getLongitude(void);	// forces getLocation and responds the 
					// current value of the longitude 
					//variable
    float getSpeed(void);	// forces getLocation and responds the 
					// current value of the speed variable
    float getAltitude(void);	// forces getLocation and responds the 
					// current value of the altitude variable
    char* getRaw(int);		// print XX bytes from the current NMEA 
					// sentences sent by the GPS to the 
					// serial port
    void setSentences(int);	// set the NMEA sentences we want to get 
					// from the GPS
    uint8_t getSentences();   // get the NMEA sentences we are 
					// currently getting from the GPS
    bool dataValid(void) {return fixValid;};  // answers if the last 
					// reading of data was valid

    // general functions
    char* getLibVersion(void) {return VERSION;};  // get the library's 
					// version

- list of public variables:

    // variables, GPS related
    char inBuffer[GPS_BUFFER_SIZE];	// buffer where to store data 
					// coming in
    char arguments[13][11];  	// array of arguments in every GPS raw 
					//string
    uint8_t commMode;		// communication mode: software or 
					// hardware serial
    uint8_t pwrMode;	// power mode for the GPS
    uint8_t wakeMode;   // waking up mode
    uint8_t sentences;	// variable containing the sentences to be used
    char* timeGPS;	// time on the GPS as a string
    char* dateGPS;	// date on the GPS as a string
    char* coordinates;	// coordinates as a string
    float latitude;	// latitude according to last measurement
    float longitude;	// longitude according to last measurement
    float speed;	// speed according to last measurement
    float altitude;	// altitude according to last measurement
    float course;	// course (angle) according to last measurement
    LB_GPS();		// object containing the whole GPS information

- the whole code is implemented as a class with a preinstantiated GPS object, thus the prefix GPS. allows accessing any of the functions or variables

- the mechanism on how the library works is simple. A call to e.g. getLocation() will be made in the form: GPS.getLocation() in your program. Some of the funtions only change internal variables but don't print anything (this is one)
  Subsequent calls to e.g. Serial.println(GPS.dateGPS) will print out the data as updated the last time getLocation() was called

- accessing a variable via a function call will force a reading of the latest value of the variable. Accessing it via the variable will just take the last modification

Known Issues:

- hardware serial port not implemented yet (in the close future)

- this version of LB_GPS supports only one type of GPS sentence at the time for the getRaw(XX) operation; future revisions making use of hardware serial instead of software serial will be able of answering with data sourcing from more than one type of GPS string simultaneously

- the software serial version of the library works with the GPS at 4800bps only

- if you are running linux, please note that as for 20090420 you need to have upgraded gcc-avr to 4.3.1 or newer, there is a known problem with long-ints on previous versions. You can find more information at:  http://arduino.cc/playground/Learning/Linux
