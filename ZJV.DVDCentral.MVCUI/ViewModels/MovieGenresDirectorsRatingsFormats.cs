using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZJV.DVDCentral.BL.Models;

namespace ZJV.DVDCentral.MVCUI.ViewModels
{
    public class MovieGenresDirectorsRatingsFormats
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Director> Directors { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Format> Formats { get; set; }

        public IEnumerable<int> GenreIds { get; set; }
        public HttpPostedFileBase File { get; set; }

        public MovieGenresDirectorsRatingsFormats()
        {
            Genres = new List<Genre>();
            Directors = new List<Director>();
            Ratings = new List<Rating>();
            Formats = new List<Format>();
        }
    }
}