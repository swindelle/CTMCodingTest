using BookLoader;
using PrimeTester;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordCounter;

namespace CTMCodingTest
{
    public class BookAnalyzer
    {
        IBookLoader bookLoader;
        IWordCounter wordCounter;
        IPrimeTestable primeTester;
        string bookPath;

        public BookAnalyzer(IBookLoader loader, IWordCounter counter, IPrimeTestable tester, string path)
        {
            bookLoader = loader;
            wordCounter = counter;
            primeTester = tester;
            bookPath = path;
        }

        public IEnumerable<string> Analyze()
        {
            string error = string.Empty;
            Dictionary<string, int> result = new Dictionary<string, int>();
            try
            {
                result = wordCounter.CountWords(bookLoader.Load(bookPath));
            }
            catch(FileNotFoundException)
            {
                error = "could not find file: " + bookPath;
            }
            catch(DirectoryNotFoundException)
            {
                error = "could not find directory containing file: " + bookPath;
            }
            catch(Exception e)
            {
                error = e.Message;
            }
            if (error.Length > 0)
            {
                yield return error;
            }
            else
            {
                foreach (var kvp in result.OrderBy(a => a.Value))
                {
                    yield return string.Format("Word: {0}, Count: {1}, Prime? {2}", kvp.Key, kvp.Value, primeTester.IsPrime(kvp.Value) ? "Yes" : "No");
                }
            }
        }
    }
}
