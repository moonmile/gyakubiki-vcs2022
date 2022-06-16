namespace ref443;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var mis = typeof(Sample).GetMethods();
        listBox1.Items.Clear();
        foreach( var mi in mis )
        {
            listBox1.Items.Add(mi.Name);
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

