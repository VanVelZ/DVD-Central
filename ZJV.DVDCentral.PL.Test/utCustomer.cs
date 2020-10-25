using System;
using ZJV.DVDCentral.PL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ZJV.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {

                var results = from customer in dc.tblCustomers select customer;

                int rows = results.Count();

                Assert.AreNotEqual(0, rows);
                Assert.IsNotNull(rows);
            }
        }
    }
}
