namespace net382;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// GETメソッドの呼び出し
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(textBox1.Text);

        var cl = new HttpClient();
        var url = $"http://localhost:5000/api/Gyakubiki/{id}";
        var response = await cl.GetStringAsync(url);
        textBox2.Text = response; 
    }
}
