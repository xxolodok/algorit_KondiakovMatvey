using System;
using System.IO; 

class Program
{
    static void Main()
    {
        string[] StringArray = File.ReadAllLines("test_string");
        foreach(var s in StringArray)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if(char.IsDigit(s[i])) 
                {

                    Stack<char> NumberStack = new();
                    while(i < s.Length && char.IsDigit(s[i]))
                    {
                        NumberStack.Push(s[i]);
                        i++;
                    }
                    if(NumberStack.Pop() % 2 == 0)
                    {
                        Console.WriteLine(s);  
                        break;  
                    }
                }
            }
        }
    }
}