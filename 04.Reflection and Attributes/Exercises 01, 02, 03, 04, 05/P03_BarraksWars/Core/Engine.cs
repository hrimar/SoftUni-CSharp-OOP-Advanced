namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;


    class Engine : IRunnable
    {
        //private IRepository repository;
        //private IUnitFactory unitFactory;

        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            //this.repository = repository;
            //this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    //string result = InterpredCommand(data, commandName);
                    IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

                    // Намираме метода на този клас - в случая е само един:
                    MethodInfo method = typeof(IExecutable).GetMethods().First();
                    try
                    {
                        string result = (string)method.Invoke(command, null);
                        Console.WriteLine(result);
                    }
                    catch (TargetInvocationException e)
                    {
                        throw e.InnerException;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        //    private string InterpredCommand(string[] data, string commandName)
        //    {
        //            string result = string.Empty;

        //            Assembly assembly = Assembly.GetCallingAssembly();
        //            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

        //            if (commandType == null)
        //            {
        //                throw new ArgumentException("Invalid command!");
        //            }
        //            if (!typeof(IExecutable).IsAssignableFrom(commandType)) // всички Commands : IExecutable
        //            {
        //                throw new ArgumentException($"{commandName} is not a Commandt!");
        //            }

        //            // Намираме метода на този клас - в случая е само един:
        //            MethodInfo method = typeof(IExecutable).GetMethods().First();

        //            // правим масив от парам-те за ctor-a:
        //            object[] constrArgs = new object[] { data, this.repository, this.unitFactory };
        //            object instance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

        //            try
        //            {
        //                result = (string)method.Invoke(instance, null); // null щото нямамае аргум за този метод
        //// Ако се хвърли Exception на .Invoke or .CreateInstance, то с Try-Catch трябва да вземем грешката:
        //            }
        //            catch (TargetInvocationException e)
        //            {
        //                throw e.InnerException;
        //            }
        //            return result;


        //            //switch (commandName) // -> code before refactoring:
        //            //{
        //            //    case "add":
        //            //        result = this.AddUnitCommand(data);
        //            //        break;
        //            //    case "report":
        //            //        result = this.ReportCommand(data);
        //            //        break;
        //            //    case "fight":
        //            //        Environment.Exit(0);
        //            //        break;
        //            //    default:
        //            //        throw new InvalidOperationException("Invalid command!");
        //            //}
        //            //return result;
        //        }

        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}
