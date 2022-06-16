using System.Net;
using System.Text.Json;
using System.Linq;

namespace net389;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        // クッキーを再利用するため
        _cookie = new CookieContainer();
        _cl = new HttpClient(new HttpClientHandler()
        {
            UseCookies = true,
            CookieContainer = _cookie
        });
    }
    HttpClient _cl;
    CookieContainer _cookie;


    private async void button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(textBox1.Text);
        var url = $"http://localhost:5000/api/Gyakubiki/checkCookie";
        var response = await _cl.GetStringAsync(url);
        var userkey = _cookie.GetCookies( new Uri(url))["User-Key"]?.ToString();
        textBox2.Text = userkey;


    }
}

