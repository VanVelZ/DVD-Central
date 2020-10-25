using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadByIDTest()
        {
            Movie movie = MovieManager.LoadByID(1);
            Assert.IsNotNull(movie);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(MovieManager.Delete(3) > 0);
        }
        [TestMethod]
        public void Load()
        {
            List<Movie> movies = MovieManager.Load(1);

            Assert.IsTrue(movies[0].RatingDescription == "R");
        }
    }
}
