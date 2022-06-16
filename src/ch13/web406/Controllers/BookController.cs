using Microsoft.AspNetCore.Mvc;
using web406.Models;

namespace web406.Controllers
{
    public class BookController : Controller
    {
        /// <summary>
        /// テスト用の初期データ
        /// </summary>
        List<Book> books = new List<Book>();
        List<Author> authors = new List<Author>();
        List<Publisher> publishers = new List<Publisher>();

        public BookController()
        {
            /// 初期値を入れておく
            this.books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                AuthorId = 1,
                PublisherId = 1,
                Title = "逆引き大全C#2022",
                Price = 1000
            });
            books.Add(new Book
            {
                Id = 2,
                AuthorId = 1,
                PublisherId = 1,
                Title = "逆引き大全C#2022",
                Price = 1000
            });
            books.Add(new Book
            {
                Id = 3,
                AuthorId = 1,
                PublisherId = 2,
                Title = ".NET5プログラミング入門",
                Price = 1000
            });
            authors = new List<Author>();
            authors.Add(new Author { Id = 1, Name = "増田智明" });
            authors.Add(new Author { Id = 2, Name = "トム・デマルコ" });
            authors.Add(new Author { Id = 3, Name = "G.M.ワインバーグ" });
            authors.Add(new Author { Id = 4, Name = "ウンベルト・エーコ" });
            publishers = new List<Publisher>();
            publishers.Add(new Publisher { Id = 1, Name = "秀和システム", Telephone = "03-XXXX-XXXX" });
            publishers.Add(new Publisher { Id = 2, Name = "日経BP", Telephone = "03-XXXX-XXXX" });
        }
        public IActionResult Index( int id = 0 )
        {
            /// 空モデルをビューに渡す
            return View(new Book());
        }

        public IActionResult Post( Book book )
        {
            // 入力結果のページを表示
            return View("Result", book);
        }
    }
}
