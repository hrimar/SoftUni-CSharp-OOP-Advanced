using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    private const int KnifeMaxDamage = 4;

    private const int KnifeMinDamage = 3;

    private const int NumberOfSockets = 2;

    public Knife(string name, Rarity damageModifier)
        : base(name, KnifeMinDamage, KnifeMaxDamage, NumberOfSockets, damageModifier)
    {
    }
}
