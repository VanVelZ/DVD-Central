using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void SeedTest()
        {
            UserManager.Seed();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LoginPass()
        {
            bool actual = UserManager.Login(new User("zjvv", "birch"));
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void LoginFail()
        {
            bool actual = UserManager.Login(new User("Greg", "maple"));
            Assert.IsFalse(actual);
        }
    }
}
