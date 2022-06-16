using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web428.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("hello")]
        public HelloResult hello()
        {
            var apikey = this.Request.Headers["X-API-KEY"];
            if (apikey.FirstOrDefault() != "TEST-SERVER")
            {
                return new HelloResult
                {
                    ErrorMesssage = "apikey error."
                };
            } else {
                return new HelloResult
                {
                    Id = 1,
                    Name = "masuda",
                    ErrorMesssage = ""
                };
            }
        }
    }

    public class HelloResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string ErrorMesssage { get; set; } = "";
    }
}
