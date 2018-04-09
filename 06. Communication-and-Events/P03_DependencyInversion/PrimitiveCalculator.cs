using P03_DependencyInversion.Contracts;
using P03_DependencyInversion.Strategies;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator 
    {
        //private bool isAddition;
        //private AdditionStrategy additionStrategy;
        //private SubtractionStrategy subtractionStrategy;

        private ICalculationStrategy calculationStrategy;

        public PrimitiveCalculator(ICalculationStrategy calculationStrategy)
        {
            //this.additionStrategy = new AdditionStrategy();
            //this.subtractionStrategy = new SubtractionStrategy();
            //this.isAddition = true;

            this.ChangeStrategy(calculationStrategy);
        }

        //public void ChangeStrategy(char @operator)
        //{
        //    switch (@operator)
        //    {
        //        case '+':
        //            this.isAddition = true;
        //            break;
        //        case '-':
        //            this.isAddition = false;
        //            break;
        //    }
        //}
        public void ChangeStrategy(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }

        //public int PerformCalculation(int firstOperand, int secondOperand)
        //{
        //    if (this.isAddition)
        //    {
        //        return additionStrategy.Calculate(firstOperand, secondOperand);
        //    }
        //    else {
        //        return subtractionStrategy.Calculate(firstOperand, secondOperand);
        //    }
        //}
        public int PerformCalculation(int firstOperand, int secondOperand)
        {
         int result =   this.calculationStrategy.Calculate(firstOperand, secondOperand);

            return result;
        }
    }
}
