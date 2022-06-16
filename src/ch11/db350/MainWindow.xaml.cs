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

namespace db350
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
        /// 結果クラスを利用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickUseClass(object sender, RoutedEventArgs e)
        {
            var context = new MyContext();
            var q = from book in context.Book
                    join author in context.Author on book.AuthorId equals author.Id 
                    join publisher in context.Publisher on book.PublisherId equals publisher.Id 
                    orderby book.Id
                    select new ReusltItem
                    {
                        Id = book.Id,
                        Title = book.Title,
                        AuthorName = author.Name,
                        PublisherName = publisher.Name,
                        Price = book.Price
                    };
            this.dg.ItemsSource = q.ToList();
            // MVVM でデータバインドを使うときは、
            // ViewModel に型指定をするために結果クラスが必須になる
        }

        /// <summary>
        /// 匿名型を利用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickUseAnonymous(object sender, RoutedEventArgs e)
        {
            var context = new MyContext();
            var q = from book in context.Book
                    join author in context.Author on book.AuthorId equals author.Id
                    join publisher in context.Publisher on book.PublisherId equals publisher.Id
                    orderby book.Id
                    select new 
                    {
                        Id = book.Id,
                        Title = book.Title,
                        AuthorName = author.Name,
                        PublisherName = publisher.Name,
                        Price = book.Price
                    };
            this.dg.ItemsSource = q.ToList();
        }


        /// <summary>
        /// 検索結果を受け取るクラス
        /// </summary>
        public class ReusltItem
        {
            public int Id { get; set; }
            public string Title { get; set; } = "";
            public string AuthorName { get; set; } = "";
            public string PublisherName { get; set; } = "";
            public int Price {  get; set; }
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
