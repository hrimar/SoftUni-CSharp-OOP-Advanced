using System;
using System.Collections.Generic;
using System.Text;
using P01.EventImplementation.Contracts;

namespace P01.EventImplementation
{
    public class Handler : INameChangeHandler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"{sender.GetType().Name}'s name changed to {args.Name}.");
        }
    }
}
