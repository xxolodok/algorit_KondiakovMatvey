using System;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        int m = 6;
        int n = 6;

        int[,] matrixx = new int[6, 6]
        {
            { 0, 7, 8, 0, 0, 0 },
            { 7, 0, 11, 2, 0, 0 },
            { 8, 11, 0, 6, 9, 0 },
            { 0, 2, 6, 0, 11, 9 },
            { 0, 0, 9, 11, 0, 10 },
            { 0, 0, 8, 9, 10, 0 }
        };

        string[] Edges = new string[100];
        int[] Weight = new int[100];
        int count = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (matrixx[i, j] != 0)
                {
                    Edges[count] = $"{i}{j}";
                    Weight[count] = matrixx[i, j];
                    count++;
                }
            }
        }

        string[] AllEdges = new string[count];
        int[] AllWeight = new int[count];

        for (int i = 0; i < count; i++)
        {
            AllEdges[i] = Edges[i];
            AllWeight[i] = Weight[i];
        }

        
        Array.Sort(AllWeight, AllEdges);
        
        char[] ExistEdges = new char[count * 2];
        bool EdgesExist = false;
        int countExistEdges = 0;
        int totalWeight = 0;
        int countWG = 0;
        foreach (string s in AllEdges)
        {
            Console.WriteLine("Rebro: " + s);
            foreach (char c in s)
            {
                Console.WriteLine($"{c}, ");
                for (int i = 0; i < countExistEdges; i++)
                {
                    if (ExistEdges[i] == c)
                    {
                        EdgesExist = true;
                        Console.WriteLine("s  = 77");
                        break;
                    }
                }
                if (EdgesExist == true)
                {
                    EdgesExist = false;
                    Console.WriteLine("s  = 83");

                    continue;
                }
                else
                {
                    ExistEdges[countExistEdges] = c;
                    countExistEdges++;
                    Console.WriteLine("s  = 89");
                    totalWeight += Convert.ToInt32(AllWeight[countWG]);
                    EdgesExist = false;
                    Console.WriteLine("TotalWeiaght: " + countWG);
                    for (int i = 0; i < countExistEdges; i++)
                    {
                        Console.Write($"{ExistEdges[i]}, ");
                    }
                    break;
                }

            }
            countWG++;
        }

        Console.WriteLine("TotalWeiaght: " + countWG);
        for (int i = 0; i < countExistEdges; i++)
        {
            Console.Write($"{ExistEdges[i]}, ");
        }
    }

    static bool IsExistVertex()
    {

        return false;
    }



}
