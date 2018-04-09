using System;

class Program
{
    static void Main()  // 100/100 - for int
    {
        int n =int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var box = new Box<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(box);
        }
    }
}

