namespace ref446;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
    }

    /// <summary>
    /// �����l��ݒ肵�Ă���
    /// </summary>
    Sample _obj = new Sample
    {
        Id = 100,
        Name = "�}�X�_�g���A�L",
        Address = "����"
    };
    private void Form1_Load(object? sender, EventArgs e)
    {
        textBox1.Text = _obj.Name;
    }

    /// <summary>
    /// ���t���N�V�����Œl���擾
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        // ���t���N�V�����Őݒ�
        var pi = typeof(Sample).GetProperty("Name");
        var value = pi?.GetValue(_obj) as string;
        textBox2.Text = value;
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

