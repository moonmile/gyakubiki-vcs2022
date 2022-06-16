namespace excel489;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var dt = dateTimePicker1.Value;
        var title = textBox1.Text;
        var check = checkBox1.Checked;


        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            int r = 2;
            // 末尾あるいは要件がマッチする行を探す
            while (sh.Cell(r, 1).GetString() != "")
            {
                if ( sh.Cell(r, 1).GetString()== title )
                {
                    break;
                }
                r++;
            }
            if (sh.Cell(r, 1).GetString() == "")
            {
                // 末尾に追加する
                sh.Cell(r, 1).Value = dt.ToString("yyyy/MM/dd");
                sh.Cell(r, 2).Value = title;
                sh.Cell(r, 3).Value = check ? "完了" : "未完了";
            } 
            else
            {
                // チェックだけを更新する
                sh.Cell(r, 3).Value = check ? "完了" : "未完了";
            }
            // 上書きで保存
            wb.Save();
        }
        MessageBox.Show("データを更新しました");
    }
}
