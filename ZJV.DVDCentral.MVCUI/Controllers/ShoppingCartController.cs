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
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                GetShoppingCart();
                return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        [ChildActionOnly]
        public ActionResult CartDisplay()
        {
            GetShoppingCart();
            return PartialView(cart);
        }
        public ActionResult Remove(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                GetShoppingCart();
                Movie movie = cart.Items.FirstOrDefault(i => i.Id == id);
                ShoppingCartManager.Remove(cart, movie);
                Session["cart"] = cart;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult Add(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                GetShoppingCart();
                Movie movie = MovieManager.LoadByID(id);
                ShoppingCartManager.Add(cart, movie);
                Session["cart"] = cart;
                return RedirectToAction("Index", "Movie");
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult Checkout()
        {
            if (Authenticate.IsAuthenticated())
            {
                GetShoppingCart();
                if (cart != null)
                {
                    return RedirectToAction("Assign");
                }
                else
                {
                    ViewBag.Message = "No items in Cart";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        [HttpGet]
        public ActionResult Assign()
        {
            if (Authenticate.IsAuthenticated())
            {
                User user = (User)Session["user"];
                CartCustomers cc = new CartCustomers();

                cc.Customers = CustomerManager.Load();

                cc.CustomerId = CustomerManager.Load(user.Id).Id;
                //if customer id is set by the load method, go ahead and complete the order
                if (cc.CustomerId != 0)
                {
                    Assign(cc);
                    return RedirectToAction("Thanks");
                }
                //An employee is logged in and needs to assign a customer
                else
                {
                    Session["cc"] = cc;
                    return View(cc);
                }
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

            }

        }
        [HttpPost]
        public ActionResult Assign(CartCustomers cc)
        {
            GetShoppingCart();
            User user = (User)Session["user"];
            cc.Cart = cart;
            ShoppingCartManager.Checkout(cc.Cart, user.Id, cc.CustomerId);
            Session["cc"] = null;
            Session["cart"] = null;
            return RedirectToAction("Thanks");
        }
        public ActionResult Thanks()
        {
            return View("Thanks");
        }
        private void GetShoppingCart()
        {
            if (Session["cart"] == null) cart = new ShoppingCart();
            else cart = (ShoppingCart)Session["cart"];
        }

    }
}