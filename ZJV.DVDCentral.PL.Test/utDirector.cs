using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from director in dc.tblDirectors select director;

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
                tblDirector newrow = new tblDirector();

                newrow.Id = -99;
                newrow.FirstName = "Johnny";
                newrow.LastName = "Johnny";


                dc.tblDirectors.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                //get row that I want to update
                //SELECT * gtp, tblDegreeType where id = -99
                tblDirector row = (from dt in dc.tblDirectors
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                //change the values to something else
                if (row != null) { row.FirstName = "Test"; row.LastName = "Tester"; }

                //save changes
                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
    }
}
