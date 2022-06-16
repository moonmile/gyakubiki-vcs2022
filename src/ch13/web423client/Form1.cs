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
                textBox2.Text = "���Ђ�������܂���ł���";
            }
            else
            {
                textBox2.Text = @$"
ID: {book.Id}
����: {book.Title}
���Җ�: {book.Author?.Name}
�o�ŎЖ�: {book.Publisher?.Name}
���i: {book.Price} �~
";

            }
        }
    }


    /// <summary>
    /// ���ЃN���X
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int Price { get; set; }
        // �֘A����e�[�u��
        public Author? Author { get; set; }
        public Publisher? Publisher { get; set; }
    }
    /// <summary>
    /// ���҃N���X
    /// </summary>
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
    /// <summary>
    /// �o�ŎЃN���X
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