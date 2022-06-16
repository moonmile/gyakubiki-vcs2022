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
            textBox2.Text = "�v���p�e�B��������܂���";
        }
        else
        {
            string text = $@"
�v���p�e�B���F {pi.Name}
�^�F {pi.PropertyType.ToString()}
�ǂݎ��F {pi.CanRead}
�������݁F {pi.CanWrite}
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



