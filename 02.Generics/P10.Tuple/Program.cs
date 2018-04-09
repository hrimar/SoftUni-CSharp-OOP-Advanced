using System;

class Program
{
    static void Main() // 100/100
    {
        var input1 = Console.ReadLine().Split();
        var name = input1[0]+" "+input1[1];
        var address = input1[2];
        var tuple1 = new Tuple<string, string>(name, address);
        Console.WriteLine(tuple1);

        var input2 = Console.ReadLine().Split();
        var name2 = input2[0];
        int liters =int.Parse(input2[1]);
        var tuple2 = new Tuple<string, int>(name2, liters);
        Console.WriteLine(tuple2);

        var input3 = Console.ReadLine().Split();
        var integer = int.Parse(input3[0]);
        var doubleNum = double.Parse(input3[1]);
        var tuple3 = new Tuple<int, double>(integer, doubleNum);
        Console.WriteLine(tuple3);
    }
}

