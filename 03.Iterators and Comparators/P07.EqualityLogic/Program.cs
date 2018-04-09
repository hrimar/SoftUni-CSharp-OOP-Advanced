using System;
using System.Collections.Generic;

class Program
{
    static void Main()  // 100/100 - Very usefull!
    {
        var nameSorter = new SortedSet<Person>();
        var ageSorter = new HashSet<Person>();

        int numberLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberLines; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            int age = int.Parse(input[1]);
            var person = new Person(name, age);

            nameSorter.Add(person);
            ageSorter.Add(person);
        }

        Console.WriteLine(nameSorter.Count);
        Console.WriteLine( ageSorter.Count);

    }
}
