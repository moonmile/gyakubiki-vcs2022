namespace debug261;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
#if DEBUG
        MessageBox.Show("DEBUG���[�h�Ńr���h");
#else
        MessageBox.Show("RELEASE���[�h�Ńr���h");
#endif
    }
}
