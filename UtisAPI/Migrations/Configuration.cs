namespace UtisAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UtisAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UtisAPI.Models.UtisDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UtisAPI.Models.UtisDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Years.AddOrUpdate(

                    new Year { 
                    
                        BeginDate = new DateTime(2014,1,1),
                        
                        
                    
                    },
                     new Year
                     {

                         BeginDate = new DateTime(2015, 1, 1)
                         


                     }
                     

                );
            context.VrsteUplata.AddOrUpdate(

                    new VrstaUplate { Name = "Gotovina" },
                    new VrstaUplate { Name="Žiro"}


                );
        }
    }
}
