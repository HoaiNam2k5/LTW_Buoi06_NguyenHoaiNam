using System.Web.Mvc;
using BTTL_01.Models;

namespace BTTL_01.Controllers
{
    public class AccountController : Controller
    {
        DuLieu db = new DuLieu();

       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost]
        public ActionResult Login(string sodienthoai, string matkhau)
        {
            var user = db.KiemTraDangNhap(sodienthoai, matkhau);
            if (user != null)
            {
                Session["TaiKhoan"] = user;
                TempData["ThongBao"] = "Xin chào, " + user.TenKH + "!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Số điện thoại hoặc mật khẩu không đúng!";
                return View();
            }
        }

        // Đăng xuất
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Login");
        }
    }
}
