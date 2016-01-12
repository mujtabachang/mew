int count;
int rettim;
int rettim2;
void initBlinky()
{  
  rettim=timer.setInterval(70, LEDsBlinkyTwoTimes);

}
void LEDsBlinkyFourTimes()
{
  count++;
  if (count > 4)
  {
    rettim2=timer.setTimeout(800, BlinkyDelay);
    timer.deleteTimer(rettim);
    count =0; 
  }
  else{
    digitalWrite(LED1Pin, !digitalRead(LED1Pin));   
    digitalWrite(LED2Pin, !digitalRead(LED2Pin));   
  }
}

void BlinkyDelay()
{
  if (mymode >=1)
  {
    rettim=timer.setInterval(50, LEDsBlinkyFourTimes);
  }
  else{
    rettim=timer.setInterval(70, LEDsBlinkyTwoTimes);
  }
  timer.deleteTimer(rettim2);
}

void LEDsBlinkyTwoTimes()
{
  count++;
  if (count > 2)
  {
    rettim2=timer.setTimeout(5000, BlinkyDelay);
    timer.deleteTimer(rettim);
    count =0; 
  }
  else{
    digitalWrite(LED1Pin, !digitalRead(LED1Pin));   
    digitalWrite(LED2Pin, !digitalRead(LED2Pin));   
  }
}





