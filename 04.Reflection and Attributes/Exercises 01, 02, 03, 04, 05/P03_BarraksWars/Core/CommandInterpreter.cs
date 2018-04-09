using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        //private IRepository repository;
        //private IUnitFactory unitFactory;
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)  // (IRepository repository, IUnitFactory unitFactory)
        {
            this.serviceProvider = serviceProvider;
            //this.repository = repository;
            //this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            //string result = string.Empty;

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType)) // всички Commands : IExecutable
            {
                throw new ArgumentException($"{commandName} is not a Commandt!");
            }

            // правим масив от парам-те за ctor-a:
            //object[] constrArgs = new object[] { data, this.repository, this.unitFactory };


            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] constrArgs = new object[] { data }.Concat(injectArgs).ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

            return instance;

          
     
            //switch (commandName) // -> code before refactoring:
            //{
            //    case "add":
            //        result = this.AddUnitCommand(data);
            //        break;
            //    case "report":
            //        result = this.ReportCommand(data);
            //        break;
            //    case "fight":
            //        Environment.Exit(0);
            //        break;
            //    default:
            //        throw new InvalidOperationException("Invalid command!");
            //}
            //return result;
        }
    }
}
