using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type menuType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new ArgumentException($"{menuName} not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType)) 
            {
                throw new InvalidOperationException($"{menuName} is not a menu!");
            }

            // за взимане на парамс на ctor-a
            ConstructorInfo constructor = menuType.GetConstructors().First();
            ParameterInfo[] ctorParams = constructor.GetParameters(); // !!
            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType); 
            }


            IMenu command = (IMenu)Activator.CreateInstance(menuType, args);

            return command;

        }
    }
}
