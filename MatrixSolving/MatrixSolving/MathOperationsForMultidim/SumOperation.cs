using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixSolving.MathOperationsForMultidim
{
    public class SumOperation
    {
        public void SumOperationMethod()
        {
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
            Console.WriteLine("Input second matrix!");

            int[,] multidim2 = new int[firstMatrixRowsCount, firstMatrixColsCount];
            for (int i = 0; i < firstMatrixRowsCount; i++)
            {
                int[] row2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < firstMatrixColsCount; j++)
                {
                    multidim2[i, j] = row2[j];
                }
            }

            int[,] summedMultidim = new int[firstMatrixRowsCount, firstMatrixColsCount];

            for (int i = 0; i < firstMatrixRowsCount; i++)
            {

                for (int j = 0; j < firstMatrixColsCount; j++)
                {
                    summedMultidim[i, j] = multidim[i, j] + multidim2[i, j];
                }
            }

            Console.WriteLine("Result.");

            for (int i = 0; i < summedMultidim.GetLength(0); i++)
            {
                for (int j = 0; j < summedMultidim.GetLength(1); j++)
                {
                    Console.Write("{0} ", summedMultidim[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
