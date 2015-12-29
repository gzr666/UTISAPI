using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtisAPI.Models;
using UtisAPI.ViewModels;

namespace UtisAPI.Repositories
{
    public class MembershipRepo : IMembershipRepo
    {
        private UtisDb db;



        public MembershipRepo(UtisDb db)
        {

            this.db = db;
        
        }


        public IQueryable<Year> GetMembershipsYears()
        {

            return db.Years;

        }


        public IQueryable<VrstaUplate> GetMembershipTypes()
        {
            return db.VrsteUplata;
        }


        public MembershipTotal GetTotal(int UserID, int YearID)
        {
            var user = db.Users.Include("Memmberships").Where(u => u.ID == UserID).First();

            MembershipTotal total = new MembershipTotal();
            int ukupnaClanarina;
            int mjesecnaClanarina = 300 / 12;
            Year godinaClanarine = db.Years.Find(YearID);

            if (user.DateJoined.Year > godinaClanarine.BeginDate.Year)
            {
                ukupnaClanarina = 0;
            }
            else
            {

                if (user.DateJoined.Year == godinaClanarine.BeginDate.Year)
                {
                    //ukoliko je user uclanjen u istoj godini kao ona za koju se upalcuje clanarina tada moramo umanjiti ukupnu godisnju clanarinu
                    ukupnaClanarina = (12 - user.DateJoined.Month) * mjesecnaClanarina;

                }
                else
                {

                    ukupnaClanarina = 300;

                }

            }


            var ukupnaTrenutnaUplata = user.Memmberships.Where(d => d.YearId == YearID).Sum(m => m.Amount);

            total.UkupnoUplaceno = ukupnaTrenutnaUplata;
            total.PreostaloZaUplatu = ukupnaClanarina - ukupnaTrenutnaUplata;
            total.GodisnjaClanarina = ukupnaClanarina;





            return total;

        
        }


        //INSERTS




        public YearlyMembership InsertMembership(Uplata uplata)
        {
            YearlyMembership membership = new YearlyMembership();
            User user = db.Users.Find(uplata.UserId);
            Year year = db.Years.Find(uplata.YearId);
            VrstaUplate vrstaUplate = db.VrsteUplata.Find(uplata.VrstaId);

            //inicijaliziraj membership
            membership.User = user;
            membership.Year = year;
            membership.VrstaUplate = vrstaUplate;
            membership.Amount = uplata.Amount;
            membership.UserId = uplata.UserId;
            membership.YearId = uplata.YearId;
            membership.VrstaUplateID = uplata.VrstaId;
            membership.DatumUplate = uplata.Datum;


            try
            {
                db.Memmberships.Add(membership);

                //smanji dug

                
                var dug = db.Dugovi.Where(p => p.UserID == uplata.UserId && p.YearID == uplata.YearId).FirstOrDefault();
                dug.Amount -= uplata.Amount;

                db.Entry(dug).State = System.Data.Entity.EntityState.Modified;

                return membership;
            }

            catch 
            {
                return null;
            }
        }




        public bool SaveAll()
        {
            return db.SaveChanges() > 0;
        }
    }
}