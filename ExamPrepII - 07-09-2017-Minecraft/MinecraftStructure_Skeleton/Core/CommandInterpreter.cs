using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    //private IEnergyRepository repository;  
    //private IHarvesterFactory harvesterFactory; 
    //private IProviderFactory providerFactory;
    
    public CommandInterpreter(IHarvesterController harvesterController,
        IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }


    public string ProcessCommand(IList<string> args)
    {
        // Command Pattern без Service Provider:!!!
        ICommand command = this.CreateCommand(args);

        string result = command.Execute();
        return result;

        //string result = string.Empty;        
        //// Пример за Commnad Pattern !!!
        //var commandName = args[0];
        //Assembly assembly = Assembly.GetCallingAssembly();
        //Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");
        //var method = commandType.GetMethods().First();

        //// Вар.1. - правим масив от парам на ctor-a за всички полета:
        //object[] ctorArgs = new object[] { args, this.repository, this.manager };//, this.ProviderController.};                

        //ICommand instance = (ICommand)Activator.CreateInstance(commandType, ctorArgs);

        //try
        //{
        //     result = (string)method.Invoke(instance, null);
        //}
        //catch (TargetInvocationException e)
        //{
        //    throw e.InnerException;
        //}
        //return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        //Целта тук е всяка команда да държи само това депенънси, което и трябва на нея!!!!
      
        string commandName = args[0];

        Assembly assembly = Assembly.GetCallingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");
        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }
        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        // За взимане на ctor-a без Service Provider и след това парам на ctor-a на Harvester или Provider:
        ConstructorInfo ctor = commandType.GetConstructors().First();
        ParameterInfo[] ctorParametersInfo = ctor.GetParameters();
        object[] parameters = new object[ctorParametersInfo.Length];

        for (int i = 0; i < ctorParametersInfo.Length; i++)
        {
            Type paramType = ctorParametersInfo[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);
                parameters[i] = paramInfo.GetValue(this);
            }
        }

        ICommand instance = (ICommand)Activator.CreateInstance(commandType, parameters);
        return instance;
    }
}

