namespace excel488;

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
            var sh = wb.Worksheets.First();
            int rmax = 2;
            // 終端を探す
            while (sh.Cell(rmax, 1).GetString() != "")
            {
                rmax++;
            }
            rmax--;
            var rg = sh.Range(sh.Cell(1, 1), sh.Cell(rmax, 4));
            // フォントを変える
            rg.Style.Font.FontName = "UD デジタル 教科書体 N-B";
            rg.Style.Font.Italic = true;
            wb.Save();
        }
        MessageBox.Show("フォントを設定しました");

    }
}
