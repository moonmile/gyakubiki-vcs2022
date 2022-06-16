using Microsoft.AspNetCore.Mvc;

namespace web394.Controllers
{
    /// <summary>
    /// 追加したコントローラー
    /// </summary>
    public class Home2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
