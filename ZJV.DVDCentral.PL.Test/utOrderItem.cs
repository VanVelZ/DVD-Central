using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void InsertTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrderItem newrow = new tblOrderItem();

                newrow.Id = -99;
                newrow.MovieID = 1;
                newrow.OrderID = 1;
                newrow.Quantity = 1;
                newrow.Cost = 10;

                dc.tblOrderItems.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrderItem row = (from dt in dc.tblOrderItems
                                    where dt.Id == -99
                                select dt).FirstOrDefault();

                dc.tblOrderItems.Remove(row);


                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrderItem row = (from dt in dc.tblOrderItems
                                where dt.Id == -99
                                select dt).FirstOrDefault();

                if (row != null) row.Cost = 9.99;

                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from order in dc.tblOrderItems select order;

                int rows = results.Count();

                Assert.AreNotEqual(0, rows);
                Assert.IsNotNull(rows);
            }
        }
    }
}
