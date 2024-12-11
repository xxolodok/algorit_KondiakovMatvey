using System;

class lab
{
    static void Main()
    {

        string str = Console.ReadLine();
        int countAnB = 0;
        int countABC = 0;
        int maxCountABC = 0;
        while (true)
        {
            countABC = 0;

            if (str == "")
            {
                break;
            }
            str = str.ToLower();
            for (int i = 0; i < str.Length - 2; i++)
            {

                if ($"{str[i]}" == "a" && $"{str[i + 2]}" == "b")
                {
                    countAnB++;
                    break;
                }

            }

            foreach (char c in str)
            {
                if (char.ToLower(c) == 'a' || char.ToLower(c) == 'b' || char.ToLower(c) == 'c')
                {
                    countABC++;
                }
                else
                {
                    if (countABC > maxCountABC)
                    {
                        maxCountABC = countABC;
                    }
                    countABC = 0; 
                }
            }
            if (countABC > maxCountABC)
            {
                maxCountABC = countABC;
                Console.WriteLine(countABC);
            }

            str = Console.ReadLine();

        }


        Console.WriteLine("Кол-ыо строк с a*b :" + countAnB);

    }
}