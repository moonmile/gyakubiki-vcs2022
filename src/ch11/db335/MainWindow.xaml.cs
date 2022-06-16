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
using System.Collections.ObjectModel;

namespace db335
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
            _vm.Items = new ObservableCollection<Person>(
                _context.Person.ToList());
        }

        /// <summary>
        /// 新規にクリアする
        /// カーソルを外して、テキストボックスを空欄にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickNew(object sender, RoutedEventArgs e)
        {
            _vm.SelectedItem = null;
            _vm.Name = "";
            _vm.Age = 0;
            _vm.Address = "";
        }


        /// Tips 334 
        /// 「新規」でクリアした後に、追加する
        /// <summary>
        /// データベースに追加
        /// （あらかじめて「新規」ボタンでクリアしておく
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickAdd(object sender, RoutedEventArgs e)
        {
            var item = new Person()
            {
                Name = _vm.Name,
                Age = _vm.Age,
                Address = _vm.Address,
            };
            _context.Person.Add(item);
            _context.SaveChanges();
            // DataGridにも追加する
            _vm.Items.Add(item);
        }

        /// Tips 335 
        /// 「更新」した後にリストをも更新する
        /// <summary>
        /// データベースを更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickUpdate(object sender, RoutedEventArgs e)
        {
            // 選択位置の項目を更新する
            if (_vm.SelectedItem == null) return;
            var item = _vm.SelectedItem;
            item.Name = _vm.Name;
            item.Age = _vm.Age;
            item.Address = _vm.Address;
            _context.Person.Update(item);
            _context.SaveChanges();

            // カーソル位置を保持してリロードする
            _vm.SelectedItem = null;
            _vm.Items = new ObservableCollection<Person>(
                _context.Person.ToList());
            _vm.SelectedItem = _vm.Items.FirstOrDefault(t => t.Id == item.Id);
        }

        /// <summary>
        /// データベースから削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDelete(object sender, RoutedEventArgs e)
        {
            // 選択位置の項目を削除する
            if (_vm.SelectedItem == null) return;
            var item = _vm.SelectedItem;
            _context.Person.Remove(item);
            _context.SaveChanges();
            // カーソルを外す
            _vm.SelectedItem = null;
            _vm.Items.Remove(item);
        }

    }

    public class ViewModel : BindableBase
    {
        private string _name = "";
        private int _age;
        private string _address = "";
        public string Name { get => _name; set => SetProperty(ref _name, value, nameof(Name)); }
        public int Age { get => _age; set => SetProperty(ref _age, value, nameof(Age)); }
        public string Address { get => _address; set => SetProperty(ref _address, value, nameof(Address)); }

        private Person? _selectedItem = null;
        private ObservableCollection<Person> _items = new();

        public Person? SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value, nameof(SelectedItem));
                if (value != null)
                {
                    this.Name = value.Name;
                    this.Age = value.Age;
                    this.Address = value.Address;
                }
            }
        }
        public ObservableCollection<Person> Items { get => _items; set => SetProperty(ref _items, value, nameof(Items)); }
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
