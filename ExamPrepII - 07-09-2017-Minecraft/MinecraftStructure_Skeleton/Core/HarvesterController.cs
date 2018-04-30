using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterController : IHarvesterController, IController
{
    // Създаваме този клас и взимаме готовата логика от класа DraftManager!!!!!!
       
    private string mode;
    private IEnergyRepository energyRepository;
    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.mode = Constants.DefaultMode;
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = factory;
    }
    

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChange, mode);
    }

    public string Produce()
    {
        //calculate needed energy:
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {           
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        if (this.mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}

