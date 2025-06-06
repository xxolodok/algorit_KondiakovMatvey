using System;
using System.ComponentModel;
using System.Linq.Expressions;

class Program
{

    static void Main()
    {
        string[][] testInputData = {
            new string[] { "2", "15 15", "500 500" },
            new string[] { "3", "100 100", "200 200", "100 200" },
            new string[] { "4", "50 50", "50 450", "450 50", "450 450" },
            new string[] { "5", "123 456", "234 345", "345 234", "456 123", "150 150" },
            new string[] { "6", "200 200", "210 210", "220 220", "230 230", "240 240", "250 250" },
            };

        foreach (string[] s in testInputData)
        {
            int n = Convert.ToInt32(s[0]);
            double[,] graph = CreategraphMatrix(s, n); ;

            KruskalAlgorithm(graph,s,  n);


            
        }


    }

    static void KruskalAlgorithm(double[,] graph,string[] s, int n)
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
        Console.Write( $"Координаты домов, между которыми надо провести связь: \n");

        foreach(var edge in minimumSpanningTree){
            Console.Write( $"({s[edge[0]+1]}) - ({s[edge[1]+1]}),\n");
        }
        Console.WriteLine(
            $"\nМинимальная длина веревки для телефона: {Math.Round(MSTweight, 2)}\n"
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
                }            }
        }
    }
    static double[,] CreategraphMatrix(string[] InputData, int n)
    {
        double[,] graph = new double[n, n];

        for (int i = 1; i < n + 1; i++)
        {
            for (int j = 1; j < n + 1; j++)
            {

                string[] PointCoordinatesfirst = InputData[i].Split(" ");
                string[] PointCoordinatessecond = InputData[j].Split(" ");

                double ropeLenght = Math.Sqrt(Math.Pow(Convert.ToInt32(PointCoordinatesfirst[0]) - Convert.ToInt32(PointCoordinatessecond[0]), 2) + Math.Pow(Convert.ToInt32(PointCoordinatesfirst[1]) - Convert.ToInt32(PointCoordinatessecond[1]), 2));

                graph[i - 1, j - 1] = ropeLenght;
            }
        }
        return graph;
    }
}

