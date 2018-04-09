using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    private const int NumberOfSockets = 3;

    private const int SwordMaxDamage = 6;

    private const int SwordMinDamage = 4;

    public Sword(string name, Rarity damageModifier)
        : base(name, SwordMinDamage, SwordMaxDamage, NumberOfSockets, damageModifier)
    {
    }
}
