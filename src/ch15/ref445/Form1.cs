namespace ref445;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
    }
    /// <summary>
    /// 初期値を設定しておく
    /// </summary>
    Sample _obj = new Sample
    {
        Id = 100,
        Name = "マスダトモアキ",
        Address = "板橋区"
    };
    private void Form1_Load(object? sender, EventArgs e)
    {
        textBox1.Text = _obj.Name;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // リフレクションで設定
        var pi = typeof(Sample).GetProperty("Name");
        pi?.SetValue(_obj, textBox2.Text);
        // 変更後
        MessageBox.Show($"変更しました： {_obj.Name}");
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


