using System;
using System.Text.RegularExpressions;

delegate List<string> sortedStringList(List<string> wordList);


class program
{
    static void Main()
    {
        List<string> wordsList = new() { "мама", "мыло", "рама", "Москва", "окно", "молоко" };

        sortedStringList sortedStringList = (wordsList) =>
        {
            var sortedWordList = new List<string>();
            foreach (var word in wordsList)
            {
                if (Regex.IsMatch(word, @"^[мМ].*"))
                {
                    sortedWordList.Add(word);
                }
            }
            return sortedWordList;
        };

        Console.WriteLine(string.Join(", ", sortedStringList(wordsList)));
    }

}