using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from rating in dc.tblRatings select rating;

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
                tblRating newrow = new tblRating();

                newrow.Id = -99;
                newrow.Description = "Z";


                dc.tblRatings.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblRating row = (from dt in dc.tblRatings
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null) row.Description = "V";

                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblRating row = (from dt in dc.tblRatings
                                 where dt.Id == -99
                                 select dt).FirstOrDefault();

                dc.tblRatings.Remove(row);

               
                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
    }
}
