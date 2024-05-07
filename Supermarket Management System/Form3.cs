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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nesit\Desktop\project\Supermarket Management System\Supermarket Management System\Database1.mdf;Integrated Security=True");

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string ProdID = textBox1.Text;
            string ProdName = textBox2.Text;
            string ProdQTY = textBox3.Text;
            string ProdPrice = textBox4.Text;
            string ProdCAT = comboBox1.Text;
            


            string sqlinsert = "INSERT INTO Product (ProdID,ProdName,ProdPrice,ProdQTY,ProdCAT) VALUES('" + ProdID + "', '" + ProdName + "','" + ProdPrice + "','"+ ProdQTY +"' , '"+ProdCAT+"')";
            SqlCommand cmd = new SqlCommand(sqlinsert, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string ProdID = textBox1.Text;
            string ProdName = textBox2.Text;
            string ProdQTY = textBox3.Text;
            string ProdPrice = textBox4.Text;
            string ProdCAT = comboBox1.Text;

            string sql_update = "UPDATE Product SET ProdName = '" + ProdName + "' , ProdQTY = '" + ProdQTY + "' , ProdPrice = '"+ProdPrice+"' ,ProdCAT = '"+ProdCAT+"' WHERE ProdID = '" + ProdID + "'";

            SqlCommand cmd = new SqlCommand(sql_update, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Updated Successfully");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            string ProdID = textBox1.Text;

            string sql_delete = "DELETE FROM Product WHERE ProdID = '" + ProdID + "'";

            SqlCommand cmd = new SqlCommand(sql_delete, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted Successfully");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter data = new SqlDataAdapter(@"SELECT * FROM Product", con);
            DataTable t = new DataTable();
            dataGridView1.DataSource = t;
            data.Fill(t);
            con.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select CATName from Category";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["CATName"].ToString());
            }
            con.Close();
        }        
    }
}
