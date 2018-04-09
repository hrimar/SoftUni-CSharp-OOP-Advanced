using System;

class Program
{
    static void Main()  // 100/100 - Пак разгледай LinkedList class!
    {
        var linkedList = new LinkedList<int>();

        int countLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < countLines; i++)
        {
            var input = Console.ReadLine().Split();
            var command = input[0];
            var number = int.Parse(input[1]);
            switch (command)
            {
                case "Add":
                    linkedList.AddToEnd(number);
                    break;
                case "Remove":
                    linkedList.Remove(number);
                    break;
            }
        }
        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}

