using System;
using System.Linq;

class Program
{
    static void Main() // 100/100 - !!!
    {
        var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        var lake = new Lake(input);

        Console.WriteLine(string.Join(", ", lake));
    }
}

