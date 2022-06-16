namespace ref441;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // �v���p�e�B�ꗗ���擾����
        var pis = typeof(Sample).GetProperties();
        listBox1.Items.Clear();
        foreach (var pi in pis)
        {
            listBox1.Items.Add($"{pi.Name} : {pi.PropertyType.ToString()}");
        }
    }
}


public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    /// <summary>
    /// �v���p�e�B�̒l��\������
    /// </summary>
    /// <returns></returns>
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
    /// <summary>
    /// �Z����ύX����
    /// </summary>
    /// <param name="address"></param>
    public void ChangeAddress( string address )
    {
        this.Address = address;
    }

}


