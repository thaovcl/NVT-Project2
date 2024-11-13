using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT1_NguyenVanThao_2210900125.Models;

namespace K22CNT1_NguyenVanThao_2210900125.Controllers
{
    public class NVT_TOURsController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        // GET: NVT_TOURs
        public ActionResult Index()
        {
            var tOURs = db.TOURs.Include(t => t.LOAI_TOUR);
            return View(tOURs.ToList());
        }

        // GET: NVT_TOURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
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
