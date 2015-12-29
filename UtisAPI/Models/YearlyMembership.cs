using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UtisAPI.Models
{
    public class YearlyMembership
    {
        public int ID { get; set; }
        [Required]
        public double Amount { get; set; }
        public DateTime DatumUplate { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int YearId { get; set; }
        public Year Year { get; set; }


        public int VrstaUplateID { get; set; }
        public VrstaUplate VrstaUplate { get; set; }

        


    }
}