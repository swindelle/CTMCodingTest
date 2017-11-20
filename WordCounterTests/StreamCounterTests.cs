using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;

namespace WordCounterTests
{
    [TestClass]
    public class StreamCounterTests : WordCountTests
    {
        [TestInitialize]
        public void Setup()
        {
            wordCounter = new StreamCounter();
        }
    }
}
