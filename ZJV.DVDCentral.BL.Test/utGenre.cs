using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Genre> genres = GenreManager.Load();
            Assert.IsTrue(genres.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            Genre genre = new Genre();
            genre.Description = "Bananas";
            Assert.IsTrue(GenreManager.Insert(genre) > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Genre genre = GenreManager.LoadByID(1);
            genre.Description = "Oops";
            Assert.IsTrue(GenreManager.Update(genre) > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(GenreManager.Delete(4) > 0);
        }
    }
}
