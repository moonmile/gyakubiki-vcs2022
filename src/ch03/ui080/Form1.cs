using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui080
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var dir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var dirinfo = new DirectoryInfo(dir);
            var files = dirinfo.GetFiles("*.jpg");
            this.imageList1.Images.Clear();
            this.listView1.Items.Clear();
            this.listView1.View = View.LargeIcon;
            int i = 0;
            foreach (var file in files )
            {
                var image = Bitmap.FromFile( file.FullName);
                imageList1.Images.Add(image);
                listView1.Items.Add(file.Name,i++);
            }
        }
    }
}
