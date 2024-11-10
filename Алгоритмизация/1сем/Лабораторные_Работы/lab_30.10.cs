

using System;

class Labx
{
    static void Main()
    {
        int[][] stepArray = new int[4][];
        int n = 0;

        for(int i = 0; i< 4; i++){
            Console.WriteLine("Укажите размер массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            stepArray[i] = new int[n]; 
            for(int j = 0; j<n; j++){
            Console.WriteLine($"Укажите {j} елемент массива: ");

            stepArray[i][j] = Convert.ToInt32(Console.ReadLine());; 
            }
        }
        

        // Заполнение массивов элементами (можно заменить на ввод от пользователя)
        


        for (int i = 0; i < stepArray.Length; i++)
        {
            int evenCount = 0;
            int oddCount = 0;

            foreach (var item in stepArray[i])
            {
                if (item % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
            Console.WriteLine($"Массив {i + 1}: четных - {evenCount}, нечетных - {oddCount}");
        }
        for (int i = 0; i < stepArray.Length; i++)
        {
            int sum = 0;
            foreach (var item in stepArray[i])
            {
                sum += item; 
            }

            bool found = false;
            for (int j = 0; j < stepArray[i].Length; j++)
            {
                if (stepArray[i][j] > (sum - stepArray[i][j]))               {
                    Console.WriteLine($"В массиве {i + 1} элемент {stepArray[i][j]} на позиции {j} больше суммы остальных элементов");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"В массиве {i + 1} нет элемента, который больше суммы остальных элементов");
            }
        }

    }
}




