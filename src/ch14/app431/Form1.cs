namespace app431;

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
        proc.Start();
    }
}
