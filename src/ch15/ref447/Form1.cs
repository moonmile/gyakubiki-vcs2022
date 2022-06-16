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
    /// �����l��ݒ肵�Ă���
    /// </summary>
    Sample _obj = new Sample
    {
        Id = 100,
        Name = "�}�X�_�g���A�L",
        Address = "����"
    };

    private void button1_Click(object sender, EventArgs e)
    {
        // ���t���N�V�����Ń��\�b�h���擾
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


