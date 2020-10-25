using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class MovieGenresDirectorsRatingsFormatsManager
    {
        public static void Add(int movieid, int genreid)
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblMovieGenre mg = new tblMovieGenre();
                mg.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(p => p.Id) + 1 : 1;
                mg.MovieID = movieid;
                mg.GenreID = genreid;

                dc.tblMovieGenres.Add(mg);
                dc.SaveChanges();
            }
        }
        public static void Delete(int movieid, int genreid)
        {

            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblMovieGenre mg = dc.tblMovieGenres.FirstOrDefault(m => m.MovieID == movieid
                                    && m.GenreID == genreid);

                if(mg != null)
                {
                    dc.tblMovieGenres.Remove(mg);
                    dc.SaveChanges();
                }
            }
        }
    }
}
