using System;



class lab
{
    static void Main()
    {
        string str = Console.ReadLine();
        int countAnB = 0;
        int currentLength = 0;
        int currentMax = 0;
        int maxLength = 0; while (true)
        {
            if (string.IsNullOrEmpty(str))
            {
                break;
            }
            for (int i = 0; i < str.Length - 2; i++)
            {
                if ($"{str[i]}" == "a" && $"{str[i + 2]}" == "b")
                {
                    countAnB++;
                }
            }



            foreach (char c in str)
            {
                if (char.ToLower(c) == 'a' || char.ToLower(c) == 'b' || char.ToLower(c) == 'c')
                {
                    currentLength++;
                    currentMax = Math.Max(currentMax, currentLength);
                }
                else
                {
                    currentLength = 0; // Сброс длины, если символ не a, b или c
                }
                maxLength = Math.Max(maxLength, currentMax); // Обновление максимальной длины

            }
            str = Console.ReadLine();

        }
        Console.WriteLine("кол-во строк с A*b: " + countAnB);
        Console.WriteLine("самая длинная подоследовательность abc: " + maxLength);

    }
}

