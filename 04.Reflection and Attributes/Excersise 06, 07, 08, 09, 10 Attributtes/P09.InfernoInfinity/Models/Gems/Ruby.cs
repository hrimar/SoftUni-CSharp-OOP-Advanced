using System;
using System.Collections.Generic;
using System.Text;

public class Ruby : Gem
{
    private const int RubyAgility = 2;

    private const int RubyStrength = 7;

    private const int RubyVitality = 5;

    public Ruby(ClarityLevel clarity)
        : base(RubyStrength, RubyAgility, RubyVitality, clarity)
    {
    }
}
