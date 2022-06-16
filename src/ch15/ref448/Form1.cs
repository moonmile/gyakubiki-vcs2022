using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
namespace ref448;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // クラスの属性を取得する
        var attr = typeof(Sample).GetCustomAttribute<TableAttribute>();
        textBox1.Text = attr?.Name;
    }
}

[Table("サンプルクラス")] // この属性を取得
public class Sample
{
    [Key]
    [DisplayNameAttribute("識別子")]
    public int Id { get; set; }
    [DisplayNameAttribute("名前")]
    public string Name { get; set; } = "";
    [DisplayNameAttribute("住所")]
    public string Address { get; set; } = "";
    /// <summary>
    /// プロパティの値を表示する
    /// </summary>
    /// <returns></returns>
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
    /// <summary>
    /// 住所を変更する
    /// </summary>
    /// <param name="address"></param>
    public void ChangeAddress(string address)
    {
        this.Address = address;
    }
}



