namespace excel500;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var url = "http://www.shuwasystem.co.jp/products/7980html/5002.html";
        var cl = new HttpClient();
        var html = await cl.GetStringAsync(url);
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);

        var title = doc.DocumentNode.SelectSingleNode("//h1[@class='titleType1']").InnerText.Trim();
        var div = doc.DocumentNode.SelectSingleNode("//div[@class='right']");
        var table = div.SelectSingleNode(".//table");
        var items = table.SelectNodes("*/tr/td");
        var author = items[0].InnerText.Trim();
        var isbn = items[3].InnerText.Trim();
        var date = items[2].InnerText.Trim();
        var text = $"タイトル {title}\r\n著者: {author}\r\nISBN: {isbn}\r\n発売日: {date}\r\n";
        textBox1.Text = text;
        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            sh.Cell(1, 1).Value = "タイトル";
            sh.Cell(2, 1).Value = "著者";
            sh.Cell(3, 1).Value = "ISBN";
            sh.Cell(4, 1).Value = "発売日";

            sh.Cell(1, 2).Value = title;
            sh.Cell(2, 2).Value = author;
            sh.Cell(3, 2).Value = isbn;
            sh.Cell(4, 2).Value = date;
            wb.Save();
        }
    }
}
