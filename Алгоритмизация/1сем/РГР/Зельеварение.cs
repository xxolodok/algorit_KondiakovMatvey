using System;
using System.Diagnostics;


class Potion
{
    static void Main(string[] args)
    {
        string[] actions = File.ReadAllLines("input1.txt");
        string[][] ArrayOfAction = new string[actions.Length][];
        string[] ShortAction = new string[actions.Length];
        string action;
        int n;
        string output;
        
        for (int p = 0; p < 10; p++)
        {
            actions = File.ReadAllLines($"input{p + 1}.txt");
            ArrayOfAction = new string[actions.Length][];
            ShortAction = new string[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                action = actions[i];
                ArrayOfAction[i] = action.Split(' ');
            }
            for (int i = 0; i < ArrayOfAction.Length; i++)
            {
                switch (ArrayOfAction[i][0])
                {
                    case "DUST":
                        action = "DT";
                        for (int k = 1; k < ArrayOfAction[i].Length; k++)
                        {
                            if (int.TryParse(ArrayOfAction[i][k], out int res))
                            {
                                n = Convert.ToInt32(ArrayOfAction[i][k]);
                                action += ShortAction[+(n - 1)];
                            }
                            else
                            {
                                action += ArrayOfAction[i][k];
                            }
                        }
                        action += "TD";
                        ShortAction[i] = action;
                        break;
                    case "WATER":
                        action = "WT";
                        for (int k = 1; k < ArrayOfAction[i].Length; k++)
                        {
                            if (int.TryParse(ArrayOfAction[i][k], out int res))
                            {
                                n = Convert.ToInt32(ArrayOfAction[i][k]);
                                action += ShortAction[+(n - 1)];
                            }
                            else
                            {
                                action += ArrayOfAction[i][k];
                            }
                        }
                        action += "TW";
                        ShortAction[i] = action;
                        break;
                    case "MIX":
                        action = "MX";
                        for (int k = 1; k < ArrayOfAction[i].Length; k++)
                        {
                            if (int.TryParse(ArrayOfAction[i][k], out int res))
                            {
                                n = Convert.ToInt32(ArrayOfAction[i][k]);
                                action += ShortAction[+(n - 1)];
                            }
                            else
                            {
                                action += ArrayOfAction[i][k];
                            }
                        }
                        action += "XM";
                        ShortAction[i] = action;
                        break;
                    case "FIRE":
                        action = "FR";
                        for (int k = 1; k < ArrayOfAction[i].Length; k++)
                        {
                            if (int.TryParse(ArrayOfAction[i][k], out int res))
                            {
                                n = Convert.ToInt32(ArrayOfAction[i][k]);
                                action += ShortAction[+(n - 1)];
                            }
                            else
                            {
                                action += ArrayOfAction[i][k];
                            }
                        }
                        action += "RF";
                        ShortAction[i] = action;
                        break;
                }
            }
            output = File.ReadAllText($"output{p + 1}.txt");

            if (output == ShortAction[ShortAction.Length - 1])
            {
                Console.WriteLine($"ввод и вывод файла {p + 1} совпадают");
            }
        }
    }

}
