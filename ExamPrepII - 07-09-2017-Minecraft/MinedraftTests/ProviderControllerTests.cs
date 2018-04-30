using NUnit.Framework;
//using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

[TestFixture]
public class ProviderControllerTests
{
    private const string expectedString = "Providers are repaired by 200";
    private const string registerProvider = "Successfully registered PressureProvider";

    private ProviderController providerController;
    private EnergyRepository energyRepository;

    [SetUp]
    public void Initialize()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);    
    }

    // 1. Дали се регистрира провайдър:
    // 2. Produce-ва ли се вярна енергия:

    [Test]
    public void ProduceCorrentAmountOfEnergy()
    {
        List<string> provider1 = new List<string>
        {
            "Solar", "1", "100"
        };
        List<string> provider2 = new List<string>
        {
            "Solar", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void ProduceCorrentAmountOfEnergy2()
    {
        List<string> provider1 = new List<string>
        {
            "Solar", "1", "100"
        };
        List<string> provider2 = new List<string>
        {
            "Solar", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

       
        Assert.That(this.providerController.Produce(), Is.EqualTo("Produced 200 energy today!"));
    }

    [Test]
    public void BrokenProviderIsDelete()
    {
        List<string> provider1 = new List<string>
        {
            "Solar", "1", "100"
        };
       
        this.providerController.Register(provider1);
        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(1));
    }

    [Test]
    public void ProvidersGetRepair()
    {
        List<string> provider1 = new List<string>
        {
            "Solar", "1", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Repair(100);

        Assert.That(this.providerController.Entities.First().Durability, Is.EqualTo(1600));
    }
          
    

}

