using System.Xml.Linq;

namespace debug257;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var pa = new Person
        {
            Name = "マスダトモアキ",
            Age = 50,
            Address = "東京都板橋区"
        };

        var xml = new XElement(
            "person",
            new XElement("Name", "増田智明"),
            new XElement("Age", "50"),
            new XElement("Address", "板橋区"));

        textBox1.Text = xml.ToString();
    }
}

public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Address { get; set; } = "";
}


