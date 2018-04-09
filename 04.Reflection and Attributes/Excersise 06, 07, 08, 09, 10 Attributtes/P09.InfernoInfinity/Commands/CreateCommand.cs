using System;
using System.Collections.Generic;
using System.Text;

public class CreateCommand : Command
{
    public CreateCommand(Dictionary<string, IWeapon> weapons, WeaponFactory weaponFactory, GemFactory gemFactory, string[] args)
        : base(weapons, weaponFactory, gemFactory, args)
    {
    }

    public override void Execute()
    {
        this.Weapons[Args[2]] = this.WeaponFactory.ProduceWeapon(Args[1], Args[2]);
    }
}

