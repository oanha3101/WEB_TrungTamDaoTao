using Microsoft.AspNetCore.Mvc;
using Quan_Ly_TTDT.Data; // namespace chứa DbContext của bạn
using Quan_Ly_TTDT.Models; // namespace chứa model User
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Quan_Ly_TTDT.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị form đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string TenTaiKhoan, string MatKhau)
        {
            var user = _context.Users
                                .FirstOrDefault(u => u.TenTaiKhoan == TenTaiKhoan && u.MatKhau == MatKhau);

            if (user != null)
            {
                // Lưu session
                HttpContext.Session.SetString("Username", user.TenTaiKhoan); // Sử dụng TenTaiKhoan làm Username hiển thị
                HttpContext.Session.SetString("Role", user.Role);

                if (user.Role == "Admin")
                    return RedirectToAction("Dashboard", "Admin");
                else
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Sai tên tài khoản hoặc mật khẩu!";
            return View();
        }


        // Hiển thị form đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        public IActionResult Register(User newUser)
        {
            var exists = _context.Users.Any(u => u.TenTaiKhoan == newUser.TenTaiKhoan); // Kiểm tra theo Ten
            if (exists)
            {
                ViewBag.Message = "Tên đã tồn tại.";
                return View();
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();
            ViewBag.Message = "Đăng ký thành công! Bạn có thể đăng nhập.";
            return RedirectToAction("Login");
        }

        // Đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}