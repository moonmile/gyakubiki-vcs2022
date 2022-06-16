namespace web426client;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// BASE64文字列に変換する
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(textBox1.Text);
        textBox2.Text = System.Convert.ToBase64String(data);
    }

    /// <summary>
    /// サーバーにBASE64文字列を送信する
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void button2_Click(object sender, EventArgs e)
    {
        var url = "https://localhost:7231/api/Books/upload";
        var base64 = textBox2.Text;
        var cl = new HttpClient();
        var context = new StringContent("\""+ base64 + "\"");
        context.Headers.ContentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("text/json");
        var response = await cl.PostAsync(url, context);
        textBox3.Text = await response.Content.ReadAsStringAsync();
    }
}
