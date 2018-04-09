using P03_DependencyInversion.Contracts;
using P03_DependencyInversion.Strategies;
using System;

namespace P03_DependencyInversion
{
    class Program
    {
        static void Main()   // 100/100 - Пример за DependencyInversion с ctor Injection!!!
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy()); // default strategy!

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "mode")
                {
                    char @operator = tokens[1][0];

                    ICalculationStrategy strategy = null;

                    switch (@operator)
                    {
                        case '+':
                            strategy = new AdditionStrategy();
                            break;
                        case '-':
                            strategy = new SubtractionStrategy();
                            break;
                        case '*':
                            strategy = new MultyplicationStrategy();
                            break;
                        case '/':
                            strategy = new DivisionStrategy();
                            break;
                    }

                    if (strategy == null)
                    {
                        throw new ArgumentException("Inavalid mode!");
                    }

                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(tokens[0]);
                    int secondOperand = int.Parse(tokens[1]);

                    int result = calculator.PerformCalculation(firstOperand, secondOperand);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
