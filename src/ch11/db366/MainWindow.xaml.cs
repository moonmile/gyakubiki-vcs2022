using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

namespace db366
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
        MyContext _context = new MyContext();

        /// <summary>
        /// 検索を実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickSearch(object sender, RoutedEventArgs e)
        {
            var q = from t in _context.Person
                    select t;
            var items = q.ToList();
            this.dg.ItemsSource = items;
        }
    }

    /// <summary>
    /// Personクラス
    /// </summary>
    public class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
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
        public DbSet<Person> Person => Set<Person>();
    }
}
