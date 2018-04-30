using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
    //public RepairCommand(IList<string> arguments, IEnergyRepository repository, DraftManager manager) 
    //    : base(arguments, repository, manager)
    //{
    //}
     
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController)
    : base(arguments)
    {       
        this.providerController = providerController;
    }

    public override string Execute()
    {
        // трябва ни ProviderController ?????


        double val = double.Parse(this.Arguments[0]);
        string result = this.providerController.Repair(val);
        return result;
    }
}

