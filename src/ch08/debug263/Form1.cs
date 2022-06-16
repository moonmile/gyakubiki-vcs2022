using System.Diagnostics;

namespace debug263;

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
        for (int i = 0; i < 10; i++)
        {
            Trace.WriteLine($"計算: {i * 2}");
        }
        Trace.Flush();
        MessageBox.Show("トレース結果をファイルに出力しました");
    }
}
