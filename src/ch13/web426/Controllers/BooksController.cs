using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web426.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost("upload")]
        public ActionResult Upload([FromBody]string base64 )
        {
            // BASE64形式でデータを受信する
            var data = System.Convert.FromBase64String(base64);
            // バイナリデータにコンバートする
            string text = BitConverter.ToString(data);
            return Ok(text);
        }
    }
}
