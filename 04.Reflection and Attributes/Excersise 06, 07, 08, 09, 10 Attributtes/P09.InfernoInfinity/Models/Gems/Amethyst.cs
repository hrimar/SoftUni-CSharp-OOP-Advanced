using System;
using System.Collections.Generic;
using System.Text;


public class Amethyst : Gem
{
    private const int AmethystAgility = 8;

    private const int AmethystStrength = 2;

    private const int AmethystVitality = 4;

    public Amethyst(ClarityLevel clarity)
        : base(AmethystStrength, AmethystAgility, AmethystVitality, clarity)
    {
    }
}
