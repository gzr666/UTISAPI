using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtisAPI.Models;
using UtisAPI.ViewModels;
using System.Net;
using System.Data;
using System.Data.Entity;

namespace UtisAPI.Controllers
{
    public class ClanarineController : Controller
    {
        private UtisDb db = new UtisDb();

        // GET: /Clanarine/
        public ActionResult Index()
        {
            var memmberships = db.Memmberships.Include(y => y.User).Include(y => y.Year);
            return View(memmberships.ToList());
        }

        // GET: /Clanarine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearlyMembership yearlymembership = db.Memmberships.Find(id);
            if (yearlymembership == null)
            {
                return HttpNotFound();
            }
            return View(yearlymembership);
        }

        // GET: /Clanarine/Create
        public ActionResult Create()
        {

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

            ViewBag.UserId = new SelectList(db.Users, "ID", "Name");
            ViewBag.YearId = new SelectList(listagodina, "ID", "Name");
            return View();
        }

        // POST: /Clanarine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(YearlyMembership yearlymembership)
        {


            if (ModelState.IsValid)
            {
                db.Memmberships.Add(yearlymembership);
                db.SaveChanges();
                return RedirectToAction("Index");
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

            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", yearlymembership.UserId);
            ViewBag.YearId = new SelectList(listagodina, "ID", "Name", yearlymembership.YearId);
            return View(yearlymembership);
        }

        // GET: /Clanarine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearlyMembership yearlymembership = db.Memmberships.Find(id);
            if (yearlymembership == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", yearlymembership.UserId);
            ViewBag.YearId = new SelectList(db.Years, "ID", "ID", yearlymembership.YearId);
            return View(yearlymembership);
        }

        // POST: /Clanarine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Amount,UserId,YearId")] YearlyMembership yearlymembership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearlymembership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", yearlymembership.UserId);
            ViewBag.YearId = new SelectList(db.Years, "ID", "ID", yearlymembership.YearId);
            return View(yearlymembership);
        }

        // GET: /Clanarine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearlyMembership yearlymembership = db.Memmberships.Find(id);
            if (yearlymembership == null)
            {
                return HttpNotFound();
            }
            return View(yearlymembership);
        }

        // POST: /Clanarine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearlyMembership yearlymembership = db.Memmberships.Find(id);
            db.Memmberships.Remove(yearlymembership);
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