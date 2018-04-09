using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLights
{

    public TrafficLights(Light lightSignal)
    {
        this.LightSignal = lightSignal;
    }

    public Light LightSignal { get; set; }

    public void SwitchSignal()
    {
        this.LightSignal = (Light)((int)++this.LightSignal % 3);
    }

    public override string ToString()
    {
        return this.LightSignal.ToString();
    }
}

