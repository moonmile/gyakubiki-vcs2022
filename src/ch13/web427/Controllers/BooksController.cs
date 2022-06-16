using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web427.Controllers
{
    /// <summary>
    /// ルーティングを変更する
    /// </summary>
    [Route("Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Hello という文字列を返す
        /// </summary>
        /// <returns></returns>
        [HttpGet("hello")]
        public ActionResult hello()
        {
            return Ok("hello");
        }
        /// <summary>
        /// 2つの数字を加算する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [HttpGet("add/{x}/{y}")] 
        public ActionResult add( int x, int y )
        {
            return Ok(x+y);
        }
    }
}
