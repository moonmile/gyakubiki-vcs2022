using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization ;
using System.Xml.Serialization;

namespace netserver.Controllers;

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
            Title = ".NET6プログラミング入門",
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

    [HttpPost]
    public void Post()
    {

    }
    [HttpGet("{id}")]
    public Book? Get(int id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            return null;
        }
        else
        {
            book.Author = authors.FirstOrDefault(x => x.Id == book.AuthorId);
            book.Publisher = publishers.FirstOrDefault(x => x.Id == book.PublisherId);
            /*
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(book, options);
            return json;
            */
            return book;
        }
    }


    /// <summary>
    /// XML形式で返す
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/xml")]
    public string GetXml(int id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            return "{}";
        }
        else
        {
            book.Author = authors.FirstOrDefault(x => x.Id == book.AuthorId);
            book.Publisher = publishers.FirstOrDefault(x => x.Id == book.PublisherId);
            var serializer = new XmlSerializer(typeof(Book));
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, book);
                return sw.ToString();
            }
        }
    }

    [HttpPost("search")]
    public List<Book> Search([FromForm] string title)
    {
        var items = books.Where(x => x.Title.Contains(title)).ToList();
        foreach (var it in items)
        {
            it.Author = authors.FirstOrDefault(x => x.Id == it.AuthorId);
            it.Publisher = publishers.FirstOrDefault(x => x.Id == it.PublisherId);
        }
        return books;
    }

    [HttpPost("searchJson")]
    public List<Book> SearchJson([FromBody] SearchItem item)
    {
        if (item == null)
        {
            return new List<Book>();
        }

        var items = new List<Book>();

        /// 著者名が指定された場合
        if (item.AuthorName != "")
        {
            var author = authors.FirstOrDefault(t => t.Name == item.AuthorName);
            if (author != null)
            {
                items = books.Where(t => t.AuthorId == author.Id).ToList();
            }
        }
        /// 出版社名が指定された場合
        else if (item.PublisherName != "")
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


    [HttpPost("searchApiKey")]
    public List<Book> SearchApiKey([FromBody] SearchItem item)
    {
        if (item == null)
        {
            return new List<Book>();
        }

        var items = new List<Book>();

        /// 著者名が指定された場合
        if (item.AuthorName != "")
        {
            var author = authors.FirstOrDefault(t => t.Name == item.AuthorName);
            if (author != null)
            {
                items = books.Where(t => t.AuthorId == author.Id).ToList();
            }
        }
        /// 出版社名が指定された場合
        else if (item.PublisherName != "")
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


    [HttpGet("checkUserAgent")]
    public string CheckUserAgent()
    {
        // ヘッダ部の User-Agent をそのまま返す
        string userAgent = this.HttpContext.Request.Headers["User-Agent"].ToString();
        return userAgent;
    }

    [HttpGet("checkCookie")]
    public string checkCookie()
    {
        // Cookie に User-Key を入れる
        if (this.HttpContext.Request.Cookies.ContainsKey("User-Key") == false)
        {
            this.HttpContext.Response.Cookies.Append("User-Key", "XXXX-XXXX");
        }
        return "ユーザーキー設定";
    }

    /// <summary>
    /// Tips380 Webサーバーからファイルをダウンロードする
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("donwload/{id}")]
    public IActionResult FileDownload(int id = 0)
    {
        // 実際はidにより、ダウンロードするファイルを切り替える
        string path = "sample.zip";
        var content = System.IO.File.OpenRead(path);
        var contentType = "APPLICATION/octet-stream";
        var fileName = "sample.zip";
        return File(content, contentType, fileName);
    }

    /// <summary>
    /// Tips381 Webサーバーへファイルをアップロードする
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    [HttpPost("upload")]
    public async Task<IActionResult> FileUpload(IFormFile zipfile)
    {
        string path = "sample.zip";
        using (var stream = System.IO.File.Create(path))
        {
            await zipfile.CopyToAsync(stream);
        }
        return Ok();
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
