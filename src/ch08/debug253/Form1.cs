namespace debug253;

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
                // 3�̔{���̂Ƃ��ɉ��Z����
                sum += i;
            }
        }
        MessageBox.Show($"���v�l: {sum}");
    }
}
