using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui078
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ノードの取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = treeView1.SelectedNode.FullPath;
        }

        /// <summary>
        /// 子ノードを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            var node = treeView1.SelectedNode;
            if ( text != "" && node != null )
            {
                node.Nodes.Add(new TreeNode(text));
            }
        }

        /// <summary>
        /// 選択しているノードを削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if ( node != null )
            {
                node.Remove();
            }
        }
    }
}
