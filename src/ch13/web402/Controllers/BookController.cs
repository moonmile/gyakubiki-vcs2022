using Microsoft.AspNetCore.Mvc;
using web402.Models;

namespace web401.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
