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
            Assert.IsTrue(authWindow.Auth("admin", "AdminPass456!"));
            Assert.IsFalse(authWindow.Auth("dryfgh", "ygh23jn"));
            Assert.IsFalse(authWindow.Auth("", ""));
            Assert.IsFalse(authWindow.Auth(" ", " "));
        }
    }
}
