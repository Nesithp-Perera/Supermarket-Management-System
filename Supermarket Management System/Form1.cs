using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "pass1")
            {
                MessageBox.Show("Login Success");
                Form2 fm = new Form2(textBox1.Text);
                fm.Show();
                this.Hide();
            }
            else if (textBox1.Text == "seller" && textBox2.Text == "pass2")
            {
                MessageBox.Show("Login Success");
                Form6 fm = new Form6();
                fm.Show();
                this.Hide();
            }
           else
            {
                MessageBox.Show("Login Fail");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}