using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] pond = new char[n,n];

            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < row.Length; j++)
                {
                    pond[i, j] = row[j];
                }
            }
            List<char> branchesChar = new List<char>();
            int collectedBranches = 0;
            string command = Console.ReadLine();
            int branchesLeftInPond = 0;
            while (command != "end")
            {
                branchesLeftInPond = 0;

                int beaverRowPosition = 0;
                int beaverColPosition = 0;
                for (int r = 0; r < pond.GetLength(0); r++)
                {
                    for (int c = 0; c < pond.GetLength(1); c++)
                    {
                        if (pond[r,c] == 'B')
                        {
                            beaverRowPosition = r;
                            beaverColPosition = c;
                            break;
                        }
                        
                    }
                }
                if (command == "up")
                {
                    if (beaverRowPosition - 1 < 0)
                    {

                        if (collectedBranches > 0)
                        {
                            branchesChar.RemoveAt(branchesChar.Count - 1);
                            collectedBranches--;
                        }
                    }

                    else if (char.IsLetter(pond[beaverRowPosition - 1, beaverColPosition]) && char.IsLower(pond[beaverRowPosition - 1, beaverColPosition]))
                    {
                        branchesChar.Add(pond[beaverRowPosition - 1, beaverColPosition]);
                        collectedBranches++;
                        pond[beaverRowPosition, beaverColPosition] = '-';
                        pond[beaverRowPosition - 1, beaverColPosition] = 'B';
                    }
                    else if (pond[beaverRowPosition - 1, beaverColPosition] == 'F')
                    {
                        if (beaverRowPosition - 1 == 0)
                        {
                            pond[beaverRowPosition - 1, beaverColPosition] = '-';

                            for (int i = 1; i < pond.GetLength(0); i++)
                            {

                                if (char.IsLetter(pond[i, beaverColPosition]) && char.IsLower(pond[i, beaverColPosition]))
                                {
                                    branchesChar.Add(pond[i, beaverColPosition]);
                                    collectedBranches++;
                                }
                                pond[i - 1, beaverColPosition] = '-';
                                pond[i, beaverColPosition] = 'B';
                            }
                        }
                    }
                    
                    else
                    {
                        pond[beaverRowPosition - 1, beaverColPosition] = 'B';
                        pond[beaverRowPosition, beaverColPosition] = '-';
                    }
                }
                else if (command == "down")
                {
                    if (beaverRowPosition + 1 > pond.GetLength(0) - 1)
                    {

                        if (collectedBranches > 0)
                        {
                            branchesChar.RemoveAt(branchesChar.Count - 1);
                            collectedBranches--;
                        }
                    }
                    else if (char.IsLetter(pond[beaverRowPosition + 1, beaverColPosition]) && char.IsLower(pond[beaverRowPosition + 1, beaverColPosition]))
                    {
                        branchesChar.Add(pond[beaverRowPosition + 1, beaverColPosition]);
                        collectedBranches++;
                        pond[beaverRowPosition, beaverColPosition] = '-';
                        pond[beaverRowPosition + 1, beaverColPosition] = 'B';
                    }
                    else if (pond[beaverRowPosition + 1, beaverColPosition] == 'F')
                    {
                        if (beaverRowPosition + 1 == pond.GetLength(0) - 1)
                        {
                            pond[beaverRowPosition + 1, beaverColPosition] = '-';

                            for (int i = pond.GetLength(0) - 2; i <= 0; i--)
                            {

                                if (char.IsLetter(pond[i, beaverColPosition]) && char.IsLower(pond[i, beaverColPosition]))
                                {
                                    branchesChar.Add(pond[i, beaverColPosition]);
                                    collectedBranches++;
                                }
                                pond[i + 1, beaverColPosition] = '-';
                                pond[i, beaverColPosition] = 'B';
                            }
                        }
                    }
                    
                    else
                    {
                        pond[beaverRowPosition + 1, beaverColPosition] = 'B';
                        pond[beaverRowPosition, beaverColPosition] = '-';
                    }
                }
                else if (command == "left")
                {
                    if (beaverColPosition - 1 < 0)
                    {

                        if (collectedBranches > 0)
                        {
                            branchesChar.RemoveAt(branchesChar.Count - 1);
                            collectedBranches--;
                        }
                    }

                    else if (char.IsLetter(pond[beaverRowPosition, beaverColPosition - 1]) && char.IsLower(pond[beaverRowPosition, beaverColPosition - 1]))
                    {
                        branchesChar.Add(pond[beaverRowPosition, beaverColPosition - 1]);
                        collectedBranches++;
                        pond[beaverRowPosition, beaverColPosition] = '-';
                        pond[beaverRowPosition, beaverColPosition - 1] = 'B';
                    }
                    else if (pond[beaverRowPosition, beaverColPosition - 1] == 'F')
                    {
                        if (beaverColPosition - 1 == 0)
                        { 
                            pond[beaverRowPosition, beaverColPosition - 1] = '-';

                            for (int i = 1; i < pond.GetLength(1); i++)
                            {

                                if (char.IsLetter(pond[beaverRowPosition, i]) && char.IsLower(pond[beaverRowPosition, i]))
                                {
                                    branchesChar.Add(pond[beaverRowPosition, i]);
                                    collectedBranches++;
                                }
                                pond[beaverRowPosition, i - 1] = '-';
                                pond[beaverRowPosition, i] = 'B';
                            }
                        }
                    }
                    
                    else
                    {
                        pond[beaverRowPosition, beaverColPosition - 1] = 'B';
                        pond[beaverRowPosition, beaverColPosition] = '-';
                    }
                }
                else if (command == "right")
                {
                    if (beaverColPosition + 1 > pond.GetLength(1) - 1)
                    {

                        if (collectedBranches > 0)
                        {
                            branchesChar.RemoveAt(branchesChar.Count - 1);
                            collectedBranches--;
                        }
                        
                    }
                    else if (char.IsLetter(pond[beaverRowPosition, beaverColPosition + 1]) && char.IsLower(pond[beaverRowPosition, beaverColPosition + 1]))
                    {
                        branchesChar.Add(pond[beaverRowPosition, beaverColPosition + 1]);
                        collectedBranches++;
                        pond[beaverRowPosition, beaverColPosition] = '-';
                        pond[beaverRowPosition, beaverColPosition + 1] = 'B';
                    }
                    else if (pond[beaverRowPosition, beaverColPosition + 1] == 'F')
                    {
                        if (beaverColPosition + 1 == pond.GetLength(1) - 1)
                        {
                            pond[beaverRowPosition, beaverColPosition + 1] = '-';

                            for (int i = pond.GetLength(1) - 2; i <= 0; i--)
                            {

                                if (char.IsLetter(pond[beaverRowPosition, i]) && char.IsLower(pond[beaverRowPosition, i]))
                                {
                                    branchesChar.Add(pond[beaverRowPosition, i]);
                                    collectedBranches++;
                                }
                                pond[beaverRowPosition, i + 1] = '-';
                                pond[beaverRowPosition, i] = 'B';
                            }
                        }
                    }
                    
                    else
                    {
                        pond[beaverRowPosition, beaverColPosition + 1] = 'B';
                        pond[beaverRowPosition, beaverColPosition] = '-';
                    }
                }
                // Checking branches count in pond
                for (int r = 0; r < pond.GetLength(0); r++)
                {
                    for (int c = 0; c < pond.GetLength(1); c++)
                    {
                        if (char.IsLetter(pond[r,c]) && char.IsLower(pond[r,c]))
                        {
                            branchesLeftInPond++;
                        }
                    }
                }
                if (branchesLeftInPond == 0)
                {
                    Console.WriteLine($"The Beaver successfully collect {collectedBranches} wood branches: {String.Join(", ", branchesChar)}.");

                    for (int i = 0; i < pond.GetLength(0); i++)
                    {
                        for (int j = 0; j < pond.GetLength(1); j++)
                        {
                            Console.Write(pond[i,j] + " ");
                        }
                        Console.WriteLine();
                    }
                    break;
                }
                command = Console.ReadLine();
            }
            
            if (branchesLeftInPond > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeftInPond} branches left.");
                for (int i = 0; i < pond.GetLength(0); i++)
                {
                    for (int j = 0; j < pond.GetLength(1); j++)
                    {
                        Console.Write(pond[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            
        }
    }
}
