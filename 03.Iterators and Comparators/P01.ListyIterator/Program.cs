using System;
using System.Linq;

class Program
{
    static void Main()  // 100/100
    {
        var listyIterator = new ListyIterator<string>();
        string input;
        while ((input =Console.ReadLine()) != "END")
        {
            var commandargs = input.Split();
            var command = commandargs[0];
            var args = commandargs.Skip(1).ToArray();
            try
            {
                switch (command)
                {
                    case "Create":
                        listyIterator.Create(args);
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        } 
    }
}

