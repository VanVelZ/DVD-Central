using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Rating> ratings = RatingManager.Load();
            Assert.IsTrue(ratings.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            Rating rating = new Rating();
            rating.Description = "Bananas";
            Assert.IsTrue(RatingManager.Insert(rating) > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Rating rating = RatingManager.LoadByID(1);
            rating.Description = "Oo";
            Assert.IsTrue(RatingManager.Update(rating) > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(RatingManager.Delete(4) > 0);
        }
    }
}
