#define MAXWAYPOINTS 15            //Maximum allowed waypoints

#define SDATARATE 115200           //The main Serial (Console)
#define GPSDATARATE 115200         //GPS Aquisition Serial Rate
#define XBEEDATARATE 9600          //XBee Aquisition Serial Rate

#define DAYNIGHTSENSORPIN 0
#define HULLTEMPPIN 1
#define WATERTEMPPIN 2
#define BATTERYVOLTSENSORPIN 7
#define SOLARVOLTSENSORPIN 8

#define MINIMUMVOLTFORSAVINGMODE 8
#define MAXIMUMVOLTFORSAVINGMODE 10

#define MOTORLPIN 6               //Steering Left Motor Pin (Digital PWM)
#define MOTORRPIN 7               //Steering Right Motor Pin (Digital PWM)

#define MANUALMODEDELAYTIMER 500  //500 ms in Manual Mode

#define FIRSTFACEITANGLE 45

#define LED1Pin 52
#define LED2Pin 53

boolean DEBUGMODE_COMPASS= 0;      //Debug Mode for Compass
boolean DEBUGMODE_GPS=0;           //Debug Mode for GPS
boolean DEBUGMODE_STEERING=0;      //Debug Mode for GPS

boolean IgnorePowerSavingMode=1;   //Ignoring the Power Saving Mode

boolean SENDTELEMETRY=0;            //Telemetry ON & OFF

int TelemetrySendRate=250;

int mew_id=0;

int wp_radius=10;                   //In Meters

boolean PRINTPRMPT =1;


