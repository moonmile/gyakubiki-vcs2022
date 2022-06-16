using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web425.Models;

namespace web425.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            /// JOIN を利用する
            var items = await _context.Book
                .Include("Author")
                .Include("Publisher")
                .OrderBy(t => t.Id)
                .ToListAsync();
            return items;
        }

        /// <summary>
        /// IDを指定して取得する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Book
                .Include("Author")
                .Include("Publisher")
                .FirstOrDefaultAsync(t => t.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        /// <summary>
        /// 既存の書籍を更新する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        /// <summary>
        /// 書籍IDを指定して、書名と価格のみ更新する
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("update/{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, BookUpdate bookupdate)
        {
            if (id != bookupdate.Id)
            {
                return BadRequest();
            }
            var book = _context.Book.Find(bookupdate.Id);
            if ( book == null )
            {
                return NotFound();
            }
           
            book.Title = bookupdate.Title;
            book.Price = bookupdate.Price;
            await _context.SaveChangesAsync();


            var item = await _context.Book
                .Include("Author")
                .Include("Publisher")
                .FirstOrDefaultAsync(t => t.Id == id);
            if ( item == null )
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// 新しい書籍を追加する
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }


        /// <summary>
        /// 指定IDの画像を返す
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Books/5
        [HttpGet("image/{id}")]
        public ActionResult GetImage(int id)
        {
            // 本来は、指定IDで検索する
            var data = System.IO.File.ReadAllBytes("Data\\gyakubiki.jpg");
            return this.File(data, "image/jpeg");

            // 相対パスを使うことも可能
            // return this.File("~/Data/gyakubiki.jpg", "image/jpeg");
        }
    }

    /// <summary>
    /// 書籍の変更クラス
    /// </summary>
    public class BookUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Price { get; set; }
    }

}
