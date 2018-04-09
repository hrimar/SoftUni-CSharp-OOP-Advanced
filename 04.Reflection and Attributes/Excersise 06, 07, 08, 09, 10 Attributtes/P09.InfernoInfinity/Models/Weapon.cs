using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Contribution("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    private int maxDamage;

    private int minDamage;

    protected Weapon(string name, int minDamage, int maxDamage, int numberOfSockets, Rarity damageModifier)
    {
        this.Name = name;
        this.Sockets = new IGem[numberOfSockets];
        this.DamageModifier = damageModifier;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
    }

    public int Agility => this.Sockets.Where(x => x != null).Sum(g => g.Agility);

    public Rarity DamageModifier { get; }

    public int MaxDamage
    {
        get =>
            this.maxDamage * (int)this.DamageModifier + 3 * this.Sockets.Where(x => x != null).Sum(g => g.Strength)
                                                      + 4 * this.Sockets.Where(x => x != null).Sum(g => g.Agility);
        set => this.maxDamage = value;
    }

    public int MinDamage
    {
        get =>
            this.minDamage * (int)this.DamageModifier + 2 * this.Sockets.Where(x => x != null).Sum(g => g.Strength)
                                                      + this.Sockets.Where(x => x != null).Sum(g => g.Agility);
        set => this.minDamage = value;
    }

    public string Name { get; }

    public IGem[] Sockets { get; }

    public int Strength => this.Sockets.Where(x => x != null).Sum(g => g.Strength);

    public int Vitality => this.Sockets.Where(x => x != null).Sum(g => g.Vitality);

    public void InsertGem(IGem gem, int index)
    {
        if (index < 0 || index >= this.Sockets.Length) return;

        this.Sockets[index] = gem;
    }

    public void Print()
    {
        Console.WriteLine(
            $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, "
            + $"+{this.Agility} Agility, +{this.Vitality} Vitality");
    }

    public void RemoveGem(int index)
    {
        if (index < 0 || index >= this.Sockets.Length) return;

        this.Sockets[index] = null;
    }
}
