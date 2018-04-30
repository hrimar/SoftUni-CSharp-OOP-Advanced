using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SolarProvider : Provider
{
    private const double InitialDurabilityMultiplier = 500;

    public SolarProvider(int id, double enetenergyOutput) 
        : base(id, enetenergyOutput)
    {
        this.Durability += InitialDurabilityMultiplier;
    }
}

