using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{

    //public DayCommand(IList<string> arguments, IEnergyRepository repository, DraftManager manager)
    //    : base(arguments, repository, manager)
    //{
    //}

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController,
       IProviderController providerController)
    : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        // return this.Manager.Day();

        string providersResult = this.providerController.Produce();
        string harvestersResult = this.harvesterController.Produce();

        return providersResult + Environment.NewLine + harvestersResult;

    }
}

