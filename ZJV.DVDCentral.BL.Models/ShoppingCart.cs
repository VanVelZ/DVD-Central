using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJV.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        public List<Movie> Items { get; set; }
        public int ShoppingCount { get { return Items.Count; } }
        public double TotalCost { get; set; }


        public ShoppingCart()
        {
            Items = new List<Movie>();
        }
        public void Add(Movie movie)
        {
            Items.Add(movie);
            TotalCost += movie.Cost;
        }
        public void Remove(Movie movie)
        {
            Items.Remove(movie);
            TotalCost -= movie.Cost;
        }
    }
}
