using System.Reflection;

namespace ref452;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    Sample _obj = new Sample()
    {
        Id = 100,
        Name = "ëùìcíqñæ",
        Address = "î¬ã¥ãÊ",
    };

    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = (string)Invoke(_obj, "privateShowData", new object[] { });
    }

    private object Invoke<T>(T target, string name, object value, params object[] args)
    {
        Type t = typeof(T);
        var mi = t.GetTypeInfo().GetDeclaredMethod(name);
        return mi.Invoke(target, args);
    }
}

public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string hiddenData { get; private set; } = "initial value";

    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }

    private string privateShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }

    public void ChangeAddress(string address)
    {
        this.Address = address;
    }
}

