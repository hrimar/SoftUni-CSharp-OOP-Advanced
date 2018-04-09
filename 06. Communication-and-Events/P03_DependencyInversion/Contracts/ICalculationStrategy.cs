using System;
using System.Collections.Generic;
using System.Text;

namespace P03_DependencyInversion.Contracts
{
  public  interface ICalculationStrategy
    {

        int Calculate(int firstOperand, int secondOperand);
    }
}
