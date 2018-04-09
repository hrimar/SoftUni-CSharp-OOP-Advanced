using P09.InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P09.InfernoInfinity.Core
{
   public class Engine
    {

        public void Run()
        {
            var weapons = new Dictionary<string, IWeapon>();
            var weapongFactory = new WeaponFactory();
            var gemFactory = new GemFactory();
            var contribAttribute = typeof(Weapon).GetCustomAttribute<ContributionAttribute>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var commandArgs = inputLine.Split(';');
                var commandType = commandArgs[0];

                // var.2 - with Command Pattern:
                Assembly assembly = Assembly.GetCallingAssembly();
                Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == commandType + "Command");

                if (type == null)
                {
                    throw new ArgumentException("Invalid Command!");
                }
                if (!typeof(IExecutable).IsAssignableFrom(type))
                {
                    throw new ArgumentException($"{commandType} is not a Command!");
                }

                MethodInfo method = typeof(IExecutable).GetMethods().First();
                object[] constrArgs = new object[] { weapons, weapongFactory, gemFactory, commandArgs };
                object instance = (IExecutable)Activator.CreateInstance(type, constrArgs);

                try
                {
                    string result = (string)method.Invoke(instance, null);
                }
                catch (TargetInvocationException e)
                {

                    throw e.InnerException;
                }

                // var.1 - switch-case instead of Command Pattern:
                //switch (commandType)
                //{
                //    case "Create":
                //        weapons[commandArgs[2]] = weapongFactory.ProduceWeapon(commandArgs[1], commandArgs[2]);
                //          break;
                //    case "Add":
                //        var gem = gemFactory.ProduceGem(commandArgs[3]);
                //        var weаpon = weapons[commandArgs[1]];
                //        weаpon.InsertGem(gem, int.Parse(commandArgs[2]));
                //        break;
                //    case "Remove":
                //        weаpon = weapons[commandArgs[1]];
                //        weаpon.RemoveGem(int.Parse(commandArgs[2]));
                //        break;
                //    case "Print":
                //        weаpon = weapons[commandArgs[1]];
                //        weаpon.Print();
                //        break;
                //    case "Author":
                //        Console.WriteLine($"Author: {contribAttribute.Author}");
                //        break;
                //    case "Revision":
                //        Console.WriteLine($"Revision: {contribAttribute.Revision}");
                //        break;
                //    case "Description":
                //        Console.WriteLine($"Class description: {contribAttribute.Desctiption}");
                //        break;
                //    case "Reviewers":
                //        Console.WriteLine($"Reviewers: {string.Join(", ", contribAttribute.Reviewers)}");
                //        break;
                //}
            }
        }
    }
}
