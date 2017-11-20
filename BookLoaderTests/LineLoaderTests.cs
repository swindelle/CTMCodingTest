using BookLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookLoaderTests
{
    [TestClass]
    public class LineLoaderTests : BookLoaderTests
    {
        [TestInitialize]
        public void Setup()
        {
            loader = new LineLoader();
        }
    }
}
