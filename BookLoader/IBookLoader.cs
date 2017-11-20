using System.Collections.Generic;

namespace BookLoader
{
    public interface IBookLoader
    {
        /// <summary>
        /// Load a book from a specified file path
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>characters in the file. throws if file doesn't exist</returns>
        IEnumerable<char> Load(string path);
    }
}
