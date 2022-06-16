namespace excel490;

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
            listBox1.Items.Clear();
            foreach ( var sh in wb.Worksheets )
            {
                listBox1.Items.Add(sh.Name);
            }
        }
    }
}
