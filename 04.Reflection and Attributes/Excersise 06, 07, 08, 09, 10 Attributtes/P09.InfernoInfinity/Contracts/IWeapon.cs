using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    Rarity DamageModifier { get; }

    int MaxDamage { get; }

    int MinDamage { get; }

    string Name { get; }

    IGem[] Sockets { get; }

    void InsertGem(IGem gem, int index);

    void Print();

    void RemoveGem(int index);
}

