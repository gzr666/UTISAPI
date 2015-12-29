using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace UtisAPI.Models
{
    public class UtisDb:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<YearlyMembership> Memmberships { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Dug> Dugovi { get; set; }
        public DbSet<VrstaUplate> VrsteUplata { get; set; }

        public UtisDb():base("UTIS")
    {
        this.Configuration.LazyLoadingEnabled = false;

        
    
    }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}