namespace excel497;

using System.Text.Json;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// https://weather.tsukumijima.net/ を利用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void button1_Click(object sender, EventArgs e)
    {
        int city = 130000; // 東京都
        var url = $"https://www.jma.go.jp/bosai/forecast/data/overview_forecast/{city}.json";
        var cl = new HttpClient();
        var json = await cl.GetStringAsync(url);
        textBox1.Text = json;
        var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        var title = root.GetProperty("targetArea").GetString();
        var date = root.GetProperty("reportDatetime").GetString();
        var headline = root.GetProperty("headlineText").GetString();
        var description = root.GetProperty("text").GetString()!;
        description = description.Replace("\\n", "\n");

        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            sh.Cell(1, 2).Value = title;
            sh.Cell(2, 2).Value = date;
            sh.Cell(3, 2).Value = headline;
            sh.Cell(4, 2).Value = description;
            wb.Save();
        }
        MessageBox.Show("天気予測データを取得しました");
    }
}
