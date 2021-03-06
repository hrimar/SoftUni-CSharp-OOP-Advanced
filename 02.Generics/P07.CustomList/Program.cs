﻿using System;

class Program
{
    static void Main()  // 100/100
    {
        CustomList<string> list = new CustomList<string>();

        string input;
        while ((input = Console.ReadLine()) !="END")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];

            switch (command)
            {
                case "Add":
                    list.Add(commandArgs[1]);
                    break;
                case "Remove":
                    int index = int.Parse(commandArgs[1]);
                    list.Remove(index);
                    break;
                case "Contains":
                    bool result = list.Contains(commandArgs[1]);
                    Console.WriteLine(result);
                    break;
                case "Swap":
                  int firstIndex = int.Parse(commandArgs[1]);
                    int secondIndex = int.Parse(commandArgs[2]);
                    list.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    int count = list.CountGreaterThan(commandArgs[1]);
                    Console.WriteLine(count);
                    break;
                case "Min":
                    string minEl = list.Min();
                    Console.WriteLine(minEl);
                    break;
                case "Max":
                    string maxEl = list.Max();
                    Console.WriteLine(maxEl);
                    break;
                case "Print":
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i]); // see CustomList line 18!
                    }
                    break;
                case "Sort":
                    list.Sort();
                    break;
            }
        }
    }
}

