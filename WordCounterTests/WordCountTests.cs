using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;

namespace WordCounterTests
{
    [TestClass]
    public abstract class WordCountTests
    {
        protected IWordCounter wordCounter;

        [TestMethod]
        public void EmptyString()
        {
            Assert.IsFalse(wordCounter.CountWords(string.Empty).Any());
        }

        [TestMethod]
        public void WhiteSpace()
        {
            Assert.IsFalse(wordCounter.CountWords("  \t\n\r").Any());
        }

        [TestMethod]
        public void WhiteSpaceAll()
        {
            var whitespaceChars = Enumerable.Range(0, 0x110000)
                         .Where(x => x < 0x00d800 || x > 0x00dfff)
                         .Select(char.ConvertFromUtf32)
                         .Where(c => char.GetUnicodeCategory(c,0) == System.Globalization.UnicodeCategory.SpaceSeparator).ToArray();
            Assert.IsFalse(wordCounter.CountWords(string.Join(string.Empty, whitespaceChars)).Any());
        }


        [TestMethod]
        public void OnlyLetters()
        {
            Assert.IsTrue(wordCounter.CountWords("sfsdfsfasdfasdf").Count() == 1);
        }

        [TestMethod]
        public void Separators()
        {
            // test main options
            Assert.IsTrue(wordCounter.CountWords("a b\tc\rd\ne").Count() == 5);
        }

        [TestMethod]
        public void Multiple()
        {
            // test counting
            var res = wordCounter.CountWords("a a a a a a a a a a");
            Assert.IsTrue(res.Count() == 1);
            Assert.IsTrue(res.ContainsKey("a"));
            Assert.IsTrue(res["a"] == 10);
        }

        [TestMethod]
        public void Capitalisation()
        {
            // test capitalisation doesnt matter
            var res = wordCounter.CountWords("DONT dont Dont dOnt doNt donT");
            Assert.IsTrue(res.Count() == 1);
            Assert.IsTrue(res.ContainsKey("dont"));
            Assert.IsTrue(res["dont"] == 6);
        }

        [TestMethod]
        public void Punctuation()
        {
            // test capitalisation doesnt matter
            var res = wordCounter.CountWords("don't dont do-nt dont? dont! \"dont\" 'dont'");
            Assert.IsTrue(res.Count() == 1);
            Assert.IsTrue(res.ContainsKey("dont"));
            Assert.IsTrue(res["dont"] == 7);
        }

        [TestMethod]
        public void Combination()
        {
            // test counting
            var res = wordCounter.CountWords("The quick brown fox jumps over the lazy dog");
            Assert.IsTrue(res.Count() == 8);
            Assert.IsTrue(res.ContainsKey("the"));
            Assert.IsTrue(res["the"] == 2);
        }

    }
}
