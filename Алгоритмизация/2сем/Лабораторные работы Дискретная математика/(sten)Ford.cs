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

        FordAlgorithm(matrix, n);


    }
    static void FordAlgorithm(int[,] matrix, int n)
    {
        int inf = int.MaxValue;
        int startVertex = 1;

        Dictionary<int, int[]> shortestPaths = new();
        Dictionary<int, bool> VertexPathUpd = new();

        for (int i = 0; i < n; i++)
        {
            shortestPaths[i] = i == startVertex ? new int[] { 0, -1 } : new int[] { inf, -1 };
            VertexPathUpd[i] = false;
        }

        for (int k = 0; k < n - 1; k++)
        {
            bool updated = false;
            for (int u = 0; u < n; u++)
            {
                for (int v = 0; v < n; v++)
                {
                    if (matrix[u, v] != 0 && shortestPaths[u][0] != inf)
                    {
                        int newDist = shortestPaths[u][0] + matrix[u, v];
                        if (newDist < shortestPaths[v][0])
                        {
                            shortestPaths[v] = new int[] { newDist, u };
                            updated = true;
                        }
                    }
                }
            }
            if (!updated) break;
        }

        for (int u = 0; u < n; u++)
        {
            for (int v = 0; v < n; v++)
            {
                if (matrix[u, v] != 0 && shortestPaths[u][0] != inf &&
                    shortestPaths[u][0] + matrix[u, v] < shortestPaths[v][0])
                {
                    Console.WriteLine("Обнаружен цикл отрицательного веса!");
                    return;
                }
            }
        }

    }
}
