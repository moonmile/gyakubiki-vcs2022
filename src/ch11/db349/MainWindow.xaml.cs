using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace db349
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 検索を実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickSearchByQuery(object sender, RoutedEventArgs e)
        {
            var context = new MyContext();
            var q = from book in context.Book
                    join author in context.Author on book.AuthorId equals author.Id into temp
                    from authorj in temp.DefaultIfEmpty()
                    join publisher in context.Publisher on book.PublisherId equals publisher.Id into temp2
                    from publisherj in temp2.DefaultIfEmpty()
                    orderby book.Id
                    select new
                    {
                        Title = book.Title,
                        AuthorName = authorj.Name,
                        PublisherName = publisherj.Name,
                        Price = book.Price
                    };
            this.dg.ItemsSource = q.ToList();
        }

        /// <summary>
        /// メソッド呼び出しで実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickSearchByMethod(object sender, RoutedEventArgs e)
        {
            /*
            var context = new MyContext();
            var items = context.Book
                .GroupJoin(context.Author,
                    book => book.AuthorId,
                    author => author.Id,
                    (book, author) => new { book, author = author.FirstOrDefault() })
                .GroupJoin(context.Publisher,
                    t => t.book.PublisherId,
                    publisher => publisher.Id,
                    (t, publisher) => new { t.book, t.author, publisher = publisher.FirstOrDefault() })
                .OrderBy(t => t.book.Id)
                .Select(t => new
                {
                    Title = t.book.Title,
                    AuthorName = t.author != null ? t.author.Name : "なし" ,
                    PublisherName = t.publisher != null ? t.publisher.Name : "なし",
                    Price = t.book.Price
                }).ToList();
            dg.ItemsSource = items;
            */

            // 参考
            // SQL Server の場合、GroupJoin が正しく動かない。
            // メモリ上の List<> だと、同じ GroupJoin を書いても動作する

            var context = new MyContext();
            var books = context.Book.ToList();
            var authors = context.Author.ToList();
            var publishers = context.Publisher.ToList();

            var items = books
                .GroupJoin( authors,
                    book => book.AuthorId,
                    author => author.Id,
                    (book,author) => new { book, author = author.FirstOrDefault() })
                .GroupJoin(publishers,
                    t => t.book.PublisherId,
                    publisher => publisher.Id,
                    (t, publisher) => new { t.book, t.author, publisher = publisher.FirstOrDefault() })
                .OrderBy(t => t.book.Id)
                .Select(t => new
                {
                    Title = t.book.Title,
                    AuthorName = t.author != null ? t.author.Name : "なし",
                    PublisherName = t.publisher != null ? t.publisher.Name : "なし",
                    Price = t.book.Price
                }).ToList();
            dg.ItemsSource = items;
        }
    }

    /// <summary>
    /// 在庫クラス
    /// </summary>
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }     // 扱い始めた日時
        public DateTime UpdatedAt { get; set; }    // 在庫を更新した日時
    }
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }       // 自費出版のときは null
        public int Price { get; set; }
    }
    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
    /// <summary>
    /// 出版社クラス
    /// </summary>
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Address { get; set; } = "";
    }

    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(local)";
            builder.InitialCatalog = "sampledb";
            builder.IntegratedSecurity = true;
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
        public DbSet<Store> Store => Set<Store>();
        public DbSet<Book> Book => Set<Book>();
        public DbSet<Author> Author => Set<Author>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
    }
}
