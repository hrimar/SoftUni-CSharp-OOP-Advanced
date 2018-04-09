using System;


class Program
{
    static void Main() // 100/100 - Important - see Spy class
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);
    }
}

