using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public static class CustomerManager
    {
        public static int Insert(Customer customer)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer tblCustomer = new tblCustomer();

                    tblCustomer.FirstName = customer.FirstName;
                    tblCustomer.LastName = customer.LastName;
                    tblCustomer.Address = customer.Address;
                    tblCustomer.City = customer.City;
                    tblCustomer.State = customer.State;
                    tblCustomer.ZIP = customer.ZIP;
                    tblCustomer.UserID = customer.UserId;
                    tblCustomer.Phone = customer.Phone;

                    tblCustomer.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(dt => dt.Id) + 1 : 1;

                    customer.Id = tblCustomer.Id;

                    dc.tblCustomers.Add(tblCustomer);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static int Update(Customer customer)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblCustomer updateRow = (from dt in dc.tblCustomers
                                          where dt.Id == customer.Id
                                          select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.FirstName = customer.FirstName;
                        updateRow.LastName = customer.LastName;
                        updateRow.Address = customer.Address;
                        updateRow.City = customer.City;
                        updateRow.State = customer.State;
                        updateRow.ZIP = customer.ZIP;
                        updateRow.UserID = customer.UserId;
                        updateRow.Phone = customer.Phone;

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
                    tblCustomer deleteRow = (from dt in dc.tblCustomers
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblCustomers.Remove(deleteRow);
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
        public static Customer LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblCustomer row = (from dt in dc.tblCustomers
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null) return new Customer { Id = row.Id, FirstName = row.FirstName,LastName = row.LastName,Address = row.Address,City = row.City,State = row.State,ZIP = row.ZIP,Phone = row.Phone,UserId = row.UserID };
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Customer> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Customer> customers = new List<Customer>();

                    foreach (tblCustomer dt in dc.tblCustomers)
                    {
                        customers.Add(new Customer { Id = dt.Id, FirstName = dt.FirstName, LastName = dt.LastName, Address = dt.Address, City = dt.City, State = dt.State, ZIP = dt.ZIP, Phone = dt.Phone, UserId = dt.UserID });
                    }
                    return customers;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Customer Load(int userid)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var customer = (from c in dc.tblCustomers
                                    join u in dc.tblUsers on c.UserID equals u.Id
                                    where u.Id == userid
                                    select new
                                    {
                                        c.Id,
                                        c.FirstName,
                                        c.LastName,
                                        c.Address,
                                        c.City,
                                        c.State,
                                        c.ZIP,
                                        c.Phone,
                                        c.UserID
                                    }).FirstOrDefault();
                    if (customer == null) return new Customer();
                    return new Customer { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Address = customer.Address, City = customer.City, State = customer.State, ZIP = customer.ZIP, Phone = customer.Phone, UserId = customer.UserID };
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
