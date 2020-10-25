using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from movie in dc.tblMovies select movie;

                int rows = results.Count();

                Assert.AreNotEqual(0, rows);
                Assert.IsNotNull(rows);
            }
        }
        [TestMethod]
        public void InsertTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblMovie newrow = new tblMovie();

                newrow.Id = -99;
                newrow.Title = "Test Movie";
                newrow.Description = "It's just a test";
                newrow.Cost = 1.22;
                newrow.RatingID = -99;
                newrow.FormatID = -99; 
                newrow.DirectorID = -99;
                newrow.InStkQty = -99;
                newrow.ImagePath = "ahhhhhh";



                dc.tblMovies.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
        }
    }
}
