using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace excel494;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // �f�[�^�x�[�X����擾
        var db = new MyContext();
        var items = db.Book.Include("Author").Include("Publisher").ToList();
        // Excel�ɋL�q
        string path = "sample.xlsx";
        using (var wb = new ClosedXML.Excel.XLWorkbook(path))
        {
            var sh = wb.Worksheets.First();
            int r = 2;
            foreach (var item in items)
            {
                sh.Cell(r, 1).Value = item.Id;
                sh.Cell(r, 2).Value = item.Title;
                sh.Cell(r, 3).Value = item.Author?.Name;
                sh.Cell(r, 4).Value = item.Publisher?.Name;
                sh.Cell(r, 5).Value = item.Price;
                r++;
            }
            // Excel��ۑ�
            wb.Save();
        }
        MessageBox.Show("�f�[�^���擾���܂���");
    }
}


/// <summary>
/// �݌ɃN���X
/// </summary>
public class Store
{
    [Key]
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }     // �����n�߂�����
    public DateTime UpdatedAt { get; set; }    // �݌ɂ��X�V��������
}
/// <summary>
/// ���ЃN���X
/// </summary>
public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int AuthorId { get; set; }
    public int? PublisherId { get; set; }       // ����o�ł̂Ƃ��� null
    public int Price { get; set; }

    public Author? Author { get; set; }
    public Publisher? Publisher { get; set; }
}
/// <summary>
/// ���҃N���X
/// </summary>
public class Author
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
/// <summary>
/// �o�ŎЃN���X
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
