﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce.Contracts
{
  public  interface IEmployee
    {

        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}
