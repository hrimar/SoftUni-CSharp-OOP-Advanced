namespace Forum.App
{
	using System;

	using Microsoft.Extensions.DependencyInjection;

	using Contracts;
	using Factories;
    using Forum.Data;
    using Forum.App.Models;
    using Forum.App.Services;

    public class StartUp
	{
		public static void Main()
		{
            //IMainController menu = new MenuController(new LabelFactory(), new ForumViewEngine());

            IServiceProvider serviceProvider = ConfigureServices();
            IMainController menu = serviceProvider.GetService<IMainController>();// подава се в MenuController

            Engine engine = new Engine(menu);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices() // za DependencyInjection Container
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ITextAreaFactory, TextAreaFactory>();
            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IMenuFactory, MenuFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();

            services.AddSingleton<ForumData>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUserService, UserService>();

            services.AddSingleton<ISession, Session>();
            services.AddSingleton<IForumViewEngine, ForumViewEngine>();
            services.AddSingleton<IMainController, MenuController>();

            services.AddTransient<IForumReader, ForumConsoleReader>();

            // Билдваме serviceProvider:
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
	}
}
