using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZJV.DVDCentral.BL;

namespace ZJV.DVDCentral.MVCUI.Models
{
    public static class Authenticate
    {
        public static bool IsAuthenticated()
        {
            if (HttpContext.Current.Session == null) return false;
            else return HttpContext.Current.Session["user"] != null;
        }
    }
}