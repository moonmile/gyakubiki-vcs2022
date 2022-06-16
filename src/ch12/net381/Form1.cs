using System.Net.Http.Headers;
using System.Net.Mime;

namespace net381;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string url = "http://localhost:5000/api/Gyakubiki/upload";
        string path = "sample-upload.zip";
        Stream fileStream = System.IO.File.OpenRead(path);

        var multipartContent = new MultipartFormDataContent();
        multipartContent.Add(new StreamContent(fileStream), "zipfile", path);
        multipartContent.Headers.ContentDisposition = 
            new ContentDispositionHeaderValue("form-data") { Name = "zipfile", FileName = path };
        var client = new HttpClient();
        try
        {
            var response = await client.PostAsync(url, multipartContent);
            if ( response.IsSuccessStatusCode )
            {
                MessageBox.Show("アップロードが完了しました");
            }
            else
            {
                MessageBox.Show("アップロードに失敗しました");
            }
        } catch (Exception ex)
        {
            // アップロードが異常の場合は例外が発生する
            MessageBox.Show(ex.Message);
        }
    }
}
