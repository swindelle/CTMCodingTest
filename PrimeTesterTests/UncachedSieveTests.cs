using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTester;

namespace PrimeTesterTests
{
    [TestClass]
    public class UncachedSieveTests : PrimeTests
    {
        [TestInitialize]
        public void Setup()
        {
            primeTester = new UncachedSieve();
        }
    }
}
