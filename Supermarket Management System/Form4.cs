using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Supermarket_Management_System
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nesit\Desktop\project\Supermarket Management System\Supermarket Management System\Database1.mdf;Integrated Security=True");
       
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string CATID = textBox1.Text;
            string CATName = textBox2.Text;
            string CATDES = textBox3.Text;



            string sqlinsert = "INSERT INTO Category (CATID,CATName,CATDES) VALUES('" + CATID + "', '" + CATName + "','" + CATDES + "')";
            SqlCommand cmd = new SqlCommand(sqlinsert, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string CATID = textBox1.Text;
            string CATName = textBox2.Text;
            string CATDES = textBox3.Text;
            

            string sql_update = "UPDATE Category SET CATName = '" + CATName + "' , CATDES = '" + CATDES + "' WHERE CATID = '"+CATID+"'";

            SqlCommand cmd = new SqlCommand(sql_update, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Updated Successfully");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            string CATID = textBox1.Text;

            string sql_delete = "DELETE FROM Category WHERE CATID = '" + CATID + "'";

            SqlCommand cmd = new SqlCommand(sql_delete, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted Successfully");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter data = new SqlDataAdapter(@"SELECT * FROM Category", con);
            DataTable t = new DataTable();
            dataGridView1.DataSource = t;
            data.Fill(t);
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
