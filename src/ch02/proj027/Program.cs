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
    // �t�H�[�����J���O�Ɏ��s���鏈��
    MessageBox.Show("�t�H�[�����J���O�̏����ł�");
    // �t�H�[����\������
    Application.Run(new Form1());
}    
}