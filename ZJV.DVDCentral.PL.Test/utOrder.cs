using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void InsertTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrder newrow = new tblOrder();

                newrow.Id = -99;
                newrow.CustomerID = 1;
                newrow.OrderDate = DateTime.Now;
                newrow.UserID = 1;
                newrow.ShipDate = DateTime.Now;

                dc.tblOrders.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results == 1);
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrder row = (from dt in dc.tblOrders
                                 where dt.Id == -99
                                 select dt).FirstOrDefault();

                dc.tblOrders.Remove(row);

               
                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrder row = (from dt in dc.tblOrders
                                 where dt.Id == -99
                                 select dt).FirstOrDefault();

                if (row != null) row.OrderDate = DateTime.Now;

                int results = dc.SaveChanges();

                Assert.AreNotEqual(0, results);
            }
        }
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from order in dc.tblOrders select order;

                int rows = results.Count();

                Assert.AreNotEqual(0, rows);
                Assert.IsNotNull(rows);
            }
        }
    }
}
