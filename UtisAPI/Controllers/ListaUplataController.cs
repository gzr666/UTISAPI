using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtisAPI.Models;
using Rotativa;

namespace UtisAPI.Controllers
{
    public class ListaUplataController : Controller
    {

        private UtisDb db = new UtisDb();
        //
        // GET: /ListaUplata/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Uplate(int Id)
        {

            ViewBag.User = db.Users.Find(Id);
            
            var listaUplata = db.Memmberships.Include("User").Include("Year").Include("VrstaUplate").Where(u=>u.UserId==Id).OrderBy(d=>d.DatumUplate).ToList();

            return View(listaUplata);
        
        }
        public ActionResult PrintajUplate(int Id)
        {

            ViewBag.User = db.Users.Find(Id);

            var listaUplata = db.Memmberships.Include("User").Include("Year").Include("VrstaUplate").Where(u => u.UserId == Id).OrderBy(d => d.DatumUplate).ToList();

            return PartialView("Print",listaUplata);

        }

        public ActionResult PrintajPojedinacno(int Id)
        {
            var uplate = db.Memmberships.Include("User").Include("Year").Include("VrstaUplate");
            var uplata = uplate.Where(u => u.ID == Id).FirstOrDefault();
            
            

            return PartialView("Pojedinacni", uplata);
        
        
        }


        public ActionResult PrintUplate(int id)
        {
            return new ActionAsPdf("PrintajUplate", new { Id=id}
                           ) { FileName = "Uplate.pdf" };
        }

        public ActionResult PrintUplate2(int id)
        {
            return new ActionAsPdf("PrintajPojedinacno", new { Id = id }
                           ) { FileName = "Uplate.pdf" };
        }


	}
}