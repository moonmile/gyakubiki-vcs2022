using System.Reflection;

namespace ref453;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var asm = Assembly.GetExecutingAssembly();
        dynamic? obj = asm.CreateInstance("ref453.Sample");
        if ( obj != null)
        {
            // プロパティを設定
            obj.Id = 100;
            obj.Name = "増田智明";
            obj.Address = "東京都板橋区";
            // メソッドの呼び出し
            textBox1.Text = obj.ShowData() as string; 
        } 
        else
        {
            textBox1.Text = "インスタンスを生成できません";
        }
    }
}
public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
}

