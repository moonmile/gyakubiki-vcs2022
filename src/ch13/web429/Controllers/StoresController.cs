using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web429.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace web429.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private ApplicationDbContext _context;

        public StoresController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("{id}")]
        public IActionResult Get( int? id )
        {
            if ( id == null )
            {
                return NotFound();
            }
            var store = _context.Store.FirstOrDefault(m => m.Id == id);
            if ( store == null )
            {
                return NotFound();
            }
            return Ok(store);
        }
        [HttpPost("{id}")]
        public IActionResult Edit( int id, [FromBody]Store store)
        {
            if ( id != store.Id )
            {
                return NotFound();
            }
            // 更新日時をチェックする
            var item = _context.Store.FirstOrDefault(m => m.Id == id);
            if (item == null )
            {
                return NotFound();
            }
            if (item.UpdatedAt != store.UpdatedAt )
            {
                // 更新日時が異なる場合
                return BadRequest();
            }
            item.UpdatedAt = DateTime.Now;
            item.Stock = store.Stock;
            _context.Store.Update(item);
            _context.SaveChanges();
            return Ok();
        }
    }

}
