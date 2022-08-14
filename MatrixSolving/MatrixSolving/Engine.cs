using System;
using System.Linq;
using MatrixSolving.MathOperationsForMultidim;

namespace MatrixSolving
{
    public class Engine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write down the operation you want to use:\nChoices: Addition, Subtraction, Multiplication");
            string chosenOperation = Console.ReadLine();

            if (chosenOperation == "Addition")
            {
                SumOperation sumOperation = new SumOperation();
                sumOperation.SumOperationMethod();
            }
            else if (chosenOperation == "Multiplication")
            {
                MultiplyOperation multiplyOperation = new MultiplyOperation();
                multiplyOperation.MultiplyOperationMethod();
            }
            else if (chosenOperation == "Subtraction")
            {
                SubtractOperation subtractOperation = new SubtractOperation();
                subtractOperation.SubtractOperationMethod();
            }
            else
            {
                try
                {
                    throw new InvalidOperationException("Invalid operation!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                
            }
        }
    }
}
