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
            textBox2.Text = "���\�b�h��������܂���ł���";
        }
        else
        {
            string text = $@"
���\�b�h���F {mi.Name}
�����̐��F {mi.GetParameters().Length}
�߂�l�̌^�F {mi.ReturnType}
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
    /// �v���p�e�B�̒l��\������
    /// </summary>
    /// <returns></returns>
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
    /// <summary>
    /// �Z����ύX����
    /// </summary>
    /// <param name="address"></param>
    public void ChangeAddress(string address)
    {
        this.Address = address;
    }
}

