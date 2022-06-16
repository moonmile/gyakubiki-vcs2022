using System.Reflection;

namespace ref455;

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
        foreach (var pi in typeof(Sample).GetProperties())
        {
            var attr = pi.GetCustomAttribute<MyCustomAttribute>();
            listBox1.Items.Add($"{pi.Name} {attr?.Name} {attr?.Description}");
        }

    }
}

/// <summary>
/// カスタム属性
/// </summary>
public class MyCustomAttribute : Attribute {
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
}


public class Sample
{
    [MyCustom(Name = "識別子", Description = "オブジェクトを一意に識別する")]
    public int Id { get; set; }
    [MyCustom(Name = "名前", Description = "名前を日本語で記述します")]
    public string Name { get; set; } = "";
    [MyCustom(Name = "住所", Description = "住所を日本語で記述します")]
    public string Address { get; set; } = "";
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
}

