using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
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

namespace db346
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        ViewModel _vm = new ViewModel();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _vm;
        }

        /// <summary>
        /// 検索を実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickSearch(object sender, RoutedEventArgs e)
        {
            var context = new MyContext();
            var q = from book in context.Book
                    join author in context.Author on book.AuthorId equals author.Id
                    join publisher in context.Publisher on book.PublisherId equals publisher.Id
                    join store in context.Store on book.Id equals store.BookId
                    orderby store.Id
                    select new ResultItem() 
                    {
                        Title = book.Title,
                        AuthorName = author.Name,
                        PublisherName = publisher.Name,
                        Price = book.Price,
                        Stock = store.Stock,
                        UpdatedAt = store.UpdatedAt,
                    };
            // 件数を表示
            _vm.Count = q.Count();
            // 取得したデータを表示
            _vm.Items = q.ToList();
        }
    }

    public class ViewModel : BindableBase
    {
        private int _count = 0;
        public int Count { get => _count; set => SetProperty(ref _count, value, nameof(Count)); } 

        private List<ResultItem> _items = new List<ResultItem>();
        public List<ResultItem> Items { get => _items; set => SetProperty(ref _items, value, nameof(Items)); }
    }
    public class ResultItem
    {
        public string Title { get; set; } = "";
        public string AuthorName { get; set; } = "";
        public string PublisherName { get; set; } = "";
        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime UpdatedAt { get; set; }
    }



    // 「ツール」→「NuGet パッケージマネージャ」から「パッケージマネージャコンソール」を開く
    // Add-Migration Initial
    // Update-Database

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
        public int AuthorId { get; set; }
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
