namespace excel491;

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
            // �Ō�ɐV�����V�[�g��ǉ�����
            var sh = wb.Worksheets.Add(0);
            sh.Name = textBox1.Text;
            sh.Cell("A1").Value = "�V�����V�[�g";
            wb.Save();
        }
        MessageBox.Show("�V�[�g��ǉ����܂���");

    }
}
