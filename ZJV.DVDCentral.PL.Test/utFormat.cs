using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from format in dc.tblFormats select format;

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
                tblFormat newrow = new tblFormat();

                newrow.Id = -99;
                newrow.Description = "ZZZ";


                dc.tblFormats.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblFormat row = (from dt in dc.tblFormats
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();


                if (row != null) row.Description = "VV";

                
                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblFormat row = (from dt in dc.tblFormats
                                 where dt.Id == -99
                                 select dt).FirstOrDefault();

                dc.tblFormats.Remove(row);

                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
    }
}
