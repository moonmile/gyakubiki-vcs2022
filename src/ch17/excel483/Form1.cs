namespace excel483;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sheet = wb.Worksheets.First();
            // �Z�������w��
            label1.Text = sheet.Cell("A1").GetString();
            // �s�ԍ�,��ԍ����w��
            // label1.Text = sheet.Cell(1,1).GetString();
        }
    }
}
