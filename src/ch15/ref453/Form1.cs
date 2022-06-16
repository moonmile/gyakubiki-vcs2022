using System.Reflection;

namespace ref453;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var asm = Assembly.GetExecutingAssembly();
        dynamic? obj = asm.CreateInstance("ref453.Sample");
        if ( obj != null)
        {
            // �v���p�e�B��ݒ�
            obj.Id = 100;
            obj.Name = "���c�q��";
            obj.Address = "�����s����";
            // ���\�b�h�̌Ăяo��
            textBox1.Text = obj.ShowData() as string; 
        } 
        else
        {
            textBox1.Text = "�C���X�^���X�𐶐��ł��܂���";
        }
    }
}
public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
}

