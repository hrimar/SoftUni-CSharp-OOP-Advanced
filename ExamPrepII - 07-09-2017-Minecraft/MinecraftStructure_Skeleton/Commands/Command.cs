using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Command : ICommand
{
    // private IEnergyRepository repository;
    // private DraftManager manager;
    //// private List<IProvider> providers;

    // public Command(IList<string> arguments, IEnergyRepository repository, DraftManager manager) 
    //     //List<IProvider> providers)
    // {
    //     this.Arguments = arguments;
    //     this.Repository = repository;
    //     this.Manager = manager;
    //    // this.providers = providers;
    // }

  // Целта тук е всяка команда да държи само това депенънци, което и трябва на нея!!!!
  // В моя вариант не бях го направил така
    protected Command(IList<string> arguments)
    {
        this.Arguments = arguments;        
    }

    public IList<string> Arguments { get; protected set; }
    //public DraftManager Manager { get => manager; private set => manager = value; }
    //public IEnergyRepository Repository { get => repository; set => repository = value; }

    public abstract string Execute();
}

