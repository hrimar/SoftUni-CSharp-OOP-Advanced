using System;
using System.Collections.Generic;

class Program
{
    static void Main()  // 100/100
    {
        var list = new List<Box<string>>();

        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfLines; i++)
        {
            var input = Console.ReadLine();
            var box = new Box<string>(input);
            list.Add(box);
        }

        string comparer = Console.ReadLine();

        int count = CalcResultOfComparison<string>(list, comparer);

        Console.WriteLine(count);
    }

    private static int CalcResultOfComparison<T>(List<Box<T>> list, string comparer)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (comparer.CompareTo(item.ToString()) < 0)
            {
                count++;
            }
        }
        return count;
    }
}

