﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Models
{
    public class Footman : Subordinate
    {

        public Footman(string name)
            : base(name, "panicking")
        {
        }
    }
}
