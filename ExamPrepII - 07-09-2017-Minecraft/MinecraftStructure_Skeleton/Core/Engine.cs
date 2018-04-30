using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine : IEngine
{
    private ICommandInterpreter commandInterpreter;
    private IWriter writer;
    private IReader reader;

   
    public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
    {
        this.commandInterpreter = commandInterpreter;
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                var input = this.reader.ReadLine();
                var data = input.Split().ToList();

                var commandName = data[0];
                
                string command = commandInterpreter.ProcessCommand(data);

                this.writer.WriteLine(command);

                if (commandName == Constants.End)
                {
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //switch (command)
            //{
            //    case RegisterHarvester:
            //        var args = new List<string>(data.Skip(1).ToList());
            //        manager.RegisterHarvester(args);
            //        break;
            //    case RegisterProvider:
            //        args = new List<string>(data.Skip(1).ToList());
            //        manager.RegisterProvider(args);
            //        break;
            //    case Day:
            //        manager.Day();
            //        break;
            //    case Mode:
            //        args = new List<string>(data.Skip(1).ToList());
            //        manager.Mode(args);
            //        break;
            //    case Check:
            //        args = new List<string>(data.Skip(1).ToList());
            //        //Console.WriteLine(manager.Check(args));
            //        break;
            //    default:
            //        manager.ShutDown();
            //        Environment.Exit(0);
            //        break;
            //}
        }
    }

    private string InterpredCommand(List<string> data, string command)
    {
        string result = string.Empty;

        Assembly assembly = Assembly.GetCallingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == command + "Command");

        MethodInfo method = typeof(ICommand).GetMethods().First();


        return result;
    }
}
