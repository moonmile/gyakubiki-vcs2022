using Prism.Mvvm;
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

namespace wpf320
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

        private ViewModel _vm = new ViewModel();
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.Id = 100;
            this.DataContext = _vm;
        }

        private void clickCommit(object sender, RoutedEventArgs e)
        {
            _vm.Message = $"{_vm.Name} さん、登録完了";
        }
    }
    public class ViewModel : BindableBase
    {
        private int _id = 0;
        private string _name = "";
        private int _age = 0;
        private string _address = "";
        private string _message = "";
        public int Id { get => _id; set => SetProperty(ref _id, value, nameof(Id)); }
        public string Name { get => _name; set => SetProperty(ref _name, value, nameof(Name)); }
        public int Age { get => _age; set => SetProperty(ref _age, value, nameof(Age)); }
        public string Address { get => _address; set => SetProperty(ref _address, value, nameof(Address)); }
        public string Message { get => _message; set => SetProperty(ref _message, value, nameof(Message)); }
    }
}
