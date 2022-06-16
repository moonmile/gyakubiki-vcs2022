namespace proj027;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
[STAThread]
static void Main()
{
    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    // フォームを開く前に実行する処理
    MessageBox.Show("フォームを開く前の処理です");
    // フォームを表示する
    Application.Run(new Form1());
}    
}