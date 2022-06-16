namespace app433;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
        this.FormClosed += Form1_FormClosed;
    }


    private System.Threading.Mutex objMutex;

    private void Form1_Load(object? sender, EventArgs e)
    {
        objMutex = new System.Threading.Mutex(false, "app433");
        if (objMutex.WaitOne(0, false) == false )
        {
            MessageBox.Show("既にアプリケーションが起動しています");
            this.Close();
        }

    }

    private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
    {
        // フォームを閉じるときにミューテックスを解放する
        objMutex.Close();
    }
}
