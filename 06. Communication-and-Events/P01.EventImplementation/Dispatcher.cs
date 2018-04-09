using P01.EventImplementation.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.EventImplementation
{





    public class Dispatcher : INameChangable, INamable
    {
        public event NameChangeEventHandler NameChange;


        private string name;

        public Dispatcher(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.OnNameChanged(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public void OnNameChanged(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }

        }
    }
}
