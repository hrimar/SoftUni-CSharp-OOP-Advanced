using System;

public abstract class Provider : IProvider
{
     private double durability;

    private const double InitialDurability = 1000;

    public Provider(int id, double enetenergyOutput)
    {
        this.ID = id;
        this.EnergyOutput = enetenergyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set;  }

    public int ID { get;  }

    public virtual double Durability
    {
        get { return this.durability; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity,
                    this.GetType().Name, this.ID));
            }
            this.durability = value;
        }
    }


    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecrease;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}" +Environment.NewLine+ $"Durability: {this.Durability}";
    }
}