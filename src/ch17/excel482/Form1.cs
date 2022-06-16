namespace excel482;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string path = "sample.xlsx";
        using ( var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            label1.Text = wb.Worksheets.First().Name;
        }
    }
}
