using System;
using System.Collections.Generic;

class Program
{
    static void Main()  //100/100 - Полезна задаюа за Еnum!!
    {
        var signals = Console.ReadLine().Split();
        var n = int.Parse(Console.ReadLine());

        List<TrafficLights> trafficLights = new List<TrafficLights>();


        foreach (var inputSignal in signals)
        {
            Light currentLight = Enum.Parse<Light>(inputSignal);
            trafficLights.Add(new TrafficLights(currentLight));
        }

        for (var i = 0; i < n; i++)
        {
            foreach (TrafficLights trafficLight in trafficLights) trafficLight.SwitchSignal();
            Console.WriteLine(string.Join(" ", trafficLights));
        }

    }
}

