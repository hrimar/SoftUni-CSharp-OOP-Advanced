namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;

    using System;

    class AppEntryPoint
    {
         static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //IRepository repository = new UnitRepository();
            //IUnitFactory unitFactory = new UnitFactory();
            //ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            // така  горнит еколекции се правят провайдъри

            return serviceProvider;
        }
    }
}
