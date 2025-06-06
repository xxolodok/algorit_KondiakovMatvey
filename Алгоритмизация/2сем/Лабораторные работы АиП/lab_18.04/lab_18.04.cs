using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] StringArray = File.ReadAllLines("test_string");
        using (StreamWriter writer = new StreamWriter("output"))
        {
            foreach (var s in StringArray)
            {
                bool hasEvenNumber = false;
                
                for (int i = 0; i < s.Length; i++)
                {
                    if (char.IsDigit(s[i]))
                    {
                        Stack<char> NumberStack = new Stack<char>();
                        while (i < s.Length && char.IsDigit(s[i]))
                        {
                            NumberStack.Push(s[i]);
                            i++;
                        }
                        
                        if (NumberStack.Count > 0 && (NumberStack.Pop() - '0') % 2 == 0)
                        {
                            hasEvenNumber = true;
                            break;
                        }
                    }
                }
                
                if (hasEvenNumber)
                {
                    writer.WriteLine(s);
                }
            }
        }
    }
}