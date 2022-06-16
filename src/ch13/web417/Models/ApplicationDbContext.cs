using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace web417.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base(options) { }
        public DbSet<Book> Book => Set<Book>();
        public DbSet<Author> Author => Set<Author>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
    }
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("書名")]
        [Required(ErrorMessage ="{0}は必須項目です")]
        public string Title { get; set; } = "";
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        [DisplayName("価格")]
        [Range(100,9999, ErrorMessage = "{0}は{1}から{2}までの間で指定してください")]
        public int Price { get; set; }
        // 関連するテーブル
        public Author? Author { get; set; }
        public Publisher? Publisher { get; set; }
    }
    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("著者名")]
        public string Name { get; set; } = "";
    }
    /// <summary>
    /// 出版社クラス
    /// </summary>
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("出版社")]
        public string Name { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
