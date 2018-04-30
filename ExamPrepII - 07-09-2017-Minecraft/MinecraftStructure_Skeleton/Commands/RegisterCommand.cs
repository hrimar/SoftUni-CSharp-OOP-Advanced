using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class RegisterCommand : Command
{
    //public RegisterCommand(IList<string> arguments, IEnergyRepository repository, DraftManager manager) 
    //    : base(arguments, repository, manager)
    //{
    //}

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController,
       IProviderController providerController)
    : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string result = null;
        string entityType = this.Arguments[0];
        if(entityType == nameof(Harvester))
        {
           result =  this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if(entityType == nameof(Provider))
        {
           result =  this.providerController.Register(this.Arguments.Skip(1).ToList());
        }
        return result;

        //var args = new List<string>(this.Arguments.Skip(1).ToList());
        //var command = args[0];
        // //Пример за Command Pattern, извикващ методи на класа Manager!!! - Reflection
        // var type = typeof(DraftManager);
        // //var instance = Activator.CreateInstance(type, this.Manager); // instance е this.Manager-a!!!
        //var metods = type.GetMethods(); // (BindingFlags.Instance | BindingFlags.Public);
        // var targetMethod = metods.FirstOrDefault(m => m.Name.Contains(command));
        //var result =(string)targetMethod.Invoke(this.Manager, new object[] { args.ToList() });
        // return result;

        // //if (command== "Harvester") //- без - Reflection
        //{ 
        // //return  this.Manager.RegisterHarvester(args); ///
        //}
        //    //return this.Manager.RegisterProvider(args); ///

    }
}

