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

        /// �����l�����Ă���
        this.books = new List<Book>();
        books.Add(new Book
        {
            Id = 1,
            AuthorId = 1,
            PublisherId = 1,
            Title = "�t������SC#2022",
            Price = 1000
        });
        books.Add(new Book
        {
            Id = 2,
            AuthorId = 1,
            PublisherId = 1,
            Title = "�t������SC#2022",
            Price = 1000
        });
        books.Add(new Book
        {
            Id = 3,
            AuthorId = 1,
            PublisherId = 2,
            Title = ".NET5�v���O���~���O����",
            Price = 1000
        });
        authors = new List<Author>();
        authors.Add(new Author { Id = 1, Name = "���c�q��" });
        authors.Add(new Author { Id = 2, Name = "�g���E�f�}���R" });
        authors.Add(new Author { Id = 3, Name = "G.M.���C���o�[�O" });
        authors.Add(new Author { Id = 4, Name = "�E���x���g�E�G�[�R" });
        publishers = new List<Publisher>();
        publishers.Add(new Publisher { Id = 1, Name = "�G�a�V�X�e��", Telephone = "03-XXXX-XXXX" });
        publishers.Add(new Publisher { Id = 2, Name = "���oBP", Telephone = "03-XXXX-XXXX" });

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

        /// ���Җ����w�肳�ꂽ�ꍇ
        if ( item.AuthorName != "" )
        {
            var author = authors.FirstOrDefault(t => t.Name == item.AuthorName);
            if ( author != null )
            {
                items = books.Where(t => t.AuthorId == author.Id).ToList();
            }
        }
        /// �o�ŎЖ����w�肳�ꂽ�ꍇ
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
/// ���ЃN���X
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
/// ���҃N���X
/// </summary>
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// �o�ŎЃN���X
/// </summary>
public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Address { get; set; } = "";
}
