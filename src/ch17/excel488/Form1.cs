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
            // �I�[��T��
            while (sh.Cell(rmax, 1).GetString() != "")
            {
                rmax++;
            }
            rmax--;
            var rg = sh.Range(sh.Cell(1, 1), sh.Cell(rmax, 4));
            // �t�H���g��ς���
            rg.Style.Font.FontName = "UD �f�W�^�� ���ȏ��� N-B";
            rg.Style.Font.Italic = true;
            wb.Save();
        }
        MessageBox.Show("�t�H���g��ݒ肵�܂���");

    }
}
