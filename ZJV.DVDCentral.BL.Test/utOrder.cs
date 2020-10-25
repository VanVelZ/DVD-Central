using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadbyCustomerId()
        {
            List<Order> orders = OrderManager.LoadByCustomerId(1);

            Assert.IsTrue(orders.Count == 2);
        }
        [TestMethod]
        public void Insert()
        {
            OrderItem oi = new OrderItem { OrderId = 5, MovieId = 1, Quantity = 1, Cost = 13 };
            Order order = new Order { CustomerId = 1, OrderDate = DateTime.Now, ShipDate = DateTime.Now };

            int result = OrderManager.Insert(order);
            result += OrderItemManager.Insert(oi);

            Assert.IsTrue(result == 2);

        }
        [TestMethod]
        public void Delete()
        {

            int result = OrderManager.Delete(4);

            Assert.IsTrue(result == 1);

        }
        [TestMethod]
        public void Update()
        {

            Order order = new Order {Id = 4, CustomerId = 2, OrderDate = DateTime.Now, ShipDate = DateTime.Now };

            int result =  OrderManager.Update(order);
            Assert.IsTrue(result == 1);

        }
        [TestMethod]
        public void Load()
        {
            Assert.IsTrue(OrderManager.Load().Count == 6);
        }
    }
}
