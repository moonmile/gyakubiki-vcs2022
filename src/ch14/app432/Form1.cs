namespace app432;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var proc = new System.Diagnostics.Process();
        // ���������N������
        proc.StartInfo.FileName = "notepad.exe";
        // �A�v���P�[�V�����̏I����҂�
        proc.EnableRaisingEvents = true;
        proc.Exited += (_, _) =>
        {
            // �I���̃C�x���g���擾����
            MessageBox.Show("���������I�����܂���");
        };
        proc.Start();
    }
}
