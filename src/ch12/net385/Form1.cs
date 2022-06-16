using System.Text.Json;

namespace net385;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(textBox1.Text);
        var cl = new HttpClient();
        var url = $"http://localhost:5000/api/Gyakubiki/{id}";
        var response = await cl.GetStringAsync(url);
        // JSON�̑啶������������ʂ����Ƀf�V���A���C�Y����
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var book = JsonSerializer.Deserialize<Book>(response, options);

        if (book != null)
        {
            textBox2.Text =
@$"�����F{book.Title} 
���Җ��F{book.Author?.Name} 
�o�ŎЖ��F{book!.Publisher?.Name} 
���i�F{book.Price} 
";
        }
    }
}


/// <summary>
/// ���ЃN���X
/// </summary>
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }
    public int Price { get; set; }

    public Author? Author { get; set; }
    public Publisher? Publisher { get; set; }
}
/// <summary>
/// ���҃N���X
/// </summary>
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// �o�ŎЃN���X
/// </summary>
public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Address { get; set; } = "";
}
