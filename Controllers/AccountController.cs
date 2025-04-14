using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View(); // Trả về trang Đăng nhập
    }

    public IActionResult Register()
    {
        return View(); // Trả về trang Đăng ký
    }
}
