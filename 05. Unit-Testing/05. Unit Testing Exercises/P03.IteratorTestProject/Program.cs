using System;
using System.Linq;
using System.Reflection;

namespace P03.IteratorTestProject
{
    class Program
    {
        static void Main()
        {
            ListIterator list = null;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();
                var command = inputArgs[0];
                var args = inputArgs.Skip(1).ToList();

                //// Reflection на методи не става, щот Create е през ctor-a, а няма метод за него
                //// ако се добави и промени ListIterator ще може!
                //var type = typeof(ListIterator);
                //var instance = Activator.CreateInstance(type, args);
                //var metods = type.GetMethods();// BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                //var targetMethod = metods.FirstOrDefault(m => m.Name == command);
                //targetMethod.Invoke(instance, new object[] { args.ToArray() });

                try
                {
                    switch (command)
                    {
                        case "Create":
                            list = new ListIterator(args);
                            break;
                        case "HasNext":
                            Console.WriteLine(list.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(list.Print());
                            break;
                        case "Move":
                            Console.WriteLine(list.Move());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
