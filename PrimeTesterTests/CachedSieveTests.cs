using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTester;

namespace PrimeTesterTests
{
    [TestClass]
    public class CachedSieveTests : PrimeTests
    {
        [TestInitialize]
        public void Setup()
        {
            primeTester = new CachedPrimeSieve();
        }

    }
}
