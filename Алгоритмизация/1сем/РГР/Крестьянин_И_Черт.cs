using System;

class Program
{
    static void Main()
    {
        long MaxN = Convert.ToInt64(Console.ReadLine());
        long countCombinations = 0;

        for (int Z = 1; ; Z++)
        {
            long d = (1L << Z) - 1; 
            if (d > MaxN) break; 

            countCombinations += MaxN / d; 
        }

        Console.WriteLine(countCombinations);
    }
}
