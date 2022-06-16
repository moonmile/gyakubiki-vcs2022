namespace excel487;

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
            // �I�[��T��
            while (sh.Cell(rmax, 1).GetString() != "")
            {
                rmax++;
            }
            rmax--;
            var rg = sh.Range(sh.Cell(1, 1), sh.Cell(rmax, 4));
            // �e�s�̌r��������
            rg.Style.Border.TopBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
            rg.Style.Border.BottomBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
            rg.Style.Border.LeftBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
            rg.Style.Border.RightBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
            // �S�̂𑾘g�ň͂�
            rg.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thick;
            // �^�C�g�������ɐF��h��
            var rtitle = sh.Range(sh.Cell(1, 1), sh.Cell(1, 4));
            rtitle.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Orange;
            wb.Save();
        }
        MessageBox.Show("�r����ݒ肵�܂���");
    }
}
