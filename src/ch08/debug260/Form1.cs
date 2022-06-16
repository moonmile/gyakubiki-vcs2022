namespace debug260;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        int sum = 0;
        for (int i = 0; i < 100; i++)
        {
            if (i % 3 == 0)
            {
                // 3の倍数のときに加算する
                sum += i;
#if DEBUG
                // デバッグ時に途中経過を表示する
                System.Diagnostics.Debug.WriteLine($"経過 {sum}");
#endif

            }
        }
        MessageBox.Show($"合計値: {sum}");

    }
}
