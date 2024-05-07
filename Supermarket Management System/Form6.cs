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
    public partial class Form6 : Form
    {

        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\nesit\Desktop\project\Supermarket Management System\Supermarket Management System\Database1.mdf;Integrated Security=True");

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
       
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getTable()
        {
            con.Open();
            string query = "SELECT ProdName,ProdPrice from Product";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
        }
        private void getTable2()
        {
            con.Open();
            string query = "SELECT *from Bill";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            getTable();
            getTable2();
           
            

            Date.Text = DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        int Grdtotal = 0, n = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (ProdName.Text == "" || ProdQTY.Text == "")
            {
                MessageBox.Show("Missing Data");  
            }
            else
            {
                int  total = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQTY.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ProdName.Text;
                newRow.Cells[2].Value = ProdPrice.Text;
                newRow.Cells[3].Value = ProdQTY.Text;
                newRow.Cells[4].Value = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQTY.Text);
                dataGridView1.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + total;
                label9.Text = "" + Grdtotal;
            }

       }

        private void button5_Click(object sender, EventArgs e)
        {
            if (BillID.Text == "")
            {
                MessageBox.Show("Missing Bill ID");
            }
            else
            {
                try
            {
                con.Open();
               


                string query = "INSERT INTO Bill VALUES('" + BillID.Text + "','" + Date.Text + "','"+label9.Text+"')";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved Successfully");
                con.Close();
                getTable2();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BillID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
             {
                printDocument1.Print();
             }
               
        }
    



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FAMILYSUPERMARKET", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID:" +dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100,70));
            e.Graphics.DrawString("Date:" +dataGridView2.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100,100));
            e.Graphics.DrawString("Total Amount:" +dataGridView2.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100,130));
            e.Graphics.DrawString("ANO PVT LTD", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.Red, new Point(230,230));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
              Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string BillId = BillID.Text;

            string sql_delete = "DELETE FROM Bill WHERE BillId = '" + BillId + "'";

            SqlCommand cmd = new SqlCommand(sql_delete, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted Successfully");
            con.Close();

          
        }

       

       
        }

      
        

  }



