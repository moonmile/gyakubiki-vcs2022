namespace ref445;

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

    private void button1_Click(object sender, EventArgs e)
    {
        // ���t���N�V�����Őݒ�
        var pi = typeof(Sample).GetProperty("Name");
        pi?.SetValue(_obj, textBox2.Text);
        // �ύX��
        MessageBox.Show($"�ύX���܂����F {_obj.Name}");
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


