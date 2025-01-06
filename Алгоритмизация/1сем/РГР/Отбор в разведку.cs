using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение количества солдат из файла
        int N = int.Parse(File.ReadAllText("input_s1_01.txt").Trim());
        int result = CountGroups(N);
        Console.WriteLine(result);
    }

    static int CountGroups(int N)
    {
        // Если солдат меньше 3, группы не сформировать
        if (N < 3)
        {
            return 0;
        }
        // Если ровно 3 солдата, можно сформировать одну группу
        if (N == 3)
        {
            return 1;
        }

        // Используем массив для хранения результатов
        int[] groups = new int[N + 1];
        groups[3] = 1; // 1 группа для 3 солдат

        // Заполнение массива для всех значений до N
        for (int i = 4; i <= N; i++)
        {
            groups[i] = groups[i / 2] + groups[i - i / 2];
        }

        return groups[N];
    }
}
