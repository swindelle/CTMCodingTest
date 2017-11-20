using System.Collections.Generic;

namespace WordCounter
{
    public interface IWordCounter
    {
        /// <summary>
        /// processes characters, splitting into words ignoring case and punctuation, recording the count of instances of the word
        /// </summary>
        /// <param name="characters">input characters</param>
        /// <returns>Dictionary of lower case words found with their count</returns>
        Dictionary<string, int> CountWords(IEnumerable<char> characters);
    }
}
