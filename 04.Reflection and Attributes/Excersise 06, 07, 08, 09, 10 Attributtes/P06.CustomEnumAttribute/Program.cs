using System;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var typeAttribute = new TypeAttribute(input);
        Console.WriteLine(typeAttribute);


       //var type = typeof(TypeAttribute);
       // var fielType = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
       //     .Where(f => f.Name == "Type");
       // Console.WriteLine(fielType.GetType());
       
    }
}
