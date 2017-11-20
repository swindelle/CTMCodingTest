using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoader
{
    public class StreamLoader : IBookLoader
    {
        public IEnumerable<char> Load(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                while(reader.Peek() > 0)
                {
                    yield return (char)reader.Read();
                }
            }
        }
    }
}
