using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.MVCUI.ViewModels
{
    public class CartCustomers
    {
        public ShoppingCart Cart { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public int CustomerId { get; set; }
    }
}