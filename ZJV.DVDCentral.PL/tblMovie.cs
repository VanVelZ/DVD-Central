//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZJV.DVDCentral.PL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int RatingID { get; set; }
        public int FormatID { get; set; }
        public int DirectorID { get; set; }
        public int InStkQty { get; set; }
        public string ImagePath { get; set; }
    }
}