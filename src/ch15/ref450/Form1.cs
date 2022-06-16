using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ref450;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // メソッドの属性を取得
        var mi = typeof(Sample).GetMethod("ShowData");
        var attr = mi?.GetCustomAttribute<DisplayAttribute>();
        textBox1.Text = attr?.Description;

    }
}

[Table("サンプルクラス")]
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
    [Display(Description = "フォーマットした文字列を取得する")] 
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

