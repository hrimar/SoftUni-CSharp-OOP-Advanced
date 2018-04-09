using System;
using System.Collections.Generic;

class Program
{
    static void Main()  // 100/100 
    {
        // сравняване на обекто по техните пропъртита
        var persons = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split();
            var name = args[0];
            int age = int.Parse(args[1]);
            var town = args[2];

            var person = new Person(name, age, town);
            persons.Add(person);
        }
        int index = int.Parse(Console.ReadLine()) - 1; // index starts from 1, not from zero

        var matches = 0;
        Person personToCompare = persons[index];
        foreach (var item in persons)
        {
            if (item.CompareTo(personToCompare) == 0)
            {
                matches++;
            }
        }
        if (matches > 1)
        {
            Console.WriteLine($"{matches} {persons.Count - matches} {persons.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}

