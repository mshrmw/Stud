using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stud;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var authWindow = new MainWindow();
            Assert.IsTrue(authWindow.Auth("user", "Password123"));
        }
    }
}
