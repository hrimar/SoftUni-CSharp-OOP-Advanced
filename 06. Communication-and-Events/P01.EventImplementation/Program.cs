using System;
using P01.EventImplementation.Contracts;

namespace P01.EventImplementation
{
    class Program
    {
        static void Main() // 100/100
        {
            INameChangable dispatcher = new Dispatcher("Pesho");
            INameChangeHandler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while ((input=Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }

    }
}
