using System;
using System.ComponentModel;
using System.Linq.Expressions;

class Program
{

    static void Main()
    {
        
            int n = 6;

            double[,] matrixx = 
        {
            { 0, 7, 8, 0, 0, 0, },
            {7, 0, 11, 2, 0, 0, },
            {8, 11, 0, 6, 0, 9, },
            {0, 2, 6, 0, 9, 11, },
            {0, 0, 0, 9, 0, 10, },
            {0, 0, 9, 11, 10, 0, },
 
        };

            KruskalAlgorithm(matrixx, n);


    }

    static void KruskalAlgorithm(double[,] graph, int n)
    {
        List<int[]> minimumSpanningTree = new List<int[]>();
        double MSTweight = 0;
        Dictionary<int[], double> edgesWeightDictionary = new Dictionary<int[], double>();

        GetWeightEdgesList(graph, edgesWeightDictionary, n);

        var edgesWeightList = edgesWeightDictionary.ToList();
        edgesWeightList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        edgesWeightDictionary = edgesWeightList.ToDictionary();

        Dictionary<int, int> ComponentDictionary = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            ComponentDictionary.Add(i, i);
        }

        bool shouldStopAlgorithm = false;

        foreach(var kvp in edgesWeightDictionary){
            Console.WriteLine($"{kvp.Key[0]}, {kvp.Key[1]}: {kvp.Value}");
        }





        foreach (var edge in edgesWeightDictionary)
        {

            if (ComponentDictionary[edge.Key[0]] != ComponentDictionary[edge.Key[1]])
            {
                int compNum = Math.Min(ComponentDictionary[edge.Key[0]], ComponentDictionary[edge.Key[1]]);
                int compNumForReplace = Math.Max(ComponentDictionary[edge.Key[0]], ComponentDictionary[edge.Key[1]]);

                var keysToUpdate = ComponentDictionary
                                    .Where(kvp => kvp.Value == compNumForReplace)
                                    .Select(kvp => kvp.Key)
                                    .ToList();
                foreach (var key in keysToUpdate)
                {
                    ComponentDictionary[key] = compNum;
                }
                shouldStopAlgorithm = ComponentDictionary.Values.All(v => v == ComponentDictionary[0]);
                
                minimumSpanningTree.Add(edge.Key);
                MSTweight += edge.Value;
            }
            if (shouldStopAlgorithm)
            {
                break;
            }
        }

        foreach(var edge in minimumSpanningTree){
            Console.Write( $"({edge[0]}, {edge[1]}), ");
        }
        Console.WriteLine(
            $"\nДлина MST: {MSTweight}\n"
        );
    }

    static void GetWeightEdgesList(double[,] graph, Dictionary<int[], double> edgesWeightDictionary, int n)
    {

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if(graph[i,j] == 0){
                    continue;
                }else{
                    edgesWeightDictionary.Add(new[] { i, j }, graph[i, j]);
                }
            }
        }
    }
}

