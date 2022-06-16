using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
namespace ref448;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // �N���X�̑������擾����
        var attr = typeof(Sample).GetCustomAttribute<TableAttribute>();
        textBox1.Text = attr?.Name;
    }
}

[Table("�T���v���N���X")] // ���̑������擾
public class Sample
{
    [Key]
    [DisplayNameAttribute("���ʎq")]
    public int Id { get; set; }
    [DisplayNameAttribute("���O")]
    public string Name { get; set; } = "";
    [DisplayNameAttribute("�Z��")]
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
    public void ChangeAddress(string address)
    {
        this.Address = address;
    }
}



