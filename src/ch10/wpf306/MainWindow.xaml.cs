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

namespace wpf306
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

        private void changeDatePicker(object sender, SelectionChangedEventArgs e)
        {
            var dt = dp.SelectedDate;
            this.message.Text = dt.ToString();

        }

        private void changeCalendar(object sender, SelectionChangedEventArgs e)
        {
            var dt = cal.SelectedDate;
            this.message.Text = dt.ToString();

        }
    }
}
