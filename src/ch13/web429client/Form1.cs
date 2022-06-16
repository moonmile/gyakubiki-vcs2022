using System.ComponentModel.DataAnnotations;

namespace web429client;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private Store? _store;

    private async void button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(textBox1.Text);
        string url = $"https://localhost:7282/api/Stores/{id}";
        var cl = new HttpClient();
        var json = await cl.GetStringAsync(url);
        _store = System.Text.Json.JsonSerializer.Deserialize<Store>(
            json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        if ( _store == null )
        {
            MessageBox.Show("�w�肵���݌ɂ�������܂���");
            return;
        }
        textBox2.Text = _store.Stock.ToString();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        if (_store == null) return;

        string url = $"https://localhost:7282/api/Stores/{_store.Id}";
        _store.Stock = int.Parse(textBox2.Text);
        var cl = new HttpClient();
        string json = System.Text.Json.JsonSerializer.Serialize(_store);
        var context = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await cl.PostAsync(url, context);
        if (response.IsSuccessStatusCode)
        {
            MessageBox.Show("�݌ɐ���ύX���܂���");
        }
        else
        {
            MessageBox.Show("�݌ɐ��̕ύX�Ɏ��s���܂���");
        }
    }
}

/// <summary>
/// �݌ɃN���X
/// </summary>
public class Store
{
    [Key]
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

