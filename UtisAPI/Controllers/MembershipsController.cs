using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UtisAPI.Models;
using UtisAPI.Repositories;
using UtisAPI.ViewModels;

namespace UtisAPI.Controllers
{
    [RoutePrefix("api/Memberships")]
    public class MembershipsController : ApiController
    {
        private IMembershipRepo repo;
        // private UtisDb db = new UtisDb();

         public MembershipsController(IMembershipRepo repo)
         {
             this.repo = repo;

         }


        // GET api/Memberships
        [Route("")]
        public IQueryable<YearlyMembership> GetMemmberships()
        {
            //return db.Memmberships;
            return null;
        }

        [Route("years")]
        public IHttpActionResult GetYears()
        {

            var years = repo.GetMembershipsYears().ToList();
            return Ok(years);
            
        
        }
        [Route("vrsteuplate")]
        public IHttpActionResult GetVrste()
        {

            return Ok(repo.GetMembershipTypes().ToList());


        }



        [Route("{UserID:int}/{YearID:int}")] 
        public IHttpActionResult GetTotal(int UserID, int YearID)
        {

            return Ok(repo.GetTotal(UserID, YearID));


           
        
        }

        // GET api/Memberships/5
        //[ResponseType(typeof(YearlyMembership))]
        //public IHttpActionResult GetYearlyMembership(int id)
        //{
        //    YearlyMembership yearlymembership = db.Memmberships.Find(id);
        //    if (yearlymembership == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(yearlymembership);
        //}

        // PUT api/Memberships/5
        //public IHttpActionResult PutYearlyMembership(int id, YearlyMembership yearlymembership)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != yearlymembership.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(yearlymembership).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!YearlyMembershipExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST api/Memberships
        //[ResponseType(typeof(YearlyMembership))]

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostYearlyMembership(Uplata uplata)
        {

            uplata.Datum = DateTime.Now;

            if (uplata.YearId < 1)
            {
                ModelState.AddModelError("Year ID", "must be larger then 0");

            }

            if (!ModelState.IsValid)
            {
                 ModelState.AddModelError("Errors", "Pleasse try fix errors");


                 return BadRequest(ModelState);
            }

            var membership = repo.InsertMembership(uplata);

            if (membership != null && repo.SaveAll())
            {
                return Ok(membership);
            }
            else
            {
                return InternalServerError();
            }
        }

        //// DELETE api/Memberships/5
        //[ResponseType(typeof(YearlyMembership))]
        //public IHttpActionResult DeleteYearlyMembership(int id)
        //{
        //    YearlyMembership yearlymembership = db.Memmberships.Find(id);
        //    if (yearlymembership == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Memmberships.Remove(yearlymembership);
        //    db.SaveChanges();

        //    return Ok(yearlymembership);
        //}

        

        private bool YearlyMembershipExists(int id)
        {
            //return db.Memmberships.Count(e => e.ID == id) > 0;
            return true;
        }
    }
    }

