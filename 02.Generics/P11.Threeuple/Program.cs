using System;

class Program
{
    static void Main() // 100/100
    {
        var input1 = Console.ReadLine().Split();
        string name = input1[0] + " " + input1[1];
        string address = input1[2];
        string town = input1[3];
        var threeuple1 = new Threeuple<string, string, string>(name, address, town);
        Console.WriteLine(threeuple1);

        string[] input2 = Console.ReadLine().Split();
        string name2 = input2[0];
        int liters = int.Parse(input2[1]);
        bool drinkOrNot = input2[2] == "drunk";
        var threeuple2 = new Threeuple<string, int, bool>(name2, liters, drinkOrNot);
        Console.WriteLine(threeuple2);

        var input3 = Console.ReadLine().Split();
        var name3 = input3[0];
        var doubleNum = double.Parse(input3[1]);
        var bankName = input3[2];
        var threeuple3 = new Threeuple<string, double, string>(name3, doubleNum, bankName);
        Console.WriteLine(threeuple3);
    }
}

