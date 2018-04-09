using System;
using System.Collections.Generic;
using System.Text;

namespace P09.InfernoInfinity.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand(Dictionary<string, IWeapon> weapons, WeaponFactory weaponFactory, GemFactory gemFactory, string[] args) 
            : base(weapons, weaponFactory, gemFactory, args)
        {
        }

        public override void Execute()
        {
           var weаpon = this.Weapons[Args[1]];
            weаpon.Print();
        }
    }
}
