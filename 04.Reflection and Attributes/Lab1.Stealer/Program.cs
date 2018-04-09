using System;

class Program
{
    static void Main() // see Spy class - 100/100
    {
        Spy spy = new Spy();
        string result = spy.StealFieldInfo("System.Text.StringBuilder", "MaxChunkSize", "ThreadIDField");
        Console.WriteLine(result);
    }
}

