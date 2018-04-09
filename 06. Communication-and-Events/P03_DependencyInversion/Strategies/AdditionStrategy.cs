using P03_DependencyInversion.Contracts;

namespace P03_DependencyInversion.Strategies
{
	public class AdditionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
