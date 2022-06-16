using Microsoft.AspNetCore.Mvc;
using web407.Models;

namespace web406.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            /// 空モデルをビューに渡す
            return View(new Person());
        }
        [HttpPost]
        public IActionResult Post( Person person )
        {
            ViewBag.ErrorMessage = "";
            if ( string.IsNullOrEmpty( person.Name ) ||
                 string.IsNullOrEmpty( person.Telephone ) )
            {
                ViewBag.ErrorMessage = "名前と電話番号の両方を入力してください";
                return View("Index", person);
            }
            else
            {
                // 結果のページを表示
                return View("Result", person);
            }
        }
    }
}
