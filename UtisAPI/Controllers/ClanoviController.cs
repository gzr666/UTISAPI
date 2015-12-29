using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtisAPI.Models;
using UtisAPI.ViewModels;
using System.Net;
using System.Data.Entity;
using PagedList;
using Rotativa;



namespace UtisAPI.Controllers
{
    public class ClanoviController : Controller
    {
        private UtisDb db = new UtisDb();

        // GET: /Clanovi/
        public ActionResult Index(int? id)
        {


            /*Pagination*/
            //var users = db.Users.ToList();

            //var pageNumber = id ?? 1;
            //var pagedUsers = users.OrderBy(user=>user.Surname).ToPagedList(pageNumber, 4);
            //ViewBag.years = db.Years.ToList();
            //return View(pagedUsers);
            @ViewBag.appName = "homeIndex";
            return View();
        }

        // GET: /Clanovi/Details/5
        public ActionResult Details(int? id)
        {
          //  int godisnjaClanarina = 300;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            List<object> listagodina = new List<object>();
            foreach (var p in db.Years)
            {
                listagodina.Add(
                    new
                    {
                        Id = p.ID,
                        Name = p.BeginDate.Year
                    }

                    );

            }
            List<object> vrsteUplate = new List<object>();
            foreach (var vrsta in db.VrsteUplata)
            {
                vrsteUplate.Add(

                        new { 
                            
                            Id=vrsta.ID,
                        Name=vrsta.Name
                        
                        }

                    );
            
            }

            ViewBag.YearId = new SelectList(listagodina, "ID", "Name");
            ViewBag.VrstaId = new SelectList(vrsteUplate, "Id", "Name");


            return View(user);
        }

        // GET: /Clanovi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clanovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,DateJoined")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                int mjesecnaClanarina = 300/12;
                 Dug dug = new Dug();
                var years = db.Years;

                foreach(var year in years)
                {
                    if (user.DateJoined.Year > year.BeginDate.Year)
                    {
                        dug.Amount = 0;
                        dug.UserID = user.ID;
                        dug.YearID = year.ID;
                        dug.user = user;
                        dug.year = year;
                        db.Dugovi.Add(dug);
                        db.SaveChanges();
                    }
                    else
                    {

                        if (user.DateJoined.Year == year.BeginDate.Year)
                        {
                            dug.Amount = (12 - user.DateJoined.Month) * mjesecnaClanarina;
                            dug.UserID = user.ID;
                            dug.YearID = year.ID;
                            dug.user = user;
                            dug.year = year;
                            db.Dugovi.Add(dug);
                            db.SaveChanges();
                        }
                        else
                        {
                            dug.Amount = 300;
                            dug.UserID = user.ID;
                            dug.YearID = year.ID;
                            dug.user = user;
                            dug.year = year;
                            db.Dugovi.Add(dug);
                            db.SaveChanges();

                        }

                    }
                
                }
                db.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /Clanovi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Clanovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,DateJoined")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /Clanovi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Clanovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



	}
}