using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web395.Models;

namespace web395.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 新しいモデルクラスを使う
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        var model = new SampleModel()
        {
            Name = "マスダトモアキ",
            Address = "東京都板橋区",
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
