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

namespace wpf299
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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cb2.Items.Add("こくご");
            cb2.Items.Add("さんすう");
            cb2.Items.Add("りか");
            cb2.Items.Add("しゃかい");
            cb2.Items.Add("ぷろぐらみんぐ");
        }

        private void selectComboBox1(object sender, RoutedEventArgs e)
        {
            var item = cb1.SelectedItem as ComboBoxItem;
            message.Text = "選択科目：" + item?.Content.ToString();
        }

        private void selectComboBox2(object sender, RoutedEventArgs e)
        {
            message.Text = "選択科目：" + cb2.SelectedItem.ToString();
        }
    }
}
