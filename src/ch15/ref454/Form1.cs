namespace ref454;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // ���炩���� dll ���R�s�[���Ă���
        var asm = System.Reflection.Assembly.LoadFrom("ref454Lib.dll");
        dynamic? obj = asm.CreateInstance("ref454Lib.Sample");
        if (obj != null)
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
