using System;


class lab
// задание на первую пару
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        while (number > 0)
        {
            int numberEnd = 0;
            int rebmun = 0;

            while (number > 0)
            {
                
                if (numberEnd % 2 != 0)
                {
                    rebmun = Convert.ToInt32(rebmun.ToString() + $"{numberEnd}");
                }
            }
            if (rebmun == 0)
            {
                Console.WriteLine("Оно~~~ Испари~илось :^");

            }
            else
            {
                Console.WriteLine(rebmun);
            }
            number = Convert.ToInt32(Console.ReadLine());

        }
    }

}
// задание на вторую пару
// class alb
// {
//     static void Main()
//     {
//         Console.WriteLine($"0{0}");
//         Console.WriteLine("ВВедите количесвто элементов");
//         int n = Convert.ToInt32(Console.ReadLine());

//         int[] AbsInt = new int[n];
//         int[] BIAbsInt = new int[n];
//         for (int i = 0; i < n; i++)
//         {
//             Console.WriteLine($"Введите элемент {i + 1}/{n}");
//             AbsInt[i] = Math.Abs(Convert.ToInt32(Console.ReadLine()));
//         }


//         PrintArray(AbsInt);


//         bool isEven = true;
//         int countOfEven = 0;
//         int numberEnd;
//         int number;
//         string BInumber = "";
//         for (int i = 0; i < n; i++)
//         {
//             number = AbsInt[i];

//             while (number > 0)
//             {
//                 numberEnd = number % 10;
//                 number = number / 10;

//                 if (numberEnd % 2 == 0)
//                 {

//                 }
//                 else
//                 {
//                     isEven = false;

//                 }


//             }

//             if (isEven == true)
//             {
//                 countOfEven++;
//             }
//             isEven = true;


//         }
//         Console.WriteLine("количество элементов со всеми четными цифрами: " + countOfEven);

//         for (int i = 0; i < n; i++)
//         {
//             number = AbsInt[i];

//             while (number > 0)
//             {
//                 numberEnd = number % 10;
//                 number = number / 10;

//                 if (numberEnd % 2 == 0)
//                 {
//                     BInumber = $"0{BInumber}";
//                 }
//                 else
//                 {
//                     BInumber = $"1{BInumber}";
//                     isEven = false;
//                 }

//             }
//             BIAbsInt[i] = Convert.ToInt32(BInumber);
//             BInumber = "";
//         }
//         PrintArray(AbsInt);


//         int[] EvennOddArray = new int[n];
//         int index = 0;
//         for(int i= 0; i<n; i++){
//             if(AbsInt[i]%2==0){
//                 EvennOddArray[index] = AbsInt[i];
//                 index++;
//             }
//         }
//         PrintArray(EvennOddArray);

//         for(int i = 0 ; i<n; i++){
//             if(AbsInt[i]%2!=0){
//                 EvennOddArray[index] = AbsInt[i];
//                 index++;
//             }
//         }
//         PrintArray(EvennOddArray);
//     }
//     static void PrintArray(int[] arr)
//     {
//         Console.WriteLine(string.Join(", ", arr));
//     }
// }

