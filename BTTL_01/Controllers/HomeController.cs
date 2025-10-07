using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTTL_01.Models;
using BTTL_01.ViewModels;

namespace BTTL_01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HienThiSanPham()
        {
            DuLieu db = new DuLieu();
            List<SanPham> ds = db.dsSanPham;
            return View(ds);
        }
        public PartialViewResult MenuSanPham()
        {
            DuLieu db = new DuLieu();
            var dsLoai = db.GetLoaiSP();
            return PartialView("_MenuSanPham", dsLoai);
        }
        public ActionResult SanPhamTheoLoai(string maloai)
        {
            var duLieu = new DuLieu();


            var dsSanPham = duLieu.GetSanPhamByLoai(maloai);

      
            var loai = duLieu.GetLoaiSP().FirstOrDefault(l => l.MaLoai == maloai);

          
            var dsLoai = duLieu.GetLoaiSP();

            var vm = new SanPhamTheoLoaiViewModel
            {
                MaLoai = maloai,
                TenLoai = loai?.TenLoai ?? "Không xác định",
                DanhSachSanPham = dsSanPham,
                DanhSachLoai = dsLoai
            };

            return View(vm);
        }



        public ActionResult ChiTietSanPham(string masp)
        {
            var duLieu = new DuLieu();

            if (string.IsNullOrEmpty(masp))
                return RedirectToAction("Index");

         
            var sp = duLieu.dsSanPham.FirstOrDefault(s => s.MaSP == masp);

            if (sp == null)
                return HttpNotFound();  

            return View(sp);
        }

    }

}