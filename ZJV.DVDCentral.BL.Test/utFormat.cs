using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Format> formats = FormatManager.Load();
            Assert.IsTrue(formats.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            Format format = new Format();
            format.Description = "Bananas";
            Assert.IsTrue(FormatManager.Insert(format) > 0);
        }
    }
}
