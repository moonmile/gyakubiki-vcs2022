namespace excel485;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string title = textBox1.Text;
        int stock = int.Parse(textBox2.Text);

        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            int r = 2;
            while (sh.Cell(r, 1).GetString() != "")
            {
                // ‘–¼‚ğ’²‚×‚é
                if ( sh.Cell(r,2).GetString() == title )
                {
                    // İŒÉ”‚ğ‘‚«‚Ş
                    sh.Cell(r, 4).Value = stock;
                }
                r++;
            }
            wb.Save();
        }
        MessageBox.Show("İŒÉ”‚ğXV‚µ‚Ü‚µ‚½");
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
