using System;
using System.Collections.Generic;
using System.Text;

public class Emerald : Gem
{
    private const int EmeraldAgility = 4;

    private const int EmeraldStrength = 1;

    private const int EmeraldVitality = 9;

    public Emerald(ClarityLevel clarity)
        : base(EmeraldStrength, EmeraldAgility, EmeraldVitality, clarity)
    {
    }
}
