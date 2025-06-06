using System;
using System.Collections.Generic;
using System.Linq;

delegate List<string> SortedStringList(List<string> wordList);

class Program
{
    static void Main()
    {
        List<string> wordsList = new() { "мама", "мыло", "рама", "Москва", "окно", "молоко" };

        SortedStringList filterWords = (words) =>
        {
            List<string> filteredList = new List<string>();
            foreach (var word in words)
            {
                if (char.ToLower(word[0]) == 'м')
                {
                    filteredList.Add(word);
                }
            }
            return filteredList;
        };

        Console.WriteLine(string.Join(", ", filterWords(wordsList)));
    }
}
