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

        DijcstraAlgorithm(matrix, n);


    }
    static void DijcstraAlgorithm(int[,] matrix, int n)
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

        
        while (currentVert.Count != n)
{
    Dictionary<int, int[]> updates = new Dictionary<int, int[]>();

    foreach (int vertex in currentVert)
    {
        for (int i = 0; i < n; i++)
        {
            if (matrix[vertex, i] == 0 || currentVert.Contains(i))
                continue;

            int newDistance = (MST[vertex][0] == int.MaxValue) 
                ? int.MaxValue 
                : MST[vertex][0] + matrix[vertex, i];

            if (newDistance < MST[i][0])
            {
                updates[i] = new int[] { newDistance, vertex };
            }
        }
    }

    foreach (var update in updates)
    {
        MST[update.Key] = update.Value;
    }

    int minWeight = int.MaxValue;
    int minKey = -1;

    for (int i = 0; i < n; i++)
    {
        if (!currentVert.Contains(i) && MST[i][0] < minWeight)
        {
            minWeight = MST[i][0];
            minKey = i;
        }
    }

    if (minKey != -1)
    {
        currentVert.Add(minKey);
    }
    else
    {
        break; 
    }
}

            foreach (var kvp in MST)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value[0]} {kvp.Value[1]}");
            }
        }
    }
