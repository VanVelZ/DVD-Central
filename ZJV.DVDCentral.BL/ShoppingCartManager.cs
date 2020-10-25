using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.PL;
using ZJV.DVDCentral.BL.Models;
namespace ZJV.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Checkout(ShoppingCart cart, int userid, int customerid)
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                Order order = new Order { UserId = userid, CustomerId = customerid, OrderDate = DateTime.Now, ShipDate = DateTime.Now };
                OrderManager.Insert(order);

                foreach(Movie movie in cart.Items)
                {
                    OrderItemManager.Insert(new OrderItem { Cost = movie.Cost, Quantity = 1, MovieId = movie.Id, OrderId = order.Id });
                }
            }

        }
        public static void Add(ShoppingCart cart, Movie movie)
        {
            cart.Add(movie);
        }
        public static void Remove(ShoppingCart cart, Movie movie)
        {
            cart.Remove(movie);
        }
    }
}
