using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtisAPI.Models
{
    public class Year
    {

        public int ID { get; set; }
        public DateTime BeginDate { get; set; }

        public virtual ICollection<YearlyMembership> Memneberships { get; set; }
        public virtual ICollection<Dug> dugovi { get; set; }

    }
}