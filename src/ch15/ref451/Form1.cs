using System.Reflection;

namespace ref451;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += (_, _) =>
        {
            textBox1.Text = _obj.hiddenData;
        };
    }
    Sample _obj = new Sample()
    {
        Id = 100,
        Name = "増田智明",
        Address = "板橋区",
        // hiddenData = "初期値", // ここは設定できない
    };

    private void button1_Click(object sender, EventArgs e)
    {
        // プロパティがpriavteのため設定できない
        // _obj.hiddenData = "初期値";

        // リフレクションを使って設定する
        SetPrivateProperty(_obj, "hiddenData", "初期値");
        // 変更後を参照する
        textBox2.Text = _obj.hiddenData;
    }

    private void SetPrivateProperty<T>( T target, string name, object value, params object[] args )
    {
        Type t = typeof(T);
        var pi = t.GetTypeInfo().GetDeclaredProperty(name);
        pi.SetValue(target, Convert.ChangeType(value, pi.PropertyType), args);

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
    public void ChangeAddress(string address)
    {
        this.Address = address;
    }
}


