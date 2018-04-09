using System;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main()   // 100/100 - полезно за взимане на атрибути от клас!
    {
        var type = Type.GetType("Weapon");
     
        string input;
        while ((input=Console.ReadLine()) !="END")
        {

            var targetAttribute = type.GetCustomAttribute<CustomAttribute>();

            switch (input)
            {
                case "Author":
                    Console.WriteLine($"Author: "+ targetAttribute.Author);
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: " + targetAttribute.Revision);
                    break;
                case "Description":
                    Console.WriteLine($"Class description: " + targetAttribute.Description);
                    break;
                case "Reviewers":
                    //Console.WriteLine("Attributes.");
                    Console.WriteLine($"Reviewers: " + string.Join(", ", targetAttribute.Reviewers));
                    break;
                default:
                    break;
            }

        }
    }
}

