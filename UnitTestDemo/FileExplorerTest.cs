using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileExplorer;

namespace UnitTestDemo
{
    [TestClass]
    public class FileExplorerTest
    {
        [TestMethod]
        public void Test_directoryNotExists()
        {
            Directory dir = new Directory("d://");
            Assert.IsTrue(dir.exists());
        }
        [TestMethod]
        public void Test_directoryExists()
        {
            //Directory dir = new Directory("c://");
            //Assert.IsTrue(dir.exists());
            Assert.AreEqual(2 + 3, 6);
        }
    }
}
