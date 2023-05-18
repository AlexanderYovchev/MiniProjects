using System.Numerics;
using System.Text.RegularExpressions;

public class ChatGPtTasks
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        // We start from the top of the triangle which must be in the middle of the empty matrix.
        int cols = (n * 2);

        int[,] pascalTriangle = new int[n + 1,cols];

        // Variable that will represent the left side of the triangle
        double backwardsY = Math.Ceiling((double)cols / 2);

        // Variable that will represent the right side of the triangle
        double forwardY = Math.Ceiling((double)cols / 2);

        BigInteger sum = 0;

        // Filling the empty matrix with the sides of the isoscele triangle whose index will always be 1.
        for (double x = 0; x < n; x++)
        {
            pascalTriangle[(int)x, (int)backwardsY] = 1;
            pascalTriangle[(int)x, (int)forwardY] = 1;
            
            backwardsY--;
            forwardY++;
        }

        // Filling the inside value of the triangle. Any index that is between two values different from 0, from the previous row is their sum.
        for (int x = 0; x < pascalTriangle.GetLength(0); x++)
        {
            for (int y = 0; y <pascalTriangle.GetLength(1) - 1; y++)
            {
                // Check if the index leaving the boudaries of the matrix
                if (x == 0 || y == 0)
                {
                    continue; ;
                }
                else if (pascalTriangle[x - 1, y - 1] != 0 && pascalTriangle[x - 1, y + 1] != 0)
                {
                    pascalTriangle[x, y] = pascalTriangle[x - 1, y - 1] + pascalTriangle[x - 1, y + 1];
                }
            }
        }

        // the given diagonal starts from the same row as P and P indexes after the middle of the triangle. For every next row, we are moving -1 index on the axisY(column)..
        // to match the diagonal pattern.
        double nextDiagonalIndex = Math.Ceiling((double)(cols / 2) + (p));

        for (int i = p; i < pascalTriangle.GetLength(0); i++)
        {
            if (nextDiagonalIndex == 0)
            {
                break;
            }
            sum += pascalTriangle[i, (int)nextDiagonalIndex];
            nextDiagonalIndex--;
        }

        //(Loop for printing the whole triangle):

        for (int i = 0; i < pascalTriangle.GetLength(0); i++)
        {
            for (int y = 0; y < pascalTriangle.GetLength(1); y++)
            {
                if (pascalTriangle[i, y] == 0)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(pascalTriangle[i, y]);
                }

            }
            Console.WriteLine();
        }

        Console.WriteLine(BigInteger.Abs(sum));
    }
}
