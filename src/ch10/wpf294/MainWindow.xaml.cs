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

namespace wpf294
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

        private void clickLarge(object sender, RoutedEventArgs e)
        {
            message.FontSize = message.FontSize * 1.2;
            fontsize.Text = "font size: " + message.FontSize.ToString("0.00");
        }

        private void clickSmall(object sender, RoutedEventArgs e)
        {
            message.FontSize = message.FontSize * 0.8;
            fontsize.Text = "font size: " + message.FontSize.ToString("0.00");
        }
    }
}
