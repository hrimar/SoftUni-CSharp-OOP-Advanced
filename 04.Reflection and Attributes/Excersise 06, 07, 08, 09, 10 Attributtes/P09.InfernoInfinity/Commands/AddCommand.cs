using System;
using System.Collections.Generic;
using System.Text;

public class AddCommand : Command
{
    public AddCommand(Dictionary<string, IWeapon> weapons, WeaponFactory weaponFactory, GemFactory gemFactory, string[] args)
        : base(weapons, weaponFactory, gemFactory, args)
    {
    }

    public override void Execute()
    {
        var gem = this.GemFactory.ProduceGem(Args[3]);
        var weаpon = this.Weapons[Args[1]];
        weаpon.InsertGem(gem, int.Parse(Args[2]));
               
    }
}

