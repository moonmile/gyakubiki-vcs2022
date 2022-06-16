using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web399.Models;

namespace web399.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // 初回のみセッション情報に保存する
        if (this.HttpContext.Session.GetString("ACCESS-DATE") == null )
        {
            DateTime dt = DateTime.Now;
            this.HttpContext.Session.SetString("ACCESS-DATE", dt.ToString());
            ViewData["DATE"] = dt;
        }
        else
        {
            var dt = DateTime.Parse(this.HttpContext.Session.GetString("ACCESS-DATE")!);
            ViewData["DATE"] = dt;
        }
        return View();
    }

    public IActionResult Privacy()
    {
        // ここでセッション情報を取得する
        var dt = DateTime.Parse(this.HttpContext.Session.GetString("ACCESS-DATE")!);
        ViewData["DATE"] = dt; 
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
