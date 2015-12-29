using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtisAPI.Models
{
    public class Dug
    {
        public int DugID { get; set; }

        public double Amount { get; set; }

        public int UserID{get;set;}
        public User user { get; set; }
        public int YearID { get; set; }
        public  Year year { get; set; }
    }
}