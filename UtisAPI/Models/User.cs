using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UtisAPI.Models
{
    public class User
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Unesi Ime")]
        [StringLength(20, ErrorMessage = "Ime ne smije biti dulje od 20 slova")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unesi Prezime")]
        [StringLength(20, ErrorMessage = "Prezime ne smije biti dulje od 20 slova")]
        public string Surname { get; set; }

        [Required]   
        [DataType(DataType.DateTime)]
        public DateTime DateJoined { get; set; }

        //navigational propeties
        public virtual ICollection<YearlyMembership> Memmberships { get; set; }
        public virtual ICollection<Dug> Dugovi { get; set; }



    }
}