using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    // private const string ShutDown = "System Shutdown";
    //// private const string ShutDown = "System Shutdown";
    // private const string TotalEnergy = "Total Energy Produced: {totalEnergyProduced}";

    // public ShutdownCommand(IList<string> arguments, IEnergyRepository repository, DraftManager manager)
    //     : base(arguments, repository, manager)
    // {
    // }

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController,
       IProviderController providerController)
    : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        //   var sb = new StringBuilder();
        //   sb.AppendLine(ShutDown);
        ////   sb.AppendLine(string.Format(TotalEnergy, totalEnergyProduced));
        //   return sb.ToString().Trim();

        var sb = new StringBuilder();
        sb.AppendLine(Constants.ShutDown);
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalOreProduced, this.harvesterController.OreProduced));

        return sb.ToString();
    }
}

