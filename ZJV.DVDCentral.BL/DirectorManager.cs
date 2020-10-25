using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class DirectorManager
    {
        public static int Insert(Director director)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblDirector tblDirector = new tblDirector();

                    tblDirector.FirstName = director.FirstName;
                    tblDirector.LastName = director.LastName;

                    //example of ternary operator
                    tblDirector.Id = dc.tblDirectors.Any() ? dc.tblDirectors.Max(dt => dt.Id) + 1 : 1;

                    //Change the ID of the inserted Student
                    director.Id = tblDirector.Id;

                    dc.tblDirectors.Add(tblDirector);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Director director)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblDirector updateRow = (from dt in dc.tblDirectors
                                             where dt.Id == director.Id
                                            select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.FirstName = director.FirstName;
                        updateRow.LastName = director.LastName;

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
                    tblDirector deleteRow = (from dt in dc.tblDirectors
                                             where dt.Id == id
                                            select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblDirectors.Remove(deleteRow);
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
        public static Director LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblDirector row = (from dt in dc.tblDirectors
                                       where dt.Id == id
                                      select dt).FirstOrDefault();

                    if (row != null) return new Director { Id = row.Id, FirstName = row.FirstName, LastName = row.LastName};
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Director> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Director> ratings = new List<Director>();

                    foreach (tblDirector dt in dc.tblDirectors)
                    {
                        ratings.Add(new Director { Id = dt.Id, FirstName = dt.FirstName, LastName = dt.LastName });
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
