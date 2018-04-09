using P03_DependencyInversion.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DependencyInversion.Strategies
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
