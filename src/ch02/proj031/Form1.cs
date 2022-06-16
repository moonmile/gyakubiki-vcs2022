namespace proj031;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

private void button1_Click(object sender, EventArgs e)
{
    // リソースから文字列を表示
    this.label1.Text = Properties.Resources.subject;
    // リソースから画像を表示
    this.pictureBox1.Image = Properties.Resources.cock;
    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
}
}
