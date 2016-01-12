void clearwps()
{
  wptotal=0;
  wpcurrent=0;
  home.lat = 0;  
  home.lng = 0;
  prev_WP.lat=0; 
  prev_WP.lng =0;
  current_loc.lat=0; 
  current_loc.lng=0;
  current_WP.lat=0; 
  current_WP.lng=0;

  for (int i = 0; i<=MAXWAYPOINTS; i++)
  {
    wp_command[i] = 0;
    wp_waittime[i] = 0;
    wps[i].lat =0;
    wps[i].lng =0;
    wp_name[i] = 0;
  } 
}

/*************************************************************************
 * //Function to calculate the distance between two waypoints
 *************************************************************************/
float calc_dist(float flat1, float flon1, float flat2, float flon2)
{
  float dist_calc=0;
  float dist_calc2=0;
  float diflat=0;
  float diflon=0;

  //I've to spplit all the calculation in several steps. If i try to do it in a single line the arduino will explode.
  diflat=radians(flat2-flat1);
  flat1=radians(flat1);
  flat2=radians(flat2);
  diflon=radians((flon2)-(flon1));

  dist_calc = (sin(diflat/2.0)*sin(diflat/2.0));
  dist_calc2= cos(flat1);
  dist_calc2*=cos(flat2);
  dist_calc2*=sin(diflon/2.0);
  dist_calc2*=sin(diflon/2.0);
  dist_calc +=dist_calc2;

  dist_calc=(2*atan2(sqrt(dist_calc),sqrt(1.0-dist_calc)));

  dist_calc*=6371000.0; //Converting to meters
  //Serial.println(dist_calc);
  return dist_calc;
}


int calc_bearing(float flat1, float flon1, float flat2, float flon2)
{
  float calc;
  float bear_calc;

  float x = 69.1 * (flat2 - flat1); 
  float y = 69.1 * (flon2 - flon1) * cos(flat1/57.3);

  calc=atan2(y,x);

  bear_calc= degrees(calc);

  if(bear_calc<=1){
    bear_calc=360+bear_calc; 
  }
  return bear_calc;
}  

void setcurrentWp(int a)
{
  if (a > wptotal)  a= wptotal;
  if (a < 0) a=0; 


  current_WP.lat  = wps[a].lat;
  current_WP.lng  = wps[a].lng;

  wpcurrent = a;


  Serial << endl << "setcurrentWp called, now Current Waypoint is: " << a <<endl;

  setpreWp(a-1); 



}

void setpreWp(int a)
{
  if (a > wptotal)  a= wptotal;     
  if (a < 0)   a=0; 

  prev_WP.lat= wps[a].lat;
  prev_WP.lng= wps[a].lng;

  Serial << endl << "setpreWp called, now Previous Waypoint is: " << a<<endl;
}

void reachedWaypoint()
{
  int temp= (wpcurrent +1);

  Serial << endl << "Reached Waypoint: " << wpcurrent << "\t Name: " << wp_name[wpcurrent]<< endl;
  setcurrentWp(temp);
   
  if (temp >wptotal )
  {
    Serial << endl << "Navigation Complete. All waypoints reached, shifting to Off/Manual Mode" << endl;
    navigationDone();
    return ;
  }

}

void navigationDone()
{
  ChangeMode(0);
  setcurrentWp (0);  
  MotorsOff();
}

