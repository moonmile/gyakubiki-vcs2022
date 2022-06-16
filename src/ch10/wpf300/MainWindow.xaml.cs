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

namespace wpf300
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
            lst2.Items.Add("こくご");
            lst2.Items.Add("さんすう");
            lst2.Items.Add("りか");
            lst2.Items.Add("しゃかい");
            lst2.Items.Add("プログラミング");
        }

        private void selectList1(object sender, SelectionChangedEventArgs e)
        {
            var item = lst1.SelectedItem as ListBoxItem;
            message.Text = "選択科目：" + item?.Content.ToString();

        }

        private void selectList2(object sender, SelectionChangedEventArgs e)
        {
            message.Text = "選択科目：" + lst2.SelectedItem.ToString();
        }
    }
}
