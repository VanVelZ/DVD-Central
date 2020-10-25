using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class RatingManager
    {
        public static int Insert(Rating rating)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblRating tblRating = new tblRating();

                    tblRating.Description = rating.Description;

                    //example of ternary operator
                    tblRating.Id = dc.tblRatings.Any() ? dc.tblRatings.Max(dt => dt.Id) + 1 : 1;

                    //Change the ID of the inserted Student
                    rating.Id = tblRating.Id;

                    dc.tblRatings.Add(tblRating);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Rating rating)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblRating updateRow = (from dt in dc.tblRatings
                                            where dt.Id == rating.Id
                                            select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.Description = rating.Description;
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
                    tblRating deleteRow = (from dt in dc.tblRatings
                                            where dt.Id == id
                                            select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblRatings.Remove(deleteRow);
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
        public static Rating LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblRating row = (from dt in dc.tblRatings
                                      where dt.Id == id
                                      select dt).FirstOrDefault();

                    if (row != null) return new Rating { Id = row.Id, Description = row.Description };
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Rating> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Rating> ratings = new List<Rating>();

                    foreach (tblRating dt in dc.tblRatings)
                    {
                        ratings.Add(new Rating { Id = dt.Id, Description = dt.Description });
                    }
                    return ratings;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
