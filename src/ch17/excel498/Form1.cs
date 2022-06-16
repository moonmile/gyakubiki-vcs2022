using System.Text;

namespace excel498;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // .NET 5/6 �ł͂��ꂪ�K�v
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var urlmax = $"http://www.data.jma.go.jp/obd/stats/data/mdrr/tem_rct/alltable/mxtemsadext00_rct.csv";
        var urlmin = $"http://www.data.jma.go.jp/obd/stats/data/mdrr/tem_rct/alltable/mntemsadext00_rct.csv";
        var hc = new HttpClient();

        var enc = Encoding.GetEncoding("shift_jis");
        var st = await hc.GetStreamAsync(urlmax);
        var tr = new StreamReader(st, enc, false) as TextReader;
        var csvmax = await tr.ReadToEndAsync();

        st = await hc.GetStreamAsync(urlmin);
        tr = new StreamReader(st, enc, false) as TextReader;
        var csvmin = await tr.ReadToEndAsync();

        var data = new List<Data>();
        // �ō��C��CSV���p�[�X����
        var lst = csvmax.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
        // �擪�s�͍폜����
        lst.RemoveAt(0);
        foreach (string line in lst)
        {
            var vals = line.Split(new string[] { "," }, StringSplitOptions.None);
            if (vals.Count() > 13)
            {
                // �ϑ��ԍ�, �s���{��, �n�_, �ō��C��, �ō��C��(��), �ō��C��(��) ���擾
                try
                {
                    var d = new Data()
                    {
                        Id = int.Parse(vals[0]),
                        Place1 = vals[1],
                        Place2 = vals[2],
                        TemperatureMax = double.Parse(vals[9]),
                        MaxHour = int.Parse(vals[11]),
                        MinMinitue = int.Parse(vals[12])
                    };
                    data.Add(d);
                }
                catch { }
            }
        }
        // �Œ�C��CSV���p�[�X����
        lst = csvmin.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
        lst.RemoveAt(0);
        foreach (string line in lst)
        {
            var vals = line.Split(new string[] { "," }, StringSplitOptions.None);
            if (vals.Count() > 13)
            {
                // �ϑ��ԍ�, �s���{��, �n�_, �Œ�C��, �Œ�C��(��), �Œ�C��(��) ���擾
                try
                {

                    var id = int.Parse(vals[0]);
                    var temp = double.Parse(vals[9]);
                    var hour = int.Parse(vals[11]);
                    var min = int.Parse(vals[12]);
                    var d = data.First(x => x.Id == id);
                    if (d != null)
                    {
                        d.TemperatureMin = temp;
                        d.MinHour = hour;
                        d.MinMinitue = min;
                    }
                }
                catch { }
            }
        }
        textBox1.Text = "�擾����";

        // Excel �ɏo�͂���
        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            sh.Cell(1, 1).Value = "�ϑ��ԍ�";
            sh.Cell(1,2).Value = "�s���{��";
            sh.Cell(1, 3).Value = "�n�_";
            sh.Cell(1, 4).Value = "�Œ�C��";
            sh.Cell(1, 5).Value = "����";
            sh.Cell(1, 6).Value = "�ō��C��";
            sh.Cell(1, 7).Value = "����";

            int r = 2;
            foreach (var d in data)
            {
                sh.Cell(r, 1).Value = d.Id;
                sh.Cell(r, 2).Value = d.Place1;
                sh.Cell(r, 3).Value = d.Place1;
                sh.Cell(r, 4).Value = d.TemperatureMax;
                sh.Cell(r, 5).Value = $"{d.MaxHour}:{d.MaxMinitue}";
                sh.Cell(r, 6).Value = d.TemperatureMin;
                sh.Cell(r, 7).Value = $"{d.MinHour}:{d.MinMinitue}";
                r++;
            }
            wb.Save();
        }
        MessageBox.Show("�ō�/�Œ�C�����擾���܂���");
    }

}

#nullable disable

public class Data
{
    public int Id { get; set; }
    public string Place1 { get; set; }
    public string Place2 { get; set; }
    public double TemperatureMax { get; set; }
    public double TemperatureMin { get; set; }
    public int MaxHour { get; set; }
    public int MaxMinitue { get; set; }
    public int MinHour { get; set; }
    public int MinMinitue { get; set; }
}
