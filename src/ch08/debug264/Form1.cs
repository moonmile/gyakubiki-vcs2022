using System.Diagnostics;

namespace debug264;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var listener = new TextWriterTraceListener("trace.txt");
        Trace.Listeners.Add(listener);
        Trace.AutoFlush = true;
        for (int i = 0; i < 10; i++)
        {
            Trace.WriteLine($"�v�Z: {i * 2}");
        }
        MessageBox.Show("�g���[�X���ʂ��t�@�C���ɏo�͂��܂���");
    }
}
