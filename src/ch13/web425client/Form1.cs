namespace web425client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����ID���w�肵�āA�����Ɖ��i��ύX����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;
            HttpClient client = new HttpClient();
            var bookUpdate = new BookUpdate()
            {
                Id = int.Parse(textBox2.Text),
                Title = textBox3.Text,
                Price = int.Parse(textBox4.Text),
            };
            string json = System.Text.Json.JsonSerializer.Serialize(bookUpdate);
            var context = new StringContent(json,System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{url}/{bookUpdate.Id}", context);
            textBox5.Text = await response.Content.ReadAsStringAsync();
        }
    }

    /// <summary>
    /// ���Ђ̕ύX�N���X
    /// </summary>
    public class BookUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Price { get; set; }
    }

}