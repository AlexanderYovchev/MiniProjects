using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixSolving
{
    public class MultiplyOperation
    {
        public void MultiplyOperationMethod()
        {
            Console.WriteLine("NOTE! For using this operation the rows of the first matrix must be equal to the cold of the second one" +
                "and the cols of the first matrix must be equal to the rows of the second.");
            Console.WriteLine("EXAMPLE! m*n = n*m");

            Console.WriteLine("Write down how many rows and cols the first matrix have");
            Console.WriteLine("Rows count:");

            int firstMatrixRowsCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Cols count:");
            int firstMatrixColsCount = int.Parse(Console.ReadLine());

            int[,] multidim = new int[firstMatrixRowsCount, firstMatrixColsCount];

            

            Console.WriteLine("Input first matrix!");
            for (int i = 0; i < firstMatrixRowsCount; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < firstMatrixColsCount; j++)
                {
                    multidim[i, j] = row[j];
                }
            }
            // Second Matrix inputs
            Console.WriteLine("Input second matrix!");

            int secondMatrixRowsCount = firstMatrixColsCount;
            int secondMatrixColsCount = firstMatrixRowsCount;

            int[,] multidim2 = new int[secondMatrixRowsCount, secondMatrixColsCount];
            for (int i = 0; i < secondMatrixRowsCount; i++)
            {
                int[] row2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < secondMatrixColsCount; j++)
                {
                    multidim2[i,j] = row2[j];
                }
            }

            int biggerRow = 0;
            int biggerCol = 0;
            int[,] multipliedMultidim = null;

            int positionResult = 0;
            int resultColPosition = 0;
            
            if (firstMatrixRowsCount > secondMatrixRowsCount)
            {
                biggerRow = Math.Max(firstMatrixRowsCount, secondMatrixRowsCount);
                biggerCol = Math.Max(firstMatrixColsCount, secondMatrixColsCount);

                multipliedMultidim = new int[biggerRow, biggerCol];

                for (int h = 0; h < firstMatrixRowsCount; h++)
                {
                    resultColPosition = 0;
                    for (int i = 0; i < secondMatrixColsCount; i++)
                    {
                        for (int j = 0; j < secondMatrixRowsCount; j++)
                        {
                            positionResult += multidim[h, j] * multidim2[j, i];

                        }
                        multipliedMultidim[h, resultColPosition] = positionResult;
                        resultColPosition++;
                        positionResult = 0;
                    }
                }
            }
            else
            {
                multipliedMultidim = new int[firstMatrixRowsCount, secondMatrixColsCount];
                for (int h = 0; h < firstMatrixRowsCount; h++)
                {
                    resultColPosition = 0;
                    for (int i = 0; i < secondMatrixColsCount; i++)
                    {
                        for (int j = 0; j < secondMatrixRowsCount; j++)
                        {
                            positionResult += multidim[h, j] * multidim2[j, i];

                        }
                        multipliedMultidim[h, resultColPosition] = positionResult;
                        resultColPosition++;
                        positionResult = 0;
                    }
                }
            }

            Console.WriteLine("Result.");

            for (int i = 0; i < multipliedMultidim.GetLength(0); i++)
            {
                for (int j = 0; j < multipliedMultidim.GetLength(1); j++)
                {
                    Console.Write("{0} ", multipliedMultidim[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
