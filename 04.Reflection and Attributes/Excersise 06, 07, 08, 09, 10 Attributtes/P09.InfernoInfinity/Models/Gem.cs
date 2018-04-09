using System;
using System.Collections.Generic;
using System.Text;

public class Gem : IGem
{
    private int agility;

    private int strength;

    private int vitality;

    public Gem(int strength, int agility, int vitality, ClarityLevel clarity)
    {
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;
        this.Clarity = clarity;
    }

    public int Agility
    {
        get => this.agility + (int)this.Clarity;
        set => this.agility = value;
    }

    public ClarityLevel Clarity { get; }

    public int Strength
    {
        get => this.strength + (int)this.Clarity;
        set => this.strength = value;
    }

    public int Vitality
    {
        get => this.vitality + (int)this.Clarity;
        set => this.vitality = value;
    }
}
