using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()    // 100/100
    {
        var list = new List<Box<int>>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
            list.Add(box);
        }

        var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

       var swapedList= Swap(list, indexes[0], indexes[1]);

        foreach (var item in swapedList)
        {
            Console.WriteLine(item);
        }
    }

    private static List<T> Swap<T>(List<T> list, int v1, int v2) // така метода приема всеки тип!
    {
        var temp = list[v1];

        list[v1] = list[v2];
        list[v2] = temp;

        return list;
    }
}

