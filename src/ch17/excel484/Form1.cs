namespace excel484;

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
            var items = new List<Book>();
            int r = 2;
            while( sh.Cell(r,1).GetString() != "" )
            {
                var book = new Book()
                {
                    Id = sh.Cell(r, 1).GetValue<int>(),
                    Title = sh.Cell(r, 2).GetValue<string>(),
                    Price = sh.Cell(r, 3).GetValue<int>(),
                };
                items.Add(book);
                r++;
            }
            this.dataGridView1.DataSource = items;
        }

    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Price { get; set; }
    }
}
