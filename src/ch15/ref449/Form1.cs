using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ref449;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        // プロパティの属性を取得する
        foreach ( var  pi in typeof(Sample).GetProperties())
        {
            var attr = pi.GetCustomAttribute<DisplayNameAttribute>();
            listBox1.Items.Add($"{pi.Name} {attr?.DisplayName}");
        }
    }
}

[Table("サンプルクラス")] 
public class Sample
{
    [Key]
    [DisplayName("識別子")] // ここの属性を取得
    public int Id { get; set; }
    [DisplayName("名前")]
    public string Name { get; set; } = "";
    [DisplayName("住所")]
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

