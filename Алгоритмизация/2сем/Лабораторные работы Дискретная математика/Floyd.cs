//Алгоритм Флойда

using System;

class Program
{
    public static int[,] Floyd(int[,] matrix)
    {
        int vertices = matrix.GetLength(0);
        
        int[,] weight = (int[,])matrix.Clone();
        
        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (weight[i, k] != int.MaxValue && 
                        weight[k, j] != int.MaxValue && 
                        weight[i, k] + weight[k, j] < weight[i, j])
                    {
                        weight[i, j] = weight[i, k] + weight[k, j];
                    }
                }
            }
        }
        
        return weight;
    }
    
    static void Main()
    {
        int[,] matrix = new int[,]
        {
            { 0, 5, int.MaxValue, 10 },
            { int.MaxValue, 0, 3, int.MaxValue },
            { int.MaxValue, int.MaxValue, 0, 1 },
            { int.MaxValue, int.MaxValue, int.MaxValue, 0 }
        };
        
        
        int[,] shortestPaths = Floyd(matrix);
        
    }
}