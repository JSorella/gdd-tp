using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ofr = new Form2();
            ofr.MdiParent = this;
            ofr.Show();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 ofr = new Form3();
            ofr.MdiParent = this;
            ofr.Show();
        }


    }
}
