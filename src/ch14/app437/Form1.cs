namespace app437;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // 画像形式でペーストする
        if ( Clipboard.ContainsImage() )
        {
            var image = Clipboard.GetImage();
            pictureBox1.Image = image;
        }
    }
}
