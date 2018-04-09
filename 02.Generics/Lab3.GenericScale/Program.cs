using System;


class Program
{
    static void Main()
    {
        // Console.WriteLine(default(int)); - дава деф. ст-ст на тип!!!

        var scale = new Scale<string>("ico", "koko");
        Console.WriteLine(scale.GetHeavier());
    }
}

