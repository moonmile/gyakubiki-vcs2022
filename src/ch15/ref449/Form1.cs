using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ref449;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        // �v���p�e�B�̑������擾����
        foreach ( var  pi in typeof(Sample).GetProperties())
        {
            var attr = pi.GetCustomAttribute<DisplayNameAttribute>();
            listBox1.Items.Add($"{pi.Name} {attr?.DisplayName}");
        }
    }
}

[Table("�T���v���N���X")] 
public class Sample
{
    [Key]
    [DisplayName("���ʎq")] // �����̑������擾
    public int Id { get; set; }
    [DisplayName("���O")]
    public string Name { get; set; } = "";
    [DisplayName("�Z��")]
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

