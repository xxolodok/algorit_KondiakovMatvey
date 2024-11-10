using System;

class lab3
{
    //A     static void Main()
    //     {
    //         int n = Convert.ToInt32(Console.ReadLine());

    //         int a = Convert.ToInt32(Console.ReadLine());
    //         int b = Convert.ToInt32(Console.ReadLine());

    //         int count = 1;
    //         int countMin = 1;

    //         for (int i = 2; i < n; i++)
    //         {
    //             if (a == b)
    //             {
    //                 count++;
    //             }
    //             else
    //             {
    //                 if (count > countMin)
    //                 {
    //                     countMin = count;
    //                 }
    //                 count = 1;
    //             }
    //             a = b;
    //             b = Convert.ToInt32(Console.ReadLine());
    //             if (i == (n - 1))
    //             {
    //                 if (a == b)
    //                 {
    //                     count++;
    //                 }
    //                 else
    //                 {
    //                     if (count > countMin)
    //                     {
    //                         countMin = count;
    //                     }
    //                     count = 1;
    //                 }
    //             }

    //         }

    //         if (count > countMin)
    //         {
    //             Console.WriteLine(count);
    //         }
    //         else
    //         {
    //             Console.WriteLine(countMin);

    //         }
    //     }
    // }

    //  static void Main()
    //     {
    //         int n = Convert.ToInt32(Console.ReadLine());

    //         int b = Convert.ToInt32(Console.ReadLine());

    //         int count = 0;
    //         int countMin = 0;

    //         for (int i = 1; i < n; i++)
    //         {
    //             if (b%2 == 0)
    //             {
    //                 count++;
    //             }
    //             else
    //             {
    //                 if (count < countMin)
    //                 {
    //                     countMin = count;
    //                 }
    //                 count = 0;
    //             }
    //             b = Convert.ToInt32(Console.ReadLine());
    //             if (b%2 == 0)
    //             {
    //                 count++;
    //             }
    //             else
    //             {
    //                 if (count < countMin)
    //                 {
    //                     countMin = count;
    //                 }
    //                 count = 0;
    //             }

    //         }

    //         if (count > countMin)
    //         {
    //             Console.WriteLine(count);
    //         }
    //         else
    //         {
    //             Console.WriteLine(countMin);

    //         }
    //     }
    // }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());


        int b = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int maxSum = 0;


        int count = 0;
        int countMin = 0;
        for (int i = 1; i < n; i++)
        {
            if (b % 2 == 0)
            {
                sum += b;
                count++;
            }
            else
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                sum = 0;

                if (count > countMin)
                {
                    countMin = count;
                }
                count = 0;
            }
            Console.WriteLine("sum= " + sum);

            b = Convert.ToInt32(Console.ReadLine());
            if (i == (n - 1))
            {
                if (b % 2 == 0)
                {
                    sum += b;
                }
                else
                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                    sum = 0;
                }
            }


        }
            Console.WriteLine(countMin);

        
    }
}