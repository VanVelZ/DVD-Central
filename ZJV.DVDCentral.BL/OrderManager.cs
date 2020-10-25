using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public static class OrderManager
    {

        public static int Insert(Order order)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder tblOrder = new tblOrder();

                    tblOrder.CustomerID = order.CustomerId;
                    tblOrder.OrderDate = order.OrderDate;
                    tblOrder.ShipDate = order.ShipDate;
                    tblOrder.UserID = order.UserId;

                    //example of ternary operator
                    tblOrder.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(dt => dt.Id) + 1 : 1;

                    //Change the ID of the inserted Student
                    order.Id = tblOrder.Id;

                    dc.tblOrders.Add(tblOrder);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Order order)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblOrder updateRow = (from dt in dc.tblOrders
                                             where dt.Id == order.Id
                                             select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.CustomerID = order.CustomerId;
                        updateRow.OrderDate = order.OrderDate;
                        updateRow.ShipDate = order.ShipDate;
                        updateRow.UserID = order.UserId;

                        return dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to delete
                    tblOrder deleteRow = (from dt in dc.tblOrders
                                             where dt.Id == id
                                             select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblOrders.Remove(deleteRow);
                        return dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Order LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblOrder row = (from dt in dc.tblOrders
                                       where dt.Id == id
                                       select dt).FirstOrDefault();

                    if (row != null) return new Order { Id = row.Id, CustomerId = row.CustomerID, UserId = row.UserID, ShipDate = row.ShipDate, OrderDate = row.OrderDate };
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Order> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Order> orders = new List<Order>();

                    foreach (tblOrder dt in dc.tblOrders)
                    {
                        orders.Add(new Order { Id = dt.Id, CustomerId = dt.CustomerID, UserId = dt.UserID, ShipDate = dt.ShipDate, OrderDate = dt.OrderDate });
                    }
                    return orders;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Order> LoadByCustomerId(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Order> orders = new List<Order>();

                    foreach (tblOrder dt in dc.tblOrders)
                    {
                        if(id == dt.CustomerID)orders.Add(new Order { Id = dt.Id, CustomerId = dt.CustomerID, UserId = dt.UserID, ShipDate = dt.ShipDate, OrderDate = dt.OrderDate });
                    }
                    return orders;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
