namespace ref447;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += (_, _) =>
         {
             textBox1.Text = _obj.ShowData();
         };
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

    private void button1_Click(object sender, EventArgs e)
    {
        // リフレクションでメソッドを取得
        var mi = typeof(Sample).GetMethod("ShowData");
        var value = mi?.Invoke(_obj, new object[] { }) as string;
        textBox2.Text = value;
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


