using Prism.Mvvm;
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

namespace wpf325
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
            _vm.Person.Id = 100;
            this.DataContext = _vm;
        }

        private void clickSubmit(object sender, RoutedEventArgs e)
        {
            _vm.Message = $"{_vm.Person.Name} さん、登録完了";
            _vm.Items.Add(_vm.Person);
            _vm.Person = new Person() { Id = _vm.Person.Id + 1 };
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Address { get; set; } = "";

        public override string ToString()
        {
            return $"{Id}: {Name}({Age}) in {Address}";
        }
    }



    public class ViewModel : BindableBase
    {
        private Person _person = new Person();
        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value, nameof(Person));
        }
        public ObservableCollection<Person> Items
        {
            get;
            private set;
        } = new ObservableCollection<Person>();
        private string _message = "";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value, nameof(Message));
        }
    }
}
