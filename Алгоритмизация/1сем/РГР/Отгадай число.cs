using System;


class Program
{

    static void Main()
    {

        string[] input;
        string action;
        string argument;
        int x = 1;
        int a = 0;
        int r;

    
        for (int i = 0; i < 12; i++)
        {
            if(i<9){
                input = File.ReadAllLines($"input_s1_0{i+1}.txt");
            }else{
                input = File.ReadAllLines($"input_s1_{i+1}.txt");
            }
            int CountACtion = int.Parse(input[0]);
            x = 1 ;
            a = 0;
            r =int.Parse(input[CountACtion+1]);

            for (int j = 1; j <=CountACtion; j++)
            {
                // Console.WriteLine(input[j]+"   "+ CountACtion);
                action = input[j].Split(" ")[0];
                argument = input[j].Split(" ")[1];
                switch (action)
                {
                    case "+":
                        if (argument == "x")
                        {
                            x += 1;
                        }
                        else
                        {
                            a += int.Parse($"{argument}");
                        }
                        break;
                    case "-":
                        if (argument == "x")
                        {
                            x -= 1;
                        }
                        else
                        {
                            a -= int.Parse($"{argument}");
                        }
                        break;
                    case "*":
                        a *= +int.Parse($"{argument}");
                        x *= +int.Parse($"{argument}");
                        break;
                }
            }
                Console.WriteLine($"В файле {i+1} Изначальный x = "+ (r-a)/x);
        }
    }
}