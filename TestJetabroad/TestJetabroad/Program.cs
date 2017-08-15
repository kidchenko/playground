using System;
using System.Collections.Generic;

namespace TestJetabroad
{
    class MainClass
    {
        public static void Main()
        {
            CountLetterOccurrences("Life, the universe, and everything", 3);
        }


        public static int CountLetterOccurrences(string input, int minOccurrences)
		{
            var lettersArray = input.Replace(" ", "").ToLower().ToCharArray();
            var dict = new Dictionary<char, int>();
            var totalFound = 0;

            for (int i = 0; i < lettersArray.Length - 1; i++)
            {
                var letter = lettersArray[i];
                if (!dict.ContainsKey(letter))
                {
                    dict.Add(lettersArray[i], 1);
                }
                else 
                {
                    dict[letter] = dict[letter] + 1;
                }
            }

            foreach (var item  in dict)
            {
                if (item.Value >= minOccurrences)
                {
                    totalFound++;
                    Console.WriteLine($"TOTAL FOUND: {totalFound} - {item.Key} - value {item.Value}");    
                }
            }
            return totalFound;
        }
    }
}
