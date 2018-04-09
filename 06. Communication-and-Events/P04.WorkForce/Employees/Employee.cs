using P04.WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce.Employees
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; protected set; }

        public int WorkHoursPerWeek { get; private set; }

        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }
    }
}
