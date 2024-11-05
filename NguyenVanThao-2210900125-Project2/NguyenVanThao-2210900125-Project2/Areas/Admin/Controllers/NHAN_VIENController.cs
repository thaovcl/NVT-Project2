using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenVanThao_2210900125_Project2.Models;
using NguyenVanThao_2210900125_Project2.App_Start;

namespace NguyenVanThao_2210900125_Project2.Areas.Admin.Controllers
{
    public class NHAN_VIENController : Controller
    {
        // GET: Admin/NHAN_VIEN/DanhSach
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult DanhSach()
        {
            using (var dbContext = new NguyenVanThao_K22CNT1_Project2Entities1())
            {
                var nhanViens = dbContext.NHAN_VIEN.ToList();
                return View(nhanViens);
            }
        }

        // GET: Admin/NHAN_VIEN/Create
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NHAN_VIEN/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Create(NHAN_VIEN nhanVien)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new NguyenVanThao_K22CNT1_Project2Entities1())
                {
                    dbContext.NHAN_VIEN.Add(nhanVien);
                    dbContext.SaveChanges();
                    return RedirectToAction("DanhSach");
                }
            }
            return View(nhanVien);
        }

        // GET: Admin/NHAN_VIEN/Edit/{id}
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Edit(int id)
        {
            using (var dbContext = new NguyenVanThao_K22CNT1_Project2Entities1())
            {
                var nhanVien = dbContext.NHAN_VIEN.Find(id);
                if (nhanVien == null)
                {
                    return HttpNotFound();
                }
                return View(nhanVien);
            }
        }

        // POST: Admin/NHAN_VIEN/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Edit(NHAN_VIEN nhanVien)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new NguyenVanThao_K22CNT1_Project2Entities1())
                {
                    dbContext.Entry(nhanVien).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return RedirectToAction("DanhSach");
                }
            }
            return View(nhanVien);
        }

        // GET: Admin/NHAN_VIEN/Delete/{id}
        public ActionResult Delete(int? id)
        {
            NguyenVanThao_K22CNT1_Project2Entities1 db = new NguyenVanThao_K22CNT1_Project2Entities1();
            var updateModel = db.NHAN_VIEN.Find(id);
            db.NHAN_VIEN.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("DanhSach");
        }
    }
}
