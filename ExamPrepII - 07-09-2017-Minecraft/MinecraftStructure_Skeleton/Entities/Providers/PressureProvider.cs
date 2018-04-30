using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PressureProvider : Provider
{
    private const double InitialDurabilityMultiplier = 300;
    private const double InitialEnergyOutputMultiplier = 2;

    public PressureProvider(int id, double enetenergyOutput)
        : base(id, enetenergyOutput)
    {
        this.Durability -= InitialDurabilityMultiplier;
        this.EnergyOutput *= InitialEnergyOutputMultiplier;
    }
}

