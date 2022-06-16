namespace ui074
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LeftToolStripMenuItem,
            this.CenterToolStripMenuItem,
            this.RightToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 100);
            // 
            // LeftToolStripMenuItem
            // 
            this.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem";
            this.LeftToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
            this.LeftToolStripMenuItem.Text = "左揃え";
            this.LeftToolStripMenuItem.Click += new System.EventHandler(this.LeftToolStripMenuItem_Click);
            // 
            // CenterToolStripMenuItem
            // 
            this.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem";
            this.CenterToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
            this.CenterToolStripMenuItem.Text = "中央揃え";
            this.CenterToolStripMenuItem.Click += new System.EventHandler(this.CenterToolStripMenuItem_Click);
            // 
            // RightToolStripMenuItem
            // 
            this.RightToolStripMenuItem.Name = "RightToolStripMenuItem";
            this.RightToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
            this.RightToolStripMenuItem.Text = "右揃え";
            this.RightToolStripMenuItem.Click += new System.EventHandler(this.RightToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(12, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 50);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Visual Studio 2022";
            // 
            // textBox2
            // 
            this.textBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox2.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(12, 204);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(354, 50);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "逆引き大全";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "右クリックでコンテキストメニューを表示";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RightToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
    }
}

