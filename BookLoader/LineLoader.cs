using System.Collections.Generic;
using System.IO;

namespace BookLoader
{
    public class LineLoader : IBookLoader
    {
        public IEnumerable<char> Load(string path)
        {
            System.Console.WriteLine(path);
            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.Peek() >= 0)
                {
                    foreach (var c in reader.ReadLine())
                    {
                        yield return c;
                    }
                }
            }
        }
    }
}
