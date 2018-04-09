using System;
using System.Collections.Generic;
using System.Text;

namespace P01.EventImplementation.Contracts
{

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public interface INameChangable 
    {
        string Name { get; set; }

        event NameChangeEventHandler NameChange;

        void OnNameChanged(NameChangeEventArgs args);
    }
}
