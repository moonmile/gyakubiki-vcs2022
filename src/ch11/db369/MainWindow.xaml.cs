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

namespace db369
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
            search();
        }
        private void search()
        {
            var context = new MyContext();
            var q = from book in context.Book.Include("Author").Include("Publisher")
                    orderby book.Id
                    select new BookItem
                    {
                        Id = book.Id,
                        Title = book.Title,
                        AuthorName = book.Author == null ? "" : book.Author.Name,
                        PublisherName = book.Publisher == null ? "" : book.Publisher.Name,
                        Price = book.Price
                    };
            _vm.Item = null;
            _vm.Items = q.ToList();
        }

        /// <summary>
        /// 新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickNewItem(object sender, RoutedEventArgs e)
        {
            // 項目を空欄にする
            _vm.Item = new BookItem();

        }
        /// <summary>
        /// 項目を追加あるいは更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickUpdate(object sender, RoutedEventArgs e)
        {
            if (_vm.Item == null) { return; }

            var context = new MyContext();
            Author? author = null;
            Publisher? publisher = null;
            // トランザクションを開始

            var tr = context.Database.BeginTransaction();

            // 著者名を調べてなければ追加する
            if (_vm.Item.AuthorName != "")
            {
                author = context.Author.FirstOrDefault(t => t.Name == _vm.Item.AuthorName);
                if (author == null)
                {
                    author = new Author
                    {
                        Name = _vm.Item.AuthorName!,
                    };
                    context.Author.Add(author);
                    // 新しい著者を登録してIDを取得する
                    context.SaveChanges();
                }
            }
            // 出版社名を調べてなければ追加する
            if (_vm.Item.PublisherName != "")
            {
                publisher = context.Publisher.FirstOrDefault(t => t.Name == _vm.Item.PublisherName);
                if (publisher == null)
                {
                    publisher = new Publisher
                    {
                        Name = _vm.Item.PublisherName!
                    };
                    context.Publisher.Add(publisher);
                    // 新しい出版社を登録してIDを取得する
                    context.SaveChanges();
                }
            }
            if (_vm.Item.Id == 0)
            {
                // 書籍を追加する
                context.Book.Add(new Book
                {
                    Title = _vm.Item.Title,
                    Price = _vm.Item.Price,
                    AuthorId = author?.Id,
                    PublisherId = publisher?.Id,
                });
            }
            else
            {
                // 書籍を更新する
                var it = context.Book.Find(_vm.Item.Id);
                it.Title = _vm.Item.Title;
                it.Price = _vm.Item.Price;
                it.AuthorId = author?.Id;
                it.PublisherId = publisher?.Id;
                context.Book.Update(it);
            }
            context.SaveChanges();
            // コミットする
            tr.Commit();
            // 再検索する
            search();
        }

        /// <summary>
        /// 項目を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDelete(object sender, RoutedEventArgs e)
        {
            if (_vm.Item == null) { return; }

            var context = new MyContext();
            // トランザクションを開始
            var tr = context.Database.BeginTransaction();
            var it = context.Book.Find(_vm.Item.Id);
            context.Book.Remove(it);
            context.SaveChanges();
            // コミットする
            tr.Commit();
            // 再検索する
            search();
        }

    }

    public class BookItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? AuthorName { get; set; } = "";
        public string? PublisherName { get; set; } = "";
        public int Price { get; set; }

    }
    public class ViewModel : Prism.Mvvm.BindableBase
    {
        private List<BookItem> _items = new List<BookItem>();
        private BookItem? _item = null;

        public List<BookItem> Items { get => _items; set => SetProperty(ref _items, value, nameof(Items)); }
        public BookItem? Item { get => _item; set => SetProperty(ref _item, value, nameof(Item)); }
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
        public DateTime CreatedAt { get; set; }    // 扱い始めた日時
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
        public int? AuthorId { get; set; }          // 作者未定の場合
        public int? PublisherId { get; set; }       // 自費出版のときは null
        public int Price { get; set; }

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
        }
        public DbSet<Store> Store => Set<Store>();
        public DbSet<Book> Book => Set<Book>();
        public DbSet<Author> Author => Set<Author>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
    }
}
