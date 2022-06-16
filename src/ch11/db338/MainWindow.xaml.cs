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
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Prism.Mvvm;

namespace db338
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (_, _) =>
            {
                _vm = new ViewModel();
                DataContext = _vm;
            };
        }
        // デフォルト値を入れておく
        private ViewModel _vm = new();
        private readonly MyContext _context = new();
        /// <summary>
        /// データベースから検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickSearch(object sender, RoutedEventArgs e)
        {
            string name = _vm.Name;
            if (name == "")
            {
                // 空欄の場合はすべて検索
                _vm.Items = _context.Person.ToList();
                _vm.Count = _vm.Items.Count;
            }
            else
            {
                // 入力した文字列を含む Person を検索する
                var q = from t in _context.Person
                        where t.Name.Contains(name)
                        select t;
                _vm.Items = q.ToList();
                _vm.Count = q.Count();
                // 以下でもよい
                // _vm.Count = _vm.Items.Count;
            }
        }
    }

    public class ViewModel : BindableBase
    {
        private string _name = "";
        public string Name { get => _name; set => SetProperty(ref _name, value, nameof(Name)); }
        private int _count = 0;
        public int Count {  get => _count; set => SetProperty(ref _count, value, nameof(Count)); }

        private List<Person> _items = new();
        public List<Person> Items { get => _items; set => SetProperty(ref _items, value, nameof(Items)); }
    }

    public class Person
    {
        [Key]
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
