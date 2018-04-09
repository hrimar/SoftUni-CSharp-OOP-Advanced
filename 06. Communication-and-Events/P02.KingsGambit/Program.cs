using P02.KingsGambit.Contracts;
using P02.KingsGambit.Models;
using System;
using System.Collections.Generic;

namespace P02.KingsGambit
{
    class Program // 100/100
    {
        static void Main()
        {
            IKing king = SetUpKing();

            Engine engine = new Engine(king);
            engine.Run();

        }

        private static IKing SetUpKing()
        {
            string kingName = Console.ReadLine();
            IKing king = new King(kingName, new List<ISubordinate>());

            string[] royalGuardNames = Console.ReadLine().Split();
            foreach (var name in royalGuardNames)
            {
                king.AddSubordinate(new RoyalGuard(name));
            }

            string[] footmanNames = Console.ReadLine().Split();
            foreach (var name in footmanNames)
            {
                king.AddSubordinate(new Footman(name));
            }

            return king;
        }
    }
}
