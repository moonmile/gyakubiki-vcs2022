namespace excel486;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string title = textBox1.Text;

        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            int r = 2;
            while (sh.Cell(r, 1).GetString() != "")
            {
                // 書名を調べる
                if (sh.Cell(r, 2).GetString() == title)
                {
                    // 列全体に色を付ける
                    var rg = sh.Range(sh.Cell(r, 1), sh.Cell(r, 4));
                    rg.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Pink;
                }
                r++;
            }
            wb.Save();
        }
        MessageBox.Show("色を変更しました");

    }
}
