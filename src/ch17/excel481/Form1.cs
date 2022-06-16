namespace excel481;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Microsoft Excel Object Library ‚Ì—˜—p
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        var xapp = new Microsoft.Office.Interop.Excel.Application();
        xapp.Quit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        using (var wb = new ClosedXML.Excel.XLWorkbook())
        {
            var sheet = wb.Worksheets.Add("sample");
        }
    }
}
