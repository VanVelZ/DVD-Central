using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZJV.DVDCentral.BL;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.MVCUI.Models;

namespace ZJV.DVDCentral.MVCUI.Controllers
{
    #region pre Web-API
    public class FormatController : Controller
    {
        // GET: Format
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Format";
                var formats = FormatManager.Load();
                return View(formats);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Format/Details/5
        public ActionResult Details(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Details";
                var format = FormatManager.LoadByID(id);
                return View(format);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Format/Create
        public ActionResult Create()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Create";
                Format format = new Format();
                return View(format);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Format/Create
        [HttpPost]
        public ActionResult Create(Format format)
        {
            try
            {
                // TODO: Add insert logic here
                FormatManager.Insert(format);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(format);
            }
        }

        // GET: Format/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Edit";
                var format = FormatManager.LoadByID(id);
                return View(format);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Format/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Format format)
        {
            try
            {
                // TODO: Add update logic here
                FormatManager.Update(format);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(format);
            }
        }

        // GET: Format/Delete/5
        public ActionResult Delete(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Delete";
                var format = FormatManager.LoadByID(id);
                return View(format);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Format/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                FormatManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        #endregion
        #region "WebAPI"
        private static HttpClient InitalizeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/api/");
            return client;
        }

        public ActionResult Get()
        {
            HttpClient client = InitalizeClient();

            //call the api
            HttpResponseMessage response = client.GetAsync("Format").Result;

            //parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);

            //parse the items into a list of format objects
            List<Format> formats = items.ToObject<List<Format>>();

            ViewBag.Source = "Get";
            return View("Index", formats);
        }
        public ActionResult GetOne(int id)
        {
            HttpClient client = InitalizeClient();

            //call the api
            HttpResponseMessage response = client.GetAsync("Format/" + id).Result;

            //parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //parse the result into generic objects
            Format format = JsonConvert.DeserializeObject<Format>(result);

            return View("Details", format);
        }

        public ActionResult Insert()
        {
            HttpClient client = InitalizeClient();
            Format format = new Format();
            return View("Create", format);

        }

        [HttpPost]
        public ActionResult Insert(Format format)
        {
            try
            {

                HttpClient client = InitalizeClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Format", format).Result;

                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", format);
            }

        }
        public ActionResult Update(int id)
        {
            HttpClient client = InitalizeClient();

            HttpResponseMessage response = client.GetAsync("Format/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Format format = JsonConvert.DeserializeObject<Format>(result);

            return View("Edit", format);

        }

        [HttpPost]
        public ActionResult Update(int id, Format format)
        {
            try
            {
                HttpClient client = InitalizeClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Format/" + id, format).Result;

                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", format);
            }

        }
        public ActionResult Remove(int id)
        {
            HttpClient client = InitalizeClient();
            HttpResponseMessage response = client.GetAsync("Format/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Format format = JsonConvert.DeserializeObject<Format>(result);
            return View("Delete", format);

        }
        [HttpPost]
        public ActionResult Remove(int id, Format format)
        {
            try
            {
                HttpClient client = InitalizeClient();
                HttpResponseMessage response = client.DeleteAsync("Format/" + id).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", format);
            }
        }
        #endregion

    }
}
