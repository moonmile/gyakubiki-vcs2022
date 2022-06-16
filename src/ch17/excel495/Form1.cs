using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace excel495;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var db = new MyContext();
        // Excel から読み込み
        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            int r = 2;
            while ( sh.Cell(r,1).GetString() != "" )
            {
                var id = sh.Cell(r, 1).GetValue<int>();
                var price = sh.Cell(r,5).GetValue<int>();
                var item = db.Book.FirstOrDefault(t => t.Id == id);
                if (item != null )
                {
                    // 価格を更新
                    item.Price = price;
                }
                r++;
            }
            db.SaveChanges();
        }
        MessageBox.Show("価格を更新しました");
    }
}

/// <summary>
/// 在庫クラス
/// </summary>
public class Store
{
    [Key]
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }     // 扱い始めた日時
    public DateTime UpdatedAt { get; set; }    // 在庫を更新した日時
}
/// <summary>
/// 書籍クラス
/// </summary>
public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }       // 自費出版のときは null
    public int Price { get; set; }

    public Author? Author { get; set; }
    public Publisher? Publisher { get; set; }
}
/// <summary>
/// 著者クラス
/// </summary>
public class Author
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// 出版社クラス
/// </summary>
public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Address { get; set; } = "";
}

public class MyContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(local)";
        builder.InitialCatalog = "sampledb";
        builder.IntegratedSecurity = true;
        optionsBuilder.UseSqlServer(builder.ConnectionString);
    }
    public DbSet<Store> Store => Set<Store>();
    public DbSet<Book> Book => Set<Book>();
    public DbSet<Author> Author => Set<Author>();
    public DbSet<Publisher> Publisher => Set<Publisher>();
}
