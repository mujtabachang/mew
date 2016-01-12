void PowerManagement()
{
  
  if (IgnorePowerSavingMode==1) { PowerSavingMode=0; return;}
  
  if (BatteryVolt < MINIMUMVOLTFORSAVINGMODE)
  {
    PowerSavingMode=1;
    SENDTELEMETRY=0;
  }
  if (BatteryVolt >MAXIMUMVOLTFORSAVINGMODE)
  {
    PowerSavingMode=0;    
  }
}
