using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Year_Project
{
    public partial class Customre_Record : Form
    {
        public Customre_Record()
        {
            InitializeComponent();
            Cus_upda1();
        }

        void count()
        {
            int val = 0;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                val += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                this.textBox1.Text = val.ToString();
            }

        }
        public void Cus_Update1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";
                string sql = "SELECT *  from hussain.customer where CustomerName like '" + txtCustomers.Text + "%' order by Name";
                MySqlConnection connection = new MySqlConnection(connetionString);
                MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Stock");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Stock";
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void Cus_upda1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";

                string sql = "SELECT * FROM hussain.customer ";
                MySqlConnection connection = new MySqlConnection(connetionString);
                MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Stock");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Stock";
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }











        private void Customre_Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'husainTradesDataSet.Customer' table. You can move, or remove it, as needed.
            //this.customerTableAdapter.Fill(this.husainTradesDataSet.Customer);
            count();
            Cus_upda1();

        }

        private void txtCustomers_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomers.Text == "")
            {
                Cus_upda1();
                //count();
            }
            else
            {
                Cus_Update1();
                //count();
            }
        }

        private void Customre_Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                Sale frm = new Sale();
                frm.Show();
                frm.textBox8.Text = dr.Cells[0].Value.ToString();
                frm.txtCustomerName.Text = dr.Cells[1].Value.ToString();
                frm.label6.Text = label1.Text;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
