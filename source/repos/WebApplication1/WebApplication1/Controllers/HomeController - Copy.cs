using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        return RedirectToAction();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult University()
    {
        ViewBag.Message = "ViewBag: Messsage from university function in controller";
        return View();
    }

    
    public IActionResult Course()
    {
        return View();
    }

    public IActionResult Cookie1() {

        if (!HttpContext.Request.Cookies.ContainsKey("Test"))
        {

            CookieOptions co = new CookieOptions();
            co.Expires = DateTime.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Test", DateTime.Now.ToString(),co);
            ViewBag.Text = "First Cookie";
            return View();
        }
        else
        {
            DateTime dt = DateTime.Parse(HttpContext.Request.Cookies["Test"]);
            ViewBag.Text = dt.ToString();
            return View();
        }
    }


}
