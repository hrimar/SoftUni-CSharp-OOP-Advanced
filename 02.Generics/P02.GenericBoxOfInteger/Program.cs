using System;

class Program
{
    static void Main()  // for strings
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Reader.ReadLine(); // from class Reader
            var box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}
