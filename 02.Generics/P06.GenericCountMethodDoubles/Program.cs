using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()  // 100/100
    {
        var list = new List<Box<double>>();


        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfLines; i++)
        {
            double input = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(input);
            list.Add(box);
        }

        Box<double> comparerBox = new Box<double>(double.Parse(Console.ReadLine()));
        int count = CountComparer(list, comparerBox);
        Console.WriteLine(count);

    }

    private static int CountComparer<T>(IList<T> list, T comparerBox)
        where T : IComparable<T>
    {
        int count = list.Count(el => el.CompareTo(comparerBox) == 1);

        return count;
    }
}

