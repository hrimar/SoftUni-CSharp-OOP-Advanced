using P04.WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce.Employees
{
    public class PartTimeEmployee : Employee, IEmployee
    {
        public PartTimeEmployee(string name)
            : base(name, 20)
        {
            this.Name = name;
        }
    }
}
