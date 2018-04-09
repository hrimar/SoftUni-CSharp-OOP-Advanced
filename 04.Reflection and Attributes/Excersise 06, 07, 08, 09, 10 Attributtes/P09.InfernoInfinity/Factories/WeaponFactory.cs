using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class WeaponFactory
{

    public IWeapon ProduceWeapon(string typeAndRarity, string name)
    {
        var typeAndRaritySplit = typeAndRarity.Split();
        //var rarity = (Rarity)Enum.Parse(typeof(Rarity), typeAndRaritySplit[0]);
        Rarity rarity = Enum.Parse<Rarity>(typeAndRaritySplit[0]);

        //switch (typeAndRaritySplit[1])
        //{
        //    case "Axe":
        //        return new Axe(name, rarity);
        //    case "Sword":
        //        return new Sword(name, rarity);
        //    case "Knife":
        //        return new Knife(name, rarity);
        //    default:
        //        return null;
        //}

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == typeAndRaritySplit[1]);

        if (model == null)
        {
            throw new ArgumentException("Unvalid Weapon type");
        }
        if (! typeof(IWeapon).IsAssignableFrom(model))
        {
            throw new ArgumentException($"{typeAndRaritySplit[1]} is not a Weapon Type!");
        }

        IWeapon weapon = (IWeapon)Activator.CreateInstance(model,  new object[] { name, rarity });
        return weapon;
    }
}


