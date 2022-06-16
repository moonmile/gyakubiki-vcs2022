namespace ref444;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var name = textBox1.Text;
        var mi = typeof(Sample).GetMethod(name);
        if ( mi == null )
        {
            textBox2.Text = "メソッドが見つかりませんでした";
        }
        else
        {
            string text = $@"
メソッド名： {mi.Name}
引数の数： {mi.GetParameters().Length}
戻り値の型： {mi.ReturnType}
";
            textBox2.Text = text;

        }
    }
}

public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
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

