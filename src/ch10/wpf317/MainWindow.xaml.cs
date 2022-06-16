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

namespace wpf317
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

        private void clickStart(object sender, RoutedEventArgs e)
        {
            for ( int i=0; i<10; i++ )
            {
                var rc = new Rectangle()
                {
                    Stroke = box1.Stroke,
                    StrokeThickness = box1.StrokeThickness,
                    Width = box1.Width,
                    Height = box1.Height,
                    
                };
                int x = Random.Shared.Next(-50, 250);
                int y = Random.Shared.Next(-50, 250);
                // 位置を設定する
                Canvas.SetLeft(rc, x);
                Canvas.SetTop(rc, y);
                // キャンバスに追加する
                cv.Children.Add(rc);
            }
        }
    }
}
