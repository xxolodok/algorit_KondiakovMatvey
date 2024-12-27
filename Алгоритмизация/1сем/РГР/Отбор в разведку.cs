using System;
using System.IO;

class Program
{
    static void Main()
    {
        if(i<9){
                N = int.Parse(File.ReadAllText("input_s1_01.txt"));
            }else{
                N = int.Parse(File.ReadAllText("input_s1_01.txt"));
            }
        int result = CountGroups(N);
        Console.WriteLine(result);
    }
    static int CountGroups(int N)
    {
        
        if (N < 3)
        {
            return 0;
        }
        if (N == 3)
        {
            return 1;
        }
        int evenCount = CountGroups(N / 2); 
        int oddCount = CountGroups(N - N / 2);

        return evenCount + oddCount; 
    }
}
