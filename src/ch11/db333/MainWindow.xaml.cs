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

namespace db333
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

        private void clickSearch(object sender, RoutedEventArgs e)
        {
            var context = new DatabaseContext();
            this.dg.ItemsSource = context.Book.ToList();
        }
    }

    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string Title { get; set; } = "";
        public int? AuthorId { get; set; }
        public int Price { get; set; }
        public int? PublisherId { get; set; }
    }

    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string Name { get; set; } = "";
        [MaxLength(32)]
        public string Address { get; set; } = "";
    }

    // Microsoft.EntityFrameworkCore.Tools を追加
    // 「ツール」→「NuGet パッケージマネージャ」から「パッケージマネージャコンソール」を開く
    // Add-Migration Initial
    // Update-Database



    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(local)";
            builder.InitialCatalog = "sampledb";
            builder.IntegratedSecurity = true;
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
        public DbSet<Book> Book => Set<Book>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
    }

}
