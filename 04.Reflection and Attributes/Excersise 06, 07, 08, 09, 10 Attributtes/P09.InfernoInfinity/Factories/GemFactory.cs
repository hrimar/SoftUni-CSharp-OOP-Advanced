using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GemFactory
{

    public IGem ProduceGem(string typeAndClarity)
    {
        var gemTokens = typeAndClarity.Split();
        //var clarity = (ClarityLevel)Enum.Parse(typeof(ClarityLevel), gemTokens[0]);
        var clarity = Enum.Parse<ClarityLevel>(gemTokens[0]);

        //switch (gemTokens[1])
        //{
        //    case "Ruby":
        //        return new Ruby(clarity);
        //    case "Emerald":
        //        return new Emerald(clarity);
        //    case "Amethyst":
        //        return new Amethyst(clarity);
        //    default:
        //        return null;

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == gemTokens[1]);

        if (model == null)
        {
            throw new ArgumentException("Unvalid Gem type");
        }
        if (!typeof(IGem).IsAssignableFrom(model))
        {
            throw new ArgumentException($"{gemTokens[1]} is not a Gem Type!");
        }

        IGem gem = (IGem)Activator.CreateInstance(model, new object[] { clarity });
        return gem;
    }
}


