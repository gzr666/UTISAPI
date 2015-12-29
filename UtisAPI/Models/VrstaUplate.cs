using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UtisAPI.Models
{
    public class VrstaUplate
    {
        public int ID { get; set; }

       
        public string Name { get; set; }

        public ICollection<YearlyMembership> Memberships { get; set; }
    }
}