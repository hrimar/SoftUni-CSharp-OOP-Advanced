public class Program
{
    public static void Main()
    {
        // Идеята на това решение е вземайки двата контролера HarvesterController и ProviderController
        // и вкарвайки ги като полета (един от тих илии двата) в командите,
        // ползвайки техните методи да достъпваме всичко необходимо ни в работата, вместо
        // да подавам евсички дипендънсита като полета на всяка команда!!!!!!!!!!!


                // Structure - 250/250; IO - error; 
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IProviderFactory providerFactory = new ProviderFactory();
        IEnergyRepository energyRepository = new EnergyRepository();
       // DraftManager manager = new DraftManager(harvesterFactory, providerFactory);

        //ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterFactory, providerFactory,
        //       repository, manager);
        IHarvesterController harvesterController = new HarvesterController(energyRepository, harvesterFactory);
        IProviderController providerController = new ProviderController(energyRepository);
        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        IWriter writer =new Writer();
        IReader reader= new Reader();

       // Engine engine = new Engine(harvesterFactory, providerFactory, repository, commandInterpreter, writer, reader);
        Engine engine = new Engine(commandInterpreter, writer, reader);

        engine.Run();
    }
}