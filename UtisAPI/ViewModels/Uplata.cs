using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UtisAPI.ViewModels
{
    public class Uplata
    {
        public double Amount { get; set; }
        public int UserId { get; set; }
        [Required]
        public int YearId { get; set; }
        public int VrstaId { get; set; }
        public DateTime Datum { get; set; }

    }
}