using System;

class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите количество строк: ");
        if (!int.TryParse(Console.ReadLine(), out int numberOfLines) || numberOfLines <= 0)
        {
            return;
        }

        int* frequency = stackalloc int[256];
        for (int i = 0; i < 256; i++)
        {
            frequency[i] = 0;
        }

        // Считываем строки и обновляем частоты
        for (int line = 0; line < numberOfLines; line++)
        {
            Console.Write($"Введите строку {line + 1}: ");
            string input = Console.ReadLine();

            for (int j = 0; j < input.Length; j++)
            {
                byte b = (byte)input[j];
                frequency[b]++;
            }
        }

        int minFrequency = int.MaxValue;
        int maxFrequency = int.MinValue;

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] > 0)
            {
                if (frequency[i] < minFrequency)
                    minFrequency = frequency[i];
                if (frequency[i] > maxFrequency)
                    maxFrequency = frequency[i];
            }
        }

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] == minFrequency)
            {
                Console.WriteLine((char)i);
            }
        }

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] == maxFrequency)
            {
                Console.WriteLine((char)i);
            }
        }
    }
}
