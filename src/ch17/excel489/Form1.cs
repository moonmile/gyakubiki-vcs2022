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
            // �������邢�͗v�����}�b�`����s��T��
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
                // �����ɒǉ�����
                sh.Cell(r, 1).Value = dt.ToString("yyyy/MM/dd");
                sh.Cell(r, 2).Value = title;
                sh.Cell(r, 3).Value = check ? "����" : "������";
            } 
            else
            {
                // �`�F�b�N�������X�V����
                sh.Cell(r, 3).Value = check ? "����" : "������";
            }
            // �㏑���ŕۑ�
            wb.Save();
        }
        MessageBox.Show("�f�[�^���X�V���܂���");
    }
}
