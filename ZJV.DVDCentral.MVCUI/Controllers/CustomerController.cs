using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZJV.DVDCentral.BL;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.MVCUI.Models;
using ZJV.DVDCentral.MVCUI.ViewModels;

namespace ZJV.DVDCentral.MVCUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Customer";
                var customers = CustomerManager.Load();
                return View(customers);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Details";
                var customer = CustomerManager.LoadByID(id);
                return View(customer);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Create";
                Customer customer = new Customer();
                return View(customer);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if (Session["cc"] == null)
                {
                    CustomerManager.Insert(customer);
                    return RedirectToAction("Index");
                }
                else
                {
                    CartCustomers cc = (CartCustomers)Session["cc"];
                    Session["cc"] = null;
                    CustomerManager.Insert(customer);
                    return RedirectToAction("Assign", "ShoppingCart", cc);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(customer);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Edit";
                var customer = CustomerManager.LoadByID(id);
                return View(customer);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                CustomerManager.Update(customer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(customer);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Delete";
                var customer = CustomerManager.LoadByID(id);
                return View(customer);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CustomerManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
    }
}
