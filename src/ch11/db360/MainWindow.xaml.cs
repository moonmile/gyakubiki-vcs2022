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

namespace db360
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
        private void clickSearch(object sender, RoutedEventArgs e)
        {
            var context = new MyContext();
            var q = context.Store
                .Include("Book")
                .Include("Book.Author")
                .Include("Book.Publisher")
                .OrderByDescending(t => t.Stock)
                .Select(t => t);
            this.dg.ItemsSource = q.ToList();
        }
    }

    /// <summary>
    /// 在庫クラス
    /// </summary>
    public class Store      // クラス名とテーブル名が異なる場合
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }    // 扱い始めた日時
        public DateTime UpdatedAt { get; set; }    // 在庫を更新した日時

        // 関連テーブル
        public Book Book { get; set; }
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
        // 関連テーブル
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
            // ログを出力する
            optionsBuilder.LogTo(action =>
            {
                System.Diagnostics.Debug.WriteLine(action);
            }, Microsoft.Extensions.Logging.LogLevel.Information);
        }
        public DbSet<Store> Store => Set<Store>();
        public DbSet<Book> Book => Set<Book>();
        public DbSet<Author> Author => Set<Author>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
    }
}
