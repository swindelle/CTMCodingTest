﻿using BookLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookLoaderTests
{
    [TestClass]
    public class StreamLoaderTests : BookLoaderTests
    {
        [TestInitialize]
        public void Setup()
        {
            loader = new StreamLoader();
        }
    }
}
