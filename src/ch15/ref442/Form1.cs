namespace ref442;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text;
        var pi = typeof(Sample).GetProperty(name);
        if ( pi == null )
        {
            textBox2.Text = "プロパティが見つかりません";
        }
        else
        {
            string text = $@"
プロパティ名： {pi.Name}
型： {pi.PropertyType.ToString()}
読み取り： {pi.CanRead}
書き込み： {pi.CanWrite}
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



