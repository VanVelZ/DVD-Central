using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class GenreManager
    {
        public static int Insert(Genre genre)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblGenre tblGenre = new tblGenre();

                    tblGenre.Description = genre.Description;

                    //example of ternary operator
                    tblGenre.Id = dc.tblGenres.Any() ? dc.tblGenres.Max(dt => dt.Id) + 1 : 1;

                    //Change the ID of the inserted Student
                    genre.Id = tblGenre.Id;

                    dc.tblGenres.Add(tblGenre);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Genre genre)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblGenre updateRow = (from dt in dc.tblGenres
                                             where dt.Id == genre.Id
                                            select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.Description = genre.Description;
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
                    tblGenre deleteRow = (from dt in dc.tblGenres
                                             where dt.Id == id
                                            select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblGenres.Remove(deleteRow);
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
        public static Genre LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblGenre row = (from dt in dc.tblGenres
                                       where dt.Id == id
                                      select dt).FirstOrDefault();

                    if (row != null) return new Genre { Id = row.Id, Description = row.Description };
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Genre> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Genre> genres = new List<Genre>();

                    foreach (tblGenre dt in dc.tblGenres)
                    {
                        genres.Add(new Genre { Id = dt.Id, Description = dt.Description });
                    }
                    return genres;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Genre> Load(int movieid)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Genre> results = new List<Genre>();

                    var genres = (from g in dc.tblGenres
                                  join mg in dc.tblMovieGenres on g.Id equals mg.GenreID
                                  where mg.MovieID == movieid
                                  select new
                                  {
                                      g.Id,
                                      g.Description
                                  }).ToList();
                    genres.ForEach(r => results.Add(new Genre { Id = r.Id, Description = r.Description }));
                    return results;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
