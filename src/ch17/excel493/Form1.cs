namespace excel493;
using Excel = Microsoft.Office.Interop.Excel;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var xapp = new Excel.Application();
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\sample.xlsx";
        var wb = xapp.Workbooks.Open(path);
        var sh = wb.ActiveSheet as Excel.Worksheet;
        sh.PrintOutEx();
        xapp.Quit();
        MessageBox.Show("������܂���");
    }
}
