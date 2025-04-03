using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stud;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var authWindow = new MainWindow();
            Assert.IsTrue(authWindow.Auth("user", "Password123"));
            Assert.IsTrue(authWindow.Auth("admin", "AdminPass456!"));
            Assert.IsTrue(authWindow.Auth("coordinator", "KorPass789!"));
            Assert.IsTrue(authWindow.Auth("ivanov", "IvanovPass1!"));
            Assert.IsTrue(authWindow.Auth("petrova", "PetrovaPass2!"));
            Assert.IsTrue(authWindow.Auth("sidorov", "SidorovPass3!"));
            Assert.IsTrue(authWindow.Auth("kuznetsova", "Kuznetsova4!"));
            Assert.IsTrue(authWindow.Auth("nikolaev", "Nikolaev5!"));
            Assert.IsTrue(authWindow.Auth("vorobyeva", "Vorobyeva6!"));
            Assert.IsTrue(authWindow.Auth("gromov", "Gromov7!"));
            Assert.IsTrue(authWindow.Auth("belova", "Belova8!"));
            Assert.IsTrue(authWindow.Auth("fedorov", "Fedorov9!"));
            Assert.IsTrue(authWindow.Auth("sofib", "superstar1"));
            Assert.IsTrue(authWindow.Auth("gh", "Password1"));

        }
        [TestMethod]
        public void AuthTestFailure()
        {
            var authWindow = new MainWindow();
            Assert.IsFalse(authWindow.Auth("whoareu", "wwww1234!"));
            Assert.IsFalse(authWindow.Auth("user", "AdminPass456!"));
            Assert.IsFalse(authWindow.Auth("", "AdminPass456!"));
            Assert.IsFalse(authWindow.Auth("user", ""));
            Assert.IsFalse(authWindow.Auth("user", " "));
            Assert.IsFalse(authWindow.Auth(" ", " "));
            Assert.IsFalse(authWindow.Auth("", ""));
            Assert.IsFalse(authWindow.Auth(" user ", "Password123"));
        }
    }
}
