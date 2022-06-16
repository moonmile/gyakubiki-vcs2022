namespace ref454;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // あらかじめ dll をコピーしておく
        var asm = System.Reflection.Assembly.LoadFrom("ref454Lib.dll");
        dynamic? obj = asm.CreateInstance("ref454Lib.Sample");
        if (obj != null)
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
