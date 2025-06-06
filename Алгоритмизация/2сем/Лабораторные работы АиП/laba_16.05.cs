using System;

class Program
{
    static unsafe void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        int.TryParse(Console.ReadLine(), out int n);

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i}: ");
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                Console.Write($"Введите элемент {i}: ");
            }
        }

        int countEven = 0;

        fixed (int* p = array)
        {
            for (int i = 0; i < n; i++)
            {
                if (*(p + i) % 2 == 0)
                    countEven++;
            }
        }

        Console.WriteLine($"Количество элементов, кратных двум: {countEven}");
    }
}
