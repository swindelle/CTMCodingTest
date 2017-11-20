using BookLoader;
using PrimeTester;
using System;
using System.IO;
using System.Reflection;
using WordCounter;

namespace CTMCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(dir, "RailwayChildren.txt");
            var analyzer = new BookAnalyzer(new StreamLoader(), new StreamCounter(), new CachedPrimeSieve(), path);

            foreach (var line in analyzer.Analyze())
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
