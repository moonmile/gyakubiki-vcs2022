using System.Reflection;

namespace ref455;

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
        foreach (var pi in typeof(Sample).GetProperties())
        {
            var attr = pi.GetCustomAttribute<MyCustomAttribute>();
            listBox1.Items.Add($"{pi.Name} {attr?.Name} {attr?.Description}");
        }

    }
}

/// <summary>
/// �J�X�^������
/// </summary>
public class MyCustomAttribute : Attribute {
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
}


public class Sample
{
    [MyCustom(Name = "���ʎq", Description = "�I�u�W�F�N�g����ӂɎ��ʂ���")]
    public int Id { get; set; }
    [MyCustom(Name = "���O", Description = "���O����{��ŋL�q���܂�")]
    public string Name { get; set; } = "";
    [MyCustom(Name = "�Z��", Description = "�Z������{��ŋL�q���܂�")]
    public string Address { get; set; } = "";
    public string ShowData()
    {
        return $"{Id} : {Name} in {Address}";
    }
}

