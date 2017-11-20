using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLoader;
using System.Collections.Generic;
using WordCounter;
using PrimeTester;
using CTMCodingTest;
using System;
using System.IO;

namespace BookAnalyzerTests
{
    [TestClass]
    public class BookAnalyzerTest
    {
        private class IntegrationLoader : IBookLoader
        {
            public IEnumerable<char> Load(string path)
            {
                return "the the the the the and and in in in or";
            }
        }

        private class IntegrationLoaderWithException : IBookLoader
        {
            private Exception exception;
            public IntegrationLoaderWithException(Exception e)
            {
                exception = e;
            }

            public IEnumerable<char> Load(string path)
            {
                throw exception;
            }
        }


        private class IntegrationCounter : IWordCounter
        {
            public Dictionary<string, int> CountWords(IEnumerable<char> characters)
            {
                return new Dictionary<string, int>() { { "the", 3 }, { "and", 5 }, { "a", 2 } };
            }
        }

        private class IntegrationPrime : IPrimeTestable
        {
            public bool IsPrime(int value)
            {
                return value % 2 == 0;
            }
        }

        [TestMethod]
        public void IntegrationTest()
        {
            var analyzer = new BookAnalyzer(new IntegrationLoader(), new IntegrationCounter(), new IntegrationPrime(), "");
            string[] expected = { "Word: a, Count: 2, Prime? Yes", "Word: the, Count: 3, Prime? No", "Word: and, Count: 5, Prime? No" };
            CollectionAssert.AreEqual(expected, analyzer.Analyze().ToArray());
        }

        [TestMethod]
        public void IntegrationTestNoFile()
        {
            var analyzer = new BookAnalyzer(new IntegrationLoaderWithException(new FileNotFoundException()), new IntegrationCounter(), new IntegrationPrime(), "file");
            string[] expected = { "could not find file: file" };
            CollectionAssert.AreEqual(expected, analyzer.Analyze().ToArray());
        }

        [TestMethod]
        public void IntegrationTestNoDir()
        {
            var analyzer = new BookAnalyzer(new IntegrationLoaderWithException(new DirectoryNotFoundException()), new IntegrationCounter(), new IntegrationPrime(), "file");
            string[] expected = { "could not find directory containing file: file" };
            CollectionAssert.AreEqual(expected, analyzer.Analyze().ToArray());
        }

        [TestMethod]
        public void IntegrationTestException()
        {
            var analyzer = new BookAnalyzer(new IntegrationLoaderWithException(new Exception("message")), new IntegrationCounter(), new IntegrationPrime(), "file");
            string[] expected = { "message" };
            CollectionAssert.AreEqual(expected, analyzer.Analyze().ToArray());
        }
    }
}
