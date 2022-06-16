namespace excel496;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var url = "https://my.redmine.jp/demo/projects.json";
        var cl = new HttpClient();
        var json = await cl.GetStringAsync(url);
        textBox1.Text = json;
        var doc = System.Text.Json.JsonDocument.Parse(json);

        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path)) {
            var sh = wb.Worksheets.First();

            var projects = doc.RootElement.GetProperty("projects");
            int r = 2;
            foreach (var project in projects.EnumerateArray())
            {
                sh.Cell(r, 1).Value = project.GetProperty("id").GetInt16();
                sh.Cell(r, 2).Value = project.GetProperty("identifier").GetString();
                sh.Cell(r, 3).Value = project.GetProperty("name").GetString();
                sh.Cell(r, 4).Value = project.GetProperty("description").GetString();
                r++;
            }
            wb.Save();
        }
        MessageBox.Show("JSONŒ`Ž®‚ÅŽæ“¾‚µ‚Ü‚µ‚½");
    }
}
