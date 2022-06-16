using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization ;
using System.Xml.Serialization;

namespace netserverauth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GyakubikiController : ControllerBase
{
    private readonly ILogger<GyakubikiController> _logger;

    List<Book> books = new List<Book>();
    List<Author> authors = new List<Author>();
    List<Publisher> publishers = new List<Publisher>();


    public GyakubikiController(ILogger<GyakubikiController> logger)
    {
        _logger = logger;

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


    [HttpPost("searchAuth")]
    [Authorize]
    public List<Book> searchAuth([FromBody] SearchItem item)
    {
        if ( item == null )
        {
            return new List<Book>();
        }

        var items = new List<Book>();

        /// 著者名が指定された場合
        if ( item.AuthorName != "" )
        {
            var author = authors.FirstOrDefault(t => t.Name == item.AuthorName);
            if ( author != null )
            {
                items = books.Where(t => t.AuthorId == author.Id).ToList();
            }
        }
        /// 出版社名が指定された場合
        else if ( item.PublisherName != "" )
        {
            var publisher = publishers.FirstOrDefault(t => t.Name == item.PublisherName);
            if (publisher != null)
            {
                items = books.Where(t => t.PublisherId == publisher.Id).ToList();
            }
        }
        foreach (var it in items)
        {
            it.Author = authors.FirstOrDefault(x => x.Id == it.AuthorId);
            it.Publisher = publishers.FirstOrDefault(x => x.Id == it.PublisherId);
        }
        return items;
    }

    public class SearchItem
    {
        public string AuthorName { get; set; } = "";
        public string PublisherName { get; set; } = "";
    }
}

/// <summary>
/// 書籍クラス
/// </summary>
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }      
    public int Price { get; set; }

    public Author? Author { get; set; }
    public Publisher? Publisher { get; set; }
}
/// <summary>
/// 著者クラス
/// </summary>
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// 出版社クラス
/// </summary>
public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Address { get; set; } = "";
}
