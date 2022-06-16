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

namespace wpf297
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

        private void clickCheck(object sender, RoutedEventArgs e)
        {
            var s = "";
            if (chk1.IsChecked == true) { s += "国語, "; }
            if (chk2.IsChecked == true) { s += "算数, "; }
            if (chk3.IsChecked == true) { s += "理科, "; }
            if (chk4.IsChecked == true) { s += "社会, "; }
            if (chk5.IsChecked == true) { s += "プログラミング, "; }
            this.message.Text = s;
        }
    }
}
