using System.Collections.Generic;

namespace LinqUp
{
    public class CharacterFrequencyCounter
    {
        /// <summary>
        /// Counts the frequency of each character in a string and outputs each character encountered followed by its frequency.
        /// </summary>
        public string CountFrequencyOfCharacters(string input)
        {
            var characterFrequencies = new Dictionary<char, int>();
            foreach (char c in input)
            {
                var currentFrequencyOfCharacter = characterFrequencies.ContainsKey(c) ? characterFrequencies[c] : 0;
                characterFrequencies[c] = currentFrequencyOfCharacter+1;
            }

            string output = $"Character frequencies for \"{input}\" are:\r\n";
            foreach (var item in characterFrequencies)
            {
                output += $"[{item.Key}]: {item.Value} occurances\r\n";
            }

            return output;
        }
    }
}
