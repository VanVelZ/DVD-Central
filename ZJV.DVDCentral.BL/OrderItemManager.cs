using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public static class OrderItemManager
    {
        public static int Insert(OrderItem orderItem)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem tblOrderItem = new tblOrderItem();

                    tblOrderItem.MovieID = orderItem.MovieId;
                    tblOrderItem.OrderID = orderItem.OrderId;
                    tblOrderItem.Quantity = orderItem.Quantity;
                    tblOrderItem.Cost = orderItem.Cost;

                    //example of ternary operator
                    tblOrderItem.Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(dt => dt.Id) + 1 : 1;

                    //Change the ID of the inserted Student
                    orderItem.Id = tblOrderItem.Id;

                    dc.tblOrderItems.Add(tblOrderItem);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(OrderItem orderItem)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblOrderItem updateRow = (from dt in dc.tblOrderItems
                                          where dt.Id == orderItem.Id
                                          select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.MovieID = orderItem.MovieId;
                        updateRow.OrderID = orderItem.OrderId;
                        updateRow.Quantity = orderItem.Quantity;
                        updateRow.Cost = orderItem.Cost;

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
                    tblOrderItem deleteRow = (from dt in dc.tblOrderItems
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblOrderItems.Remove(deleteRow);
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
        public static OrderItem LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblOrderItem row = (from dt in dc.tblOrderItems
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null) return new OrderItem { Id = row.Id, MovieId = row.MovieID, OrderId = row.OrderID, Quantity = row.Quantity, Cost = row.Cost };
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<OrderItem> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<OrderItem> orderItems = new List<OrderItem>();

                    foreach (tblOrderItem dt in dc.tblOrderItems)
                    {
                        orderItems.Add(new OrderItem { Id = dt.Id, MovieId = dt.MovieID, OrderId = dt.OrderID, Quantity = dt.Quantity, Cost = dt.Cost });
                    }
                    return orderItems;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<OrderItem> LoadByOrderId(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<OrderItem> orderItems = new List<OrderItem>();

                    foreach (tblOrderItem dt in dc.tblOrderItems)
                    {
                        if (id == dt.OrderID) orderItems.Add(new OrderItem { Id = dt.Id, MovieId = dt.MovieID, OrderId = dt.OrderID, Quantity = dt.Quantity, Cost = dt.Cost });
                    }  
                    return orderItems;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
