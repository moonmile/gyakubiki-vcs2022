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


namespace db339
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
        /// テストデータを作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickInitialize(object sender, RoutedEventArgs e)
        {
            var context = new MyContext();
            context.Initialize();
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
                    orderby book.Id
                    select new { 
                        Id = book.Id, 
                        Title = book.Title,
                        AuthorName = author.Name,
                        PublisherName = publisher.Name,
                        Price = book.Price 
                    };
            this.dg.ItemsSource = q.ToList();
        }
    }



    // 「ツール」→「NuGet パッケージマネージャ」から「パッケージマネージャコンソール」を開く
    // Add-Migration Initial
    // Update-Database

    /// <summary>
    /// 在庫クラス
    /// </summary>
    public class Store {
        [Key]
        public int Id {  get; set; }
        public int BookId {  get; set; }
        public int Stock {  get; set; }
        public DateTime CreatedAt { get; set; }     // 扱い始めた日時
        public DateTime UpdatedAt {  get; set; }    // 在庫を更新した日時
    }
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book {
        [Key]
        public int Id {  get; set; }
        public string Title { get; set; } = "";
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }       // 自費出版のときは null
        public int Price { get; set; } 
    }
    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; } = "";
    }
    /// <summary>
    /// 出版社クラス
    /// </summary>
    public class Publisher {
        [Key]
        public int Id {  get; set; }
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

        /// <summary>
        /// データベースに初期値を入れる
        /// </summary>
        public void Initialize()
        {
            // 既存のデータを削除する
            this.Database.ExecuteSqlRaw("delete from Publisher");
            this.Database.ExecuteSqlRaw("delete from Author");
            this.Database.ExecuteSqlRaw("delete from Book");
            this.Database.ExecuteSqlRaw("delete from Store");

            this.Publisher.Add(new Publisher { Name = "秀和システム", Telephone = "03-6264-XXXX", Address = "東京都江東区" });
            this.Publisher.Add(new Publisher { Name = "日経BP", Telephone = "", Address = "東京都港区" });
            this.Publisher.Add(new Publisher { Name = "技術評論社", Telephone = "03-3513-XXXX", Address = "東京都新宿区" });
            this.Publisher.Add(new Publisher { Name = "共立出版", Telephone = "03-3947-XXXX", Address = "東京都文京区" });
            this.Publisher.Add(new Publisher { Name = "オーム社", Telephone = "03-3233-XXXX", Address = "東京都千代田区" });
            this.Publisher.Add(new Publisher { Name = "ピアソン・エデュケーション", Telephone = "03-3233-XXXX", Address = "東京都千代田区" });

            this.Author.Add(new Author { Name = "増田智明" });
            this.Author.Add(new Author { Name = "トム・デマルコ" });
            this.Author.Add(new Author { Name = "G.M.ワインバーグ" });
            this.Author.Add(new Author { Name = "ウンベルト・エーコ" });
            this.Author.Add(new Author { Name = "野中郁次郎" });
            this.Author.Add(new Author { Name = "ケント・ベック" });

            this.SaveChanges();

            this.Book.Add(new Book
            {
                Title = "逆引き大全C#2022版",
                AuthorId = Author.First(t => t.Name == "増田智明").Id,
                PublisherId = Publisher.First(t => t.Name == "秀和システム").Id,
                Price = 2000,
            });
            this.Book.Add(new Book
            {
                Title = "逆引き大VB#2022版(仮)",
                AuthorId = Author.First(t => t.Name == "増田智明").Id ,
                PublisherId = Publisher.First(t => t.Name == "秀和システム").Id,
                Price = 2000,
            });
            this.Book.Add(new Book
            {
                Title = ".NET5プログラミング入門",
                AuthorId = Author.First(t => t.Name == "増田智明").Id,
                PublisherId = Publisher.First(t => t.Name == "日経BP").Id,
                Price = 2000,
            });
            this.Book.Add(new Book
            {
                Title = "ピープルウェア",
                AuthorId = Author.First(t => t.Name == "トム・デマルコ").Id,
                PublisherId = Publisher.First(t => t.Name == "日経BP").Id,
                Price = 2000,
            });
            this.Book.Add(new Book
            {
                Title = "コンサルタントの道具箱",
                AuthorId = Author.First(t => t.Name == "G.M.ワインバーグ").Id,
                PublisherId = Publisher.First(t => t.Name == "日経BP").Id,
                Price = 2000,
            });
            this.Book.Add(new Book
            {
                Title = "テスト駆動開発入門",
                AuthorId = Author.First(t => t.Name == "ケント・ベック").Id,
                PublisherId = Publisher.First(t => t.Name == "ピアソン・エデュケーション").Id,
                Price = 2000,
            });
            this.SaveChanges();

            this.Store.Add(new Store { BookId = Book.First(t => t.Title == "逆引き大全C#2022版").Id, Stock = 100, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            this.Store.Add(new Store { BookId = Book.First(t => t.Title == "逆引き大VB#2022版(仮)").Id, Stock = 0, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            this.Store.Add(new Store { BookId = Book.First(t => t.Title == ".NET5プログラミング入門").Id, Stock = 50, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            this.Store.Add(new Store { BookId = Book.First(t => t.Title == "ピープルウェア").Id, Stock = 200, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            this.Store.Add(new Store { BookId = Book.First(t => t.Title == "コンサルタントの道具箱").Id, Stock = 200, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            this.Store.Add(new Store { BookId = Book.First(t => t.Title == "テスト駆動開発入門").Id, Stock = 0, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            this.SaveChanges();

        }
    }
}
