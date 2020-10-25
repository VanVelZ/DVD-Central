using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJV.DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public Double Cost { get; set; }
        public int RatingID { get; set; }
        public int FormatID { get; set; }
        public int DirectorID { get; set; }
        public int InStkQty { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }
        [DisplayName("Rating")]
        public string RatingDescription { get; set; }
        [DisplayName("Format")]
        public string FormatDescription { get; set; }
        [DisplayName("Director")]
        public string DirectorFullname { get; set; }
        public List<Genre> Genres { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
        }
    }
}
