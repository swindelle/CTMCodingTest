using System.Collections.Generic;
using System.Text;

namespace WordCounter
{
    public class StreamCounter : IWordCounter
    {
        public Dictionary<string, int> CountWords(IEnumerable<char> characters)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            bool inWord = false;
            var enumerator = characters.GetEnumerator();
            StringBuilder wordBuilder = new StringBuilder();
            while(enumerator.MoveNext())
            {
                char c = enumerator.Current;
                if (char.IsWhiteSpace(c))
                {
                    if (inWord)
                    {
                        AddWord(wordBuilder.ToString(), dictionary);
                        wordBuilder.Clear();
                        inWord = false;
                    }
                }
                if (char.IsLetter(c))
                {
                    wordBuilder.Append(c);
                    inWord = true;
                }
            }
            if (inWord)
            {
                AddWord(wordBuilder.ToString(), dictionary);
            }
            return dictionary;
        }

        private static void AddWord(string word, Dictionary<string, int> dictionary)
        {
            var lowerWord = word.ToLower();
            if (dictionary.ContainsKey(lowerWord))
            {
                dictionary[lowerWord]++;
            }
            else
            {
                dictionary.Add(lowerWord, 1);
            }
        }
    }
}
