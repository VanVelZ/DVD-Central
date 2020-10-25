using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Director> directors = DirectorManager.Load();
            Assert.IsTrue(directors.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            Director director = new Director();
            director.FirstName = "Bananas";
            director.LastName = "Bananas";
            Assert.IsTrue(DirectorManager.Insert(director) > 0);
        }
    }
}
