using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()  // 100/100 - Пак!
    {
        List<Box<string>> list = new List<Box<string>>(); // !!!

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            var box = new Box<string>(input);
            list.Add(box);
        }

        var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int index1 = indexes[0];
        int index2 = indexes[1];

        Swap(list, index1, index2);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private static IList<T> Swap<T>(IList<T> list, int index1, int index2) // така метода приема всеки тип!
    {
        var temp = list[index1];

        list[index1] = list[index2];
        list[index2] = temp;

        return list;
    }
}

