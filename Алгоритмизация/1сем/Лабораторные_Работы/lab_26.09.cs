using System;

class Lab2
{
    static void Main()
    {
        Console.WriteLine("Введите кол-во элементов последовательности(>3)");

        var n = Convert.ToInt32(Console.ReadLine());
        if (n >= 3)
        {
            Console.WriteLine("Пойдет");
            Console.WriteLine("Введите первые три числа");

            var first = Convert.ToInt32(Console.ReadLine());
            var second = Convert.ToInt32(Console.ReadLine());
            var thierd = Convert.ToInt32(Console.ReadLine());

            var count_min = 0;

            var evenCount = 0;

            var max_number = 0;
            var max_number2 = 0;

            for (var i = 0; i < (n - 3); i++)
            {
                if (first < second && first < thierd)
                {
                    count_min++;
                }
                else if (second < first && second < thierd)
                {
                    count_min++;
                }
                else if (thierd < first && thierd < second)
                {
                    count_min++;
                }

                if (i == 0)
                {
                    if (first % 2 == 0)
                    {
                        evenCount++;
                    }
                    if (second % 2 == 0)
                    {
                        evenCount++;
                    }
                    if (thierd % 2 == 0)
                    {
                        evenCount++;
                    }


                    if (first >= second && first >= thierd)
                    {
                        max_number = first;
                        max_number2 = (second >= thierd) ? second : thierd;
                    }
                    else if (second >= first && second >= thierd)
                    {
                        max_number = second;
                        max_number2 = (first >= thierd) ? first : thierd;
                    }
                    else
                    {
                        max_number = thierd;
                        max_number2 = (first >= second) ? first : second;
                    }

                }
                if (thierd % 2 == 0)
                {
                    evenCount++;
                }



                first = second;
                second = thierd;
                thierd = Convert.ToInt32(Console.ReadLine());

                if ((thierd >= max_number) && (thierd > max_number2))
                {
                    if (max_number > max_number2)
                    {
                        max_number2 = thierd;

                    }
                    else
                    {
                        max_number = thierd;
                    }
                }
                else if (thierd >= max_number && thierd <= max_number2)
                {
                    max_number = thierd;

                }
                else if (thierd <= max_number && thierd >= max_number2)
                {
                    max_number2 = thierd;
                }

            }
            Console.WriteLine("count_min = " + count_min);

            if (evenCount == n)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            Console.WriteLine("Two max number: " + $"{max_number}, {max_number2}");
        }
        else
        {
            Console.WriteLine("n>3");
        }

    }
}
