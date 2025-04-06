using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

class Program
{

    static void Main()
    {

        int n = 6;

        int[,] matrix =
    {
            { 0, 7, 8, 0, 0, 0, },
            {7, 0, 11, 2, 0, 0, },
            {8, 11, 0, 6, 0, 9, },
            {0, 2, 6, 0, 9, 11, },
            {0, 0, 0, 9, 0, 10, },
            {0, 0, 9, 11, 10, 0, },

        };

        PrimAlgorithm(matrix, n);


    }
    static void PrimAlgorithm(int[,] matrix, int n)
    {

        int inf = int.MaxValue;
        int startVertex = 0;
        List<int> currentVert = new() { startVertex };

        Dictionary<int, int[]> MST = new();

        for (int i = 0; i < n; i++)
        {
            if (i == startVertex)
            {
                int[] weightEdge = { 0, startVertex };
                MST.Add(i, weightEdge);
            }
            else
            {
                int[] weightEdge = { inf, -1 };

                MST.Add(i, weightEdge);
            }
        }
        while (currentVert.Count() != n)
        {
            for (int i = 0; i < n; i++)
            {
                if (matrix[currentVert.Last(), i] == 0)
                {
                    continue;
                }
                if (matrix[currentVert.Last(), i] < MST[i][0])
                {
                    int[] Edge = { matrix[currentVert.Last(), i], currentVert.Last() };
                    MST[i] = Edge;
                }


            }

            int minWeight = int.MaxValue;
            int minKey = -1;

            foreach (var pair in MST)
            {
                if (pair.Value[0] < minWeight && !currentVert.Contains(pair.Key))
                {
                    minWeight = pair.Value[0];
                    minKey = pair.Key;
                }
            }

            if (minKey != -1)
            {
                currentVert.Add(minKey);
            }

            foreach (var kvp in MST)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value[0]} {kvp.Value[1]}");
            }
        }
    }
}