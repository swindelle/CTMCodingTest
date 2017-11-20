using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using BookLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookLoaderTests
{
    [TestClass]
    public abstract class BookLoaderTests
    {
        protected IBookLoader loader;

        protected static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void MissingFile()
        {
            var path = Path.Combine(AssemblyDirectory, "MissingFile.txt");
            var res = loader.Load(path);
            res.ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void MissingDir()
        {
            var path = Path.Combine(AssemblyDirectory, "MissingDir\\MissingFile.txt");
            var res = loader.Load(path);
            res.ToArray();
        }

        [TestMethod]
        public void HelloWorld()
        {
            var path = Path.Combine(AssemblyDirectory, "TestFiles\\HelloWorld.txt");
            var res = loader.Load(path);
            string text = new string(res.ToArray());
            Assert.AreEqual("Hello World", text);
        }

    }
}
