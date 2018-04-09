using P04.WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce.Employees
{
    public class StandardEmployee : Employee, IEmployee
    {

        public StandardEmployee(string name)
        : base( name, 40) 
        {
            this.Name = name;
        }
    }
}
