using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTester;

namespace PrimeTesterTests
{
    [TestClass]
    public abstract class PrimeTests
    {
        protected IPrimeTestable primeTester;

        [TestMethod]
        public void Test0()
        {
            Assert.IsFalse(primeTester.IsPrime(0));
        }

        [TestMethod]
        public void Test1()
        {
            Assert.IsFalse(primeTester.IsPrime(1));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(primeTester.IsPrime(2));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.IsTrue(primeTester.IsPrime(3));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.IsFalse(primeTester.IsPrime(4));
        }

        [TestMethod]
        public void TestMinus5()
        {
            Assert.IsFalse(primeTester.IsPrime(-5));
        }

        [TestMethod]
        public void Test7()
        {
            Assert.IsTrue(primeTester.IsPrime(7));
        }


        [TestMethod]
        public void Test22()
        {
            Assert.IsFalse(primeTester.IsPrime(22));
        }


        [TestMethod]
        public void Test63()
        {
            Assert.IsFalse(primeTester.IsPrime(63));
        }


        [TestMethod]
        public void Test67()
        {
            Assert.IsTrue(primeTester.IsPrime(67));
        }


        [TestMethod]
        public void Test4000()
        {
            Assert.IsFalse(primeTester.IsPrime(4000));
        }


        [TestMethod]
        public void Test2399()
        {
            Assert.IsTrue(primeTester.IsPrime(2399));
        }


        [TestMethod]
        public void Test7919()
        {
            Assert.IsTrue(primeTester.IsPrime(7919));
        }


        [TestMethod]
        public void Test7913()
        {
            Assert.IsFalse(primeTester.IsPrime(7913));
        }


        [TestMethod]
        public void Test9973()
        {
            Assert.IsTrue(primeTester.IsPrime(9973));
        }

        [TestMethod]
        public void Test9999()
        {
            Assert.IsFalse(primeTester.IsPrime(9999));
        }


    }
}
