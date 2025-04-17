using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quan_Ly_TTDT.Models;
namespace Quan_Ly_TTDT.Controllers;
public class ReviewController : Controller
{
    public IActionResult Index()
    {
        // Điều hướng đến Views/Course/Index.cshtml
        return View();
    }
}
