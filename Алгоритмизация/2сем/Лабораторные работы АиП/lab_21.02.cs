using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите выражение:");
        string expression = Console.ReadLine();
        
        if (CheckExpression(expression))
        {
            Console.WriteLine("Выражение корректно.");
        }
        else
        {
            Console.WriteLine("Выражение некорректно.");
        }
    }
    static bool CheckExpression(string expression)
    {
        Stack<char> BracketStack = new Stack<char>();
        
        foreach (char c in expression)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                BracketStack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (BracketStack.Count == 0)
                {
                    return false; 
                }

                char top = BracketStack.Pop();
                if (!IsAntiBracket(top, c))
                {
                    return false; 
                }
            }
        }

        return BracketStack.Count == 0;
    }

    static bool IsAntiBracket(char open, char close)
    {
        return (open == '(' && close == ')') || (open == '[' && close == ']') || (open == '{' && close == '}');
    }
}
