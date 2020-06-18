using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        DoubleHash h;

        public Form1()
        {
            InitializeComponent();
            h = new DoubleHash();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            h.insert(Convert.ToInt32(textBox1.Text));
            textBox1.Text = "";
            button2.Enabled = true;
            button1.Enabled = false;
            textBox1.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = h.get();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else {
                button1.Enabled = false;
            }
        }
    }
}
