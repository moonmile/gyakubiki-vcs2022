using System.ComponentModel.DataAnnotations;

namespace web423client
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
            var json = await cl.GetStringAsync(url);
            var book = System.Text.Json.JsonSerializer.Deserialize<Book>(
                json, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if ( book == null )
            {
                textBox2.Text = "書籍が見つかりませんでした";
            }
            else
            {
                textBox2.Text = @$"
ID: {book.Id}
書名: {book.Title}
著者名: {book.Author?.Name}
出版社名: {book.Publisher?.Name}
価格: {book.Price} 円
";

            }
        }
    }


    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int Price { get; set; }
        // 関連するテーブル
        public Author? Author { get; set; }
        public Publisher? Publisher { get; set; }
    }
    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
    /// <summary>
    /// 出版社クラス
    /// </summary>
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}