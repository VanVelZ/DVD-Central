using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadByOrderID()
        {
            Assert.IsTrue(OrderItemManager.LoadByOrderId(5).Count == 3);
            
        }
    }
}
