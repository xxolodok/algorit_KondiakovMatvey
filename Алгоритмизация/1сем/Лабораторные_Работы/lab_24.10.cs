using System;
using System.Linq;

class lab
{
    static void Main()
    {

        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        // int m = 4;
        // int n = 5;
        int[,] Matrix = new int[m, n];
        // int[,] Matrix = {
        //     {1,2,3,4,5},
        //     {1,2,3,4,5},
        //     {1,2,3,123,0},
        //     {-1231,-2,-3,-4,0},
        // };

        int[] ArrayIndexs = new int[n];
        int[] ColumnSum = new int[n];
        int Sum = 0;
        int[,] SortMatrix = new int[m, n];

        Random rand = new Random();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Matrix[i, j] = rand.Next(1, 100);
            }
        }

        for (int i = 0; i < n; i++)
        {
            Sum = 0;

            for (int j = 0; j < m; j++)
            {

                Sum += Matrix[j, i];

            }
            ColumnSum[i] = Sum;


        }

        for (int i = 0; i < n; i++)
        {
            ArrayIndexs[i] = i;
        }

        Array.Sort(ColumnSum, ArrayIndexs);


        for (int j = 0; j < n; j++)
        {
            int sortedColumnIndex = ArrayIndexs[j];
            for (int i = 0; i < m; i++)
            {
                SortMatrix[i, j] = Matrix[i, sortedColumnIndex];
            }
        }

        Console.WriteLine("");
        Console.WriteLine("До сортировки");
        PrintDoubleMatrix(Matrix);
        Console.WriteLine("");
        Console.WriteLine("После сортировки");
        PrintDoubleMatrix(SortMatrix);

        Console.WriteLine("\n\nПары строк, состоящие из одинаковых элементов: ");

        int[] uniqueArr;
        int[] uniqueArr2;

        int countEqualElements = 0;



        for (int i = 0; i < m; i++)
        {

            uniqueArr = new int[n];

            for (int o = 0; o < n; o++)
            {
                uniqueArr[o] = Matrix[i, o];
            }
            uniqueArr = uniqueArr.Distinct().ToArray();
            Array.Sort(uniqueArr);


            for (int j = 0; j < m; j++)
            {
                if (i == j)
                {
                    continue;
                }
                uniqueArr2 = new int[n];
                for (int o = 0; o < n; o++)
                {
                    uniqueArr2[o] = Matrix[j, o];
                }
                uniqueArr2 = uniqueArr2.Distinct().ToArray();
                Array.Sort(uniqueArr2);




                if (uniqueArr.Length != uniqueArr2.Length)
                {
                    continue;
                }
                else
                {
                    for (int o = 0; o < uniqueArr.Length; o++)
                    {
                        if (uniqueArr[o] == uniqueArr2[o])
                        {
                            countEqualElements++;
                        }
                    }
                    if (countEqualElements == uniqueArr.Length)
                    {
                        if (i <= j)
                        {
                            Console.WriteLine($"({i}, {j})");
                        }
                    }
                }
                countEqualElements = 0;

            }
        }
        int[] row;
        int[] rowIndexes = new int[n];
        int[] col;
        int[] colIndexes = new int[m];

        int[,] colMaxIndex = new int[n, 2];
        int[,] colMinIndex = new int[n, 2];

        int[,] rowMaxIndex = new int[m, 2];
        int[,] rowMinIndex = new int[m, 2];

        for (int i = 0; i < n; i++)
        {
            rowIndexes[i] = i;
        }
        for (int i = 0; i < m; i++)
        {
            colIndexes[i] = i;
        }

        for (int i = 0; i < m; i++)
        {
            row = new int[n];
            for (int o = 0; o < n; o++)
            {
                row[o] = Matrix[i, o];
            }
            int minIndex = Array.IndexOf(row, row.Min());
            rowMinIndex[i, 0] = i;
            rowMinIndex[i, 1] = minIndex;

        }


        for (int i = 0; i < n; i++)
        {
            col = new int[m];
            for (int o = 0; o < m; o++)
            {
                col[o] = Matrix[o, i];
            }
            int maxIndex = Array.IndexOf(col, col.Max());
            colMaxIndex[i, 0] = maxIndex;
            colMaxIndex[i, 1] = i;
        }


        Console.WriteLine("Положение минимального в строке, максимального в столбце:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (colMaxIndex[i, 0] == rowMinIndex[j, 0] && colMaxIndex[i, 1] == rowMinIndex[j, 1])
                {
                    Console.WriteLine($"({colMaxIndex[i, 0]}, {colMaxIndex[i, 1]})");
                }
            }
        }


        for (int i = 0; i < m; i++)
        {
            row = new int[n];
            for (int o = 0; o < n; o++)
            {
                row[o] = Matrix[i, o];
            }
            int maxIndex = Array.IndexOf(row, row.Max());
            rowMaxIndex[i, 0] = i;
            rowMaxIndex[i, 1] = maxIndex;

        }


        for (int i = 0; i < n; i++)
        {
            col = new int[m];
            for (int o = 0; o < m; o++)
            {
                col[o] = Matrix[o, i];
            }
            int minIndex = Array.IndexOf(col, col.Min());
            colMinIndex[i, 0] = minIndex;
            colMinIndex[i, 1] = i;
        }

        Console.WriteLine("Положение максимального в строке, минимального в столбце:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (colMinIndex[i, 0] == rowMaxIndex[j, 0] && colMinIndex[i, 1] == rowMaxIndex[j, 1])
                {
                    Console.WriteLine($"({rowMaxIndex[j, 0]}, {rowMaxIndex[j, 1]})");
                }
            }
        }
    }




    static void PrintDoubleMatrix(int[,] matrix)
    {

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            Console.Write("| ");

            for (int j = 0; j < cols; j++)
            {

                Console.Write(matrix[i, j] + "\t");
            }
            Console.Write(" |");

            Console.WriteLine();
        }
    }


}


