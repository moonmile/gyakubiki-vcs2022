using System.Net.Http.Headers;

namespace web424client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;
            var cl = new HttpClient();
            cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));
            var data = await cl.GetByteArrayAsync(url );
            var mem = new MemoryStream(data);
            var bmp = Bitmap.FromStream(mem);
            pictureBox1.Image = bmp;
        }
    }
}