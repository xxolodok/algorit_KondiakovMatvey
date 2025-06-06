using System;
using System.Collections.Generic;
using System.Linq;

class LittleAlgorithmRightBranch
{
    private int[,] costMatrix;
    private int size;
    private List<int> bestPath;
    private int bestCost = int.MaxValue;

    public void Solve(int[,] matrix)
    {
        costMatrix = (int[,])matrix.Clone();
        size = matrix.GetLength(0);
        bestPath = new List<int>();

        // Начальная редукция матрицы
        int initialReduction = ReduceMatrix(costMatrix);
        BranchAndBound(0, new List<int> { 0 }, initialReduction, costMatrix);

        Console.WriteLine($"Оптимальный путь: {string.Join(" -> ", bestPath)}");
        Console.WriteLine($"Минимальная стоимость: {bestCost}");
    }

    private void BranchAndBound(int currentCost, List<int> path, int lowerBound, int[,] matrix)
    {
        if (path.Count == size)
        {
            // Проверяем возможность вернуться в начальный город
            int returnCost = matrix[path.Last(), path[0]];
            if (returnCost != int.MaxValue)
            {
                int totalCost = currentCost + returnCost;
                if (totalCost < bestCost)
                {
                    bestCost = totalCost;
                    bestPath = new List<int>(path) { path[0] };
                }
            }
            return;
        }

        int lastCity = path.Last();
        var nextCities = GetNextCities(lastCity, path, matrix);

        // Сортируем города по возрастанию стоимости перехода
        var sortedCities = nextCities.OrderBy(pair => pair.Value).ToList();

        // Рассматриваем только первый (правую ветвь)
        if (sortedCities.Count > 0)
        {
            var (nextCity, cost) = sortedCities[0];
            int[,] newMatrix = (int[,])matrix.Clone();
            UpdateMatrix(newMatrix, lastCity, nextCity);

            int reduction = ReduceMatrix(newMatrix);
            int newLowerBound = currentCost + cost + reduction;

            if (newLowerBound < bestCost)
            {
                path.Add(nextCity);
                BranchAndBound(currentCost + cost, path, newLowerBound, newMatrix);
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    private Dictionary<int, int> GetNextCities(int fromCity, List<int> path, int[,] matrix)
    {
        var cities = new Dictionary<int, int>();
        for (int toCity = 0; toCity < size; toCity++)
        {
            if (!path.Contains(toCity) && matrix[fromCity, toCity] != int.MaxValue)
            {
                cities[toCity] = matrix[fromCity, toCity];
            }
        }
        return cities;
    }

    private int ReduceMatrix(int[,] matrix)
    {
        int reduction = 0;

        // Редукция строк
        for (int i = 0; i < size; i++)
        {
            int min = int.MaxValue;
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] < min) min = matrix[i, j];
            }

            if (min != int.MaxValue && min != 0)
            {
                reduction += min;
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] != int.MaxValue) matrix[i, j] -= min;
                }
            }
        }

        // Редукция столбцов
        for (int j = 0; j < size; j++)
        {
            int min = int.MaxValue;
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, j] < min) min = matrix[i, j];
            }

            if (min != int.MaxValue && min != 0)
            {
                reduction += min;
                for (int i = 0; i < size; i++)
                {
                    if (matrix[i, j] != int.MaxValue) matrix[i, j] -= min;
                }
            }
        }

        return reduction;
    }

    private void UpdateMatrix(int[,] matrix, int from, int to)
    {
        // Запрещаем обратный переход
        matrix[to, from] = int.MaxValue;

        // Запрещаем все переходы из from и в to
        for (int i = 0; i < size; i++)
        {
            matrix[from, i] = int.MaxValue;
            matrix[i, to] = int.MaxValue;
        }
    }
}

class Program
{
    static void Main()
    {
        // Пример матрицы стоимостей (int.MaxValue означает отсутствие пути)
        int[,] costMatrix = {
            { int.MaxValue, 20, 30, 10, 11 },
            { 15, int.MaxValue, 16, 4, 2 },
            { 3, 5, int.MaxValue, 2, 4 },
            { 19, 6, 18, int.MaxValue, 3 },
            { 16, 4, 7, 16, int.MaxValue }
        };

        var solver = new LittleAlgorithmRightBranch();
        solver.Solve(costMatrix);
    }
}