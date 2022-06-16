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

namespace wpf293
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
            /// メソッドを呼び出す
            this.btnSend.Click += BtnSend_Click;

            /// ラムダ式でイベントを記述する
            this.btnRecv.Click += (_, _) =>
            {
                message.Text = "受信ボタンを押しました";
            };
        }

        /// <summary>
        /// XAMLにClickイベントを記述する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickOpen(object sender, RoutedEventArgs e)
        {
            message.Text = "開くボタンを押しました";
        }

        /// <summary>
        /// 画面ロード時にClickイベントを設定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            message.Text = "送信ボタンを押しました";
        }

    }
}
