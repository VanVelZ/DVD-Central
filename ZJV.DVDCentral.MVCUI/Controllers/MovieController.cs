using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZJV.DVDCentral.BL;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.MVCUI.Models;
using ZJV.DVDCentral.MVCUI.ViewModels;

namespace ZJV.DVDCentral.MVCUI.Controllers
{ 
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            ViewBag.Title = "Movies";
            if (Authenticate.IsAuthenticated())
            {
                var movies = MovieManager.Load();
                return View(movies);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult Browse(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                var movies = MovieManager.Load(id);
                return View("Index", movies);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Details";
                var movie = MovieManager.LoadByID(id);
                return View(movie);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Create";
                MovieGenresDirectorsRatingsFormats mgdrf = new MovieGenresDirectorsRatingsFormats();
                mgdrf.Movie = new Movie();
                mgdrf.Directors = DirectorManager.Load();
                mgdrf.Genres = GenreManager.Load();
                mgdrf.Ratings = RatingManager.Load();
                mgdrf.Formats = FormatManager.Load();

                return View(mgdrf);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieGenresDirectorsRatingsFormats mgdrf)
        {
            try
            {
                if(mgdrf.File != null)
                {
                    mgdrf.Movie.ImagePath = mgdrf.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(mgdrf.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        mgdrf.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully";
                    }
                    else
                    {

                        ViewBag.Message = "File did not upload";
                    }
                }
                // TODO: Add insert logic here
                MovieManager.Insert(mgdrf.Movie);
                mgdrf.GenreIds.ToList().ForEach(a => MovieGenresDirectorsRatingsFormatsManager.Add(mgdrf.Movie.Id, a));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(mgdrf);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {

                ViewBag.Title = "Edit";
                MovieGenresDirectorsRatingsFormats mgdrf = new MovieGenresDirectorsRatingsFormats();
                mgdrf.Movie = MovieManager.LoadByID(id);
                mgdrf.Directors = DirectorManager.Load();
                mgdrf.Genres = GenreManager.Load();
                mgdrf.Ratings = RatingManager.Load();
                mgdrf.Formats = FormatManager.Load();

                IEnumerable<int> existingGenreIds = new List<int>();
                mgdrf.Movie.Genres = MovieManager.LoadGenres(id);
                mgdrf.GenreIds = mgdrf.Movie.Genres.Select(a => a.Id);

                //put genres in session
                Session["genreids"] = mgdrf.GenreIds;
                return View(mgdrf);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieGenresDirectorsRatingsFormats mgdrf)
        {
            try
            {
                if (mgdrf.File != null)
                {
                    mgdrf.Movie.ImagePath = mgdrf.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(mgdrf.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        mgdrf.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully";
                    }
                    else
                    {

                        ViewBag.Message = "File did not upload";
                    }
                }
                //deal with genres
                IEnumerable<int> oldGenres = new List<int>();
                if(Session["genreids"] != null) oldGenres = (IEnumerable<int>)Session["genreids"];
                IEnumerable<int> newGenres = new List<int>();
                if (mgdrf.GenreIds != null) newGenres = mgdrf.GenreIds;

                //deletes
                IEnumerable<int> deletes = oldGenres.Except(newGenres);
                //adds
                IEnumerable<int> adds = newGenres.Except(oldGenres);

                deletes.ToList().ForEach(d => MovieGenresDirectorsRatingsFormatsManager.Delete(id, d));
                adds.ToList().ForEach(a => MovieGenresDirectorsRatingsFormatsManager.Add(id, a));


                // TODO: Add update logic here
                MovieManager.Update(mgdrf.Movie);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ViewBag.Title = "Delete";
                var movie = MovieManager.LoadByID(id);
                return View(movie);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MovieManager.Delete(id);
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
