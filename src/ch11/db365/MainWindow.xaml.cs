using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections.Specialized;

namespace db365
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
            var items = new ObservableCollection<Person>(q.ToList());
            this.dg.ItemsSource = items;


            // 新規追加と更新を判別する
            bool insertOrUpdate = false;
            this.dg.AddingNewItem += (_, ee) =>
            {
                insertOrUpdate = true;
            };
            // 行の更新が終わったとき
            this.dg.RowEditEnding += (_, ee) =>
            {
                if ( ee.EditAction == DataGridEditAction.Commit )
                {
                    if (insertOrUpdate)
                    {
                        ee.Row.Dispatcher.BeginInvoke( async () => {
                            // DataContext の中身を更新するまで少し待つ
                            await Task.Delay(10);
                            _context.Person.Add((Person)ee.Row.DataContext);
                            _context.SaveChanges();

                        });
                    }
                    else
                    {
                        ee.Row.Dispatcher.BeginInvoke(async () => {
                            // DataContext の中身を更新するまで少し待つ
                            await Task.Delay(10);
                            _context.Person.Update((Person)ee.Row.DataContext);
                            _context.SaveChanges();

                        });
                    }

                }
                insertOrUpdate = false;
            };
            // 行が削除されたとき
            items.CollectionChanged += (_, ee) =>
            {
                if (ee.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (Person item in ee.OldItems!)
                    {
                        _context.Person.Remove(item);
                    }
                    _context.SaveChanges();
                }
            };
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
