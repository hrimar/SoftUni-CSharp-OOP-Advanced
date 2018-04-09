using System;
using System.Collections.Generic;

class Program
{
    static void Main() // 100/100 - Very good Example!
    {
        var nameSorter = new SortedSet<Person>(new PersonNameComparer()); 
        var ageSorter = new SortedSet<Person>(new PersonAgeComparer()); 

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

        Console.WriteLine(string.Join(Environment.NewLine, nameSorter));
        Console.WriteLine(string.Join(Environment.NewLine, ageSorter));
    }
}

