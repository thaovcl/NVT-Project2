using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenVanThao_2210900125_CNT1_project2.Models;

namespace NguyenVanThao_2210900125_CNT1_project2.Controllers
{
    public class NVT_KHACH_HANGController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        // GET: NVT_KHACH_HANG
        public ActionResult Index()
        {
            var kHACH_HANG = db.KHACH_HANG.Include(k => k.QUAN_TRI);
            return View(kHACH_HANG.ToList());
        }

        // GET: NVT_KHACH_HANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // GET: NVT_KHACH_HANG/Create
        public ActionResult Create()
        {
            ViewBag.Tai_khoan = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau");
            return View();
        }

        // POST: NVT_KHACH_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_KH,Ho_ten,Tai_khoan,Mat_khau,Dia_chi,Dien_thoai,Email,Ngay_tao,Trang_thai")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tai_khoan = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau", kHACH_HANG.Tai_khoan);
            return View(kHACH_HANG);
        }

        // GET: NVT_KHACH_HANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tai_khoan = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau", kHACH_HANG.Tai_khoan);
            return View(kHACH_HANG);
        }

        // POST: NVT_KHACH_HANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_KH,Ho_ten,Tai_khoan,Mat_khau,Dia_chi,Dien_thoai,Email,Ngay_tao,Trang_thai")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tai_khoan = new SelectList(db.QUAN_TRI, "Tai_khoan", "Mat_khau", kHACH_HANG.Tai_khoan);
            return View(kHACH_HANG);
        }

        // GET: NVT_KHACH_HANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: NVT_KHACH_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            db.KHACH_HANG.Remove(kHACH_HANG);
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
