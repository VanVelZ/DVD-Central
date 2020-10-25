using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class MovieManager
    {
        public static int Insert(Movie movie)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie tblMovie = new tblMovie();

                    tblMovie.Title = movie.Title;
                    tblMovie.Description = movie.Description;
                    tblMovie.Cost = movie.Cost;
                    tblMovie.RatingID = movie.RatingID;
                    tblMovie.DirectorID = movie.DirectorID;
                    tblMovie.FormatID = movie.FormatID;
                    tblMovie.InStkQty = movie.InStkQty;
                    tblMovie.ImagePath = movie.ImagePath;

                    tblMovie.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(dt => dt.Id) + 1 : 1;

                    movie.Id = tblMovie.Id;

                    dc.tblMovies.Add(tblMovie);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Movie movie)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblMovie updateRow = (from dt in dc.tblMovies
                                          where dt.Id == movie.Id
                                          select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.Title = movie.Title;
                        updateRow.Description = movie.Description;
                        updateRow.Cost = movie.Cost;
                        updateRow.RatingID = movie.RatingID;
                        updateRow.DirectorID = movie.DirectorID;
                        updateRow.FormatID = movie.FormatID;
                        updateRow.InStkQty = movie.InStkQty;
                        updateRow.ImagePath = movie.ImagePath;
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
                    tblMovie deleteRow = (from dt in dc.tblMovies
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblMovies.Remove(deleteRow);
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
        public static Movie LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var movie = (from pd in dc.tblMovies
                                  join r in dc.tblRatings on pd.RatingID equals r.Id
                                  join d in dc.tblDirectors on pd.DirectorID equals d.Id
                                  join f in dc.tblFormats on pd.FormatID equals f.Id
                                  where (pd.Id == id || pd == null)
                                  orderby pd.Title
                                  select new
                                  {
                                      MovieId = pd.Id,
                                      RatingId = r.Id,
                                      DirectorId = d.Id,
                                      FormatId = f.Id,
                                      pd.Title,
                                      pd.ImagePath,
                                      pd.Cost,
                                      pd.Description,
                                      DirectorName = d.LastName + " " + d.FirstName,
                                      FormatName = f.Description,
                                      RatingName = r.Description,
                                      Quantity = pd.InStkQty
                                  }).FirstOrDefault();

                    if (movie != null)
                        return new Movie
                        {
                            Id = movie.MovieId,
                            RatingID = movie.RatingId,
                            DirectorID = movie.DirectorId,
                            FormatID = movie.FormatId,
                            Title = movie.Title,
                            ImagePath = movie.ImagePath,
                            Cost = movie.Cost,
                            Description = movie.Description,
                            DirectorFullname = movie.DirectorName,
                            FormatDescription = movie.FormatName,
                            InStkQty = movie.Quantity,
                            RatingDescription = movie.RatingName
                        };
                    else throw new Exception("Row was not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Movie> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Movie> results = new List<Movie>();

                    var movies = (from pd in dc.tblMovies
                                  join r in dc.tblRatings on pd.RatingID equals r.Id
                                  join d in dc.tblDirectors on pd.DirectorID equals d.Id
                                  join f in dc.tblFormats on pd.FormatID equals f.Id
                                  orderby pd.Title
                                  select new
                                  {
                                      MovieId = pd.Id,
                                      RatingId = r.Id,
                                      DirectorId = d.Id,
                                      FormatId = f.Id,
                                      pd.Title,
                                      pd.ImagePath,
                                      pd.Cost,
                                      pd.Description,
                                      DirectorName = d.LastName + ", " + d.FirstName,
                                      FormatName = f.Description,
                                      RatingName = r.Description,
                                      Quantity = pd.InStkQty
                                  }).ToList();
                    movies.ForEach(p => results.Add(new Movie
                    {
                        Id = p.MovieId,
                        RatingID = p.RatingId,
                        DirectorID = p.DirectorId,
                        FormatID = p.FormatId,
                        Title = p.Title,
                        ImagePath = p.ImagePath,
                        Cost = p.Cost,
                        Description = p.Description,
                        DirectorFullname = p.DirectorName,
                        FormatDescription = p.FormatName,
                        InStkQty = p.Quantity,
                        RatingDescription = p.RatingName
                    }));
                    return results;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Movie> Load(int? genreId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Movie> results = new List<Movie>();

                    var movies = (from m in dc.tblMovies
                                  join r in dc.tblRatings on m.RatingID equals r.Id
                                  join d in dc.tblDirectors on m.DirectorID equals d.Id
                                  join f in dc.tblFormats on m.FormatID equals f.Id
                                  join g in dc.tblMovieGenres on m.Id equals g.MovieID
                                  where (g.GenreID == genreId || genreId == null)
                                  orderby m.Title
                                  select new
                                  {
                                      MovieId = m.Id,
                                      RatingId = r.Id,
                                      DirectorId = d.Id,
                                      FormatId = f.Id,
                                      m.Title,
                                      m.ImagePath,
                                      m.Cost,
                                      m.Description,
                                      DirectorName = d.LastName + ", " + d.FirstName,
                                      FormatName = f.Description,
                                      RatingName = r.Description,
                                      Quantity = m.InStkQty
                                  }).ToList();
                    movies.ForEach(p => results.Add(new Movie
                    {
                        Id = p.MovieId,
                        RatingID = p.RatingId,
                        DirectorID = p.DirectorId,
                        FormatID = p.FormatId,
                        Title = p.Title,
                        ImagePath = p.ImagePath,
                        Cost = p.Cost,
                        Description = p.Description,
                        DirectorFullname = p.DirectorName,
                        FormatDescription = p.FormatName,
                        InStkQty = p.Quantity,
                        RatingDescription = p.RatingName
                    }));
                    return results;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Genre> LoadGenres(int movieid)
        {
           return GenreManager.Load(movieid);
        }
    }
}