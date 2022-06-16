namespace excel499;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var url = "http://shuwasystem.co.jp";
        var cl = new HttpClient();
        var html = await cl.GetStringAsync(url);
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        var lst = doc.DocumentNode.SelectNodes("//li[@class='items']");
        var items = new List<string>();
        var books = new List<Book>();
        foreach (var it in lst)
        {
            var a = it.SelectSingleNode(".//a");
            var img = it.SelectSingleNode(".//img");
            var text = img.GetAttributeValue("alt", "");
            var link = a.GetAttributeValue("href", "");
            items.Add(text);
            books.Add(new Book() { Title = text, Link = link });
        }
        listBox1.DataSource = items;

        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            sh.Cell(1, 1).Value = "タイトル";
            sh.Cell(1, 2).Value = "リンク";
            int r = 2;
            foreach (var it in books)
            {
                sh.Cell(r, 1).Value = it.Title;
                sh.Cell(r, 2).Value = it.Link;
                r++;
            }
            wb.Save();
        }
    }
}

#nullable disable
public class Book
{
    public string Title { get; set; }
    public string Link { get; set; }
}
