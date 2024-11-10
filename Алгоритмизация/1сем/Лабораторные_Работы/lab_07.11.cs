using System;

class Program
{
    static void Main()
    {

        string B = "бвгджзйклмнпрстфхцчшщьъ";
        string A = "аеёиоуыэюя";

        Console.WriteLine("Введите строку");
        string input = Console.ReadLine();
        string DelettedSpaceString = DeleteSpace(input);
        Console.WriteLine(DelettedSpaceString);

        string[] AfterReferse = DelettedSpaceString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string str in AfterReferse)
        {
            string Polindrom = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Polindrom += str[i];

            }
            if (str == Polindrom)
            {
                Console.WriteLine("полиндром: " + str);
            }
            else
            {
                Console.WriteLine("не полиндром: "+str);

            }
        }

        string ReverseDelettedSpaceString = "";
        for (int i = DelettedSpaceString.Length - 1; i >= 0; i--)
        {
            ReverseDelettedSpaceString += DelettedSpaceString[i];
        }
        if (ReverseDelettedSpaceString == DelettedSpaceString)
        {
            Console.WriteLine("Строка  полиндром");
        }
        else
        {
            Console.WriteLine("Строка  не полиндром");

        }
    
    int countA = 0; 
    int countB = 0; 
    
        Console.WriteLine("Введите кол=-во строк");
    
    int n = Convert.ToInt32(Console.ReadLine());

    string IdolString = "";


        for (int i = 0; i < n; i++)
        {
            countA = 0; 
            countB = 0; 
            Console.WriteLine("Введите строку № " + (i+1));
            string str = Console.ReadLine();
            for (int o = 0; o < str.Length; o++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (str[o] == A[j])
                    {
                        countA++;
                    }
                }
            }
            for (int o = 0; o < str.Length; o++)
            {
               
                for (int j = 0; j < B.Length; j++)
                {
                    if (str[o] == B[j])
                    {
                        countB++;
                    }
                }
            }
            if (countA > countB)
            {
                IdolString += $"\t{str}; \n";
            }
        }
        Console.WriteLine("скроки: \n" + IdolString);
    }



    static string DeleteSpace(string s)
    {
        return string.Join(" ", s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }
}
