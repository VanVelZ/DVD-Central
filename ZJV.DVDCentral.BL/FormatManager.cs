using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class FormatManager
    {
        public static int Insert(Format format)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat tblFormat = new tblFormat();

                    tblFormat.Description = format.Description;

                    //example of ternary operator
                    tblFormat.Id = dc.tblFormats.Any() ? dc.tblFormats.Max(dt => dt.Id) + 1 : 1;

                    //Change the ID of the inserted Student
                    format.Id = tblFormat.Id;

                    dc.tblFormats.Add(tblFormat);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(Format format)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to update
                    tblFormat updateRow = (from dt in dc.tblFormats
                                             where dt.Id == format.Id
                                            select dt).FirstOrDefault();

                    if (updateRow != null)
                    {
                        updateRow.Description = format.Description;
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
                    tblFormat deleteRow = (from dt in dc.tblFormats
                                             where dt.Id == id
                                            select dt).FirstOrDefault();

                    if (deleteRow != null)
                    {
                        dc.tblFormats.Remove(deleteRow);
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
        public static Format LoadByID(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //get the row i want to load
                    tblFormat row = (from dt in dc.tblFormats
                                       where dt.Id == id
                                      select dt).FirstOrDefault();

                    if (row != null) return new Format { Id = row.Id, Description = row.Description };
                    else throw new Exception("Row not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Format> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Format> ratings = new List<Format>();

                    foreach (tblFormat dt in dc.tblFormats)
                    {
                        ratings.Add(new Format { Id = dt.Id, Description = dt.Description });
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
