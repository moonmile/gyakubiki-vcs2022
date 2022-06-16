using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net379
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// クエリ文字列を使って検索する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            var client = new HttpClient();
            var ub = new UriBuilder("https://www.google.co.jp/search");
            var query = System.Web.HttpUtility.ParseQueryString("");
            query.Add("q", System.Web.HttpUtility.UrlPathEncode(text));
            query.Add("hl", "jp");
            ub.Query = query.ToString();
            try
            {
                var response = await client.GetAsync(ub.Uri);
                textBox2.Text = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
