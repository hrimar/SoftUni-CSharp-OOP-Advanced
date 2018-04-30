//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//public class DraftManager
//{
//    private const string SuccesfullRehisteredHarvester = "Successfully registered {0}Harvester";
//    private const string SuccesfullRehisteredProvider = "Successfully registered {0}Provider";
//    private const string Full = "Full";
//    private const string Half= "Half";
//    private const string Energy =  "Energy";
//    private const string PassedDay = "A day has passed.";
//    private const string EnergyProvided = "Energy Provided: {producedPower}";
//    private const string PlumbusOreMined = "Plumbus Ore Mined: {minedOres}";
//    private const string SuccessChangedWorkingMode = "Mode changed to {0}!"; //"Successfully changed working mode to {0} Mode";
//    private const string NoElement = "No element found with id - {id}";
//    private const string SystemShutdown = "System Shutdown";
//    private const string  TotalEnergyStored = "Total Energy Stored: {0}";
//    private const string TotalMinedOre = "Total Mined Plumbus Ore: {0}";

//    // взимаме готовата логика от класа DraftManager и създаваме HarvesterController и CommandInterpreter 
//    // а този клас става излишен!!!!!!!

//    private double totalStoredEnergy;
//    private double totalMinedOre;
//    private Dictionary<string, IHarvester> harvestersById;
//    private Dictionary<string, IProvider> providersById;
//    private IHarvesterFactory harvesterFactory;
//    private IProviderFactory providerFactory;

//    public DraftManager(IHarvesterFactory harvesterFactory, IProviderFactory providerFactory)
//    {
//       // this.mode = "Full";
//        this.totalMinedOre = 0;
//        this.totalStoredEnergy = 0;
//        this.harvestersById = new Dictionary<string, IHarvester>();
//        this.providersById = new Dictionary<string, IProvider>();
//        this.harvesterFactory = harvesterFactory;
//        this.providerFactory = providerFactory;
//    }

//    //public string RegisterHarvester(List<string> arguments)
//    //{
//    //    arguments = new List<string>(arguments.Skip(1).ToList());
//    //    var type = arguments[0];
//    //    var id = arguments[1];
//    //    var oreOutput = double.Parse(arguments[2]);
//    //    var energyRequirement = double.Parse(arguments[3]);
//    //    var sonicFactor = 0;
//    //    if (arguments.Count == 5)
//    //    {
//    //        sonicFactor = int.Parse(arguments[4]);
//    //    }

//    //    try
//    //    {
//    //        IHarvester harvester = harvesterFactory.GenerateHarvester(arguments);
//    //        this.harvestersById.Add(id, harvester);
//    //    }
//    //    catch (ArgumentException e)
//    //    {
//    //        return e.Message;
//    //    }

//    //    return string.Format(SuccesfullRehisteredHarvester, type);
//    //}

//    //public string RegisterProvider(List<string> arguments)
//    //{
//    //    arguments = new List<string>(arguments.Skip(1).ToList());
//    //    var type = arguments[0];
//    //    var id = arguments[1];
//    //    var energyOutput = int.Parse(arguments[2]);

//    //    try
//    //    {
//    //       // IProviderFactory fac = new ProviderFactory();//
//    //        IProvider provider = this.providerFactory.GenerateProvider(arguments);
//    //        this.providersById.Add(id, provider);
//    //    }
//    //    catch (ArgumentException e)
//    //    {
//    //        return e.Message;
//    //    }

//    //    return string.Format(SuccesfullRehisteredProvider, type);
//    //}

//    //public string Day()
//    //{
//    //    //calculate provided power for the day
//    //    double producedPower = 0;
//    //    foreach (var provider in this.providersById)
//    //    {
//    //        producedPower += provider.Value.EnergyOutput;
//    //    }

//    //    //add to the total energy
//    //    this.totalStoredEnergy += producedPower;



//    //    //sb.AppendLine(string.Format(Constants.EnergyOutputToday, totalStoredEnergy));
//    //    //sb.AppendLine(string.Format(Constants.OreOutputToday, minedOres));
//    //    //       return sb.ToString().Trim();
//    //    return "";
//    //}

//    //public string Mode(List<string> arguments)
//    //{
//    //    var mode = arguments[0];
//    //    this.mode = mode;

//    //    return string.Format(SuccessChangedWorkingMode, mode);
//    //}

//    //public string Check(List<string> arguments)
//    //{
//    //    var id = arguments[0];
//    //    var sb = new StringBuilder();
//    //    if (this.providersById.ContainsKey(id))
//    //    {
//    //        sb.AppendLine(providersById[id].ToString());
//    //    }
//    //    if (this.harvestersById.ContainsKey(id))
//    //    {
//    //        sb.AppendLine(harvestersById[id].ToString());
//    //    }
//    //    if (string.IsNullOrWhiteSpace(sb.ToString()))
//    //    {
//    //        sb.AppendLine(string.Format(NoElement, id));
//    //    }

//    //    return sb.ToString().Trim();
//    //}

//    //public string ShutDown()
//    //{
//    //    var sb = new StringBuilder();
//    //    sb.AppendLine(SystemShutdown);
//    //    sb.AppendLine(string.Format(TotalEnergyStored, this.totalStoredEnergy));
//    //    sb.Append(string.Format(TotalMinedOre, this.totalMinedOre));

//    //    return sb.ToString();
//    //}

//}
