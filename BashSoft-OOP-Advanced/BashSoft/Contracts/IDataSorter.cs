﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Contracts
{
    public interface IDataSorter
    {
        void OrderAndTake(IDictionary<string, double> studentsMarks, string comparison, int studentsToTake);
    }
}
