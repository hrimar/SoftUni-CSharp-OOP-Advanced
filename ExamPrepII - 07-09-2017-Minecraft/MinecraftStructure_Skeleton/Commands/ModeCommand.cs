using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModeCommand : Command
{
    //public ModeCommand(IList<string> arguments, IEnergyRepository repository, DraftManager manager)
    //    : base(arguments, repository, manager)
    //{
    //}

    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string mode = this.Arguments[0];

        string result = this.harvesterController.ChangeMode(mode);
        return result;

      //var  args = new List<string>(Arguments.Skip(1).ToList());
      //  return        this.Manager.Mode(args);
    }
}

