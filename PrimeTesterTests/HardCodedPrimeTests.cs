using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTester;

namespace PrimeTesterTests
{
    [TestClass]
    public class HardCodedPrimeTests : PrimeTests
    {
        [TestInitialize]
        public void Setup()
        {
            primeTester = new HardCodedPrimes();
        }
    }
}
