using System;
using System.Linq;

class Program
{
    static void Main() // 100/100 - !
    {
        var stack = new Stack<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandargs = input.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            string command = commandargs[0];
            var args = commandargs.Skip(1).ToArray();
            
            
                switch (command)
                {
                    case "Push":
                        stack.Push(args);                   
                    break;
                    case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                        break;
                    
                }
            
        }
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }

    }
}

