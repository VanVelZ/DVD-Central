using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from genre in dc.tblGenres select genre;

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
                tblGenre newrow = new tblGenre();

                newrow.Id = -99;
                newrow.Description = "Children's Cartoon";

                dc.tblGenres.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
            
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblGenre row = (from dt in dc.tblGenres
                                where dt.Id == -99
                                select dt).FirstOrDefault();

                dc.tblGenres.Remove(row);


                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
    }
}
