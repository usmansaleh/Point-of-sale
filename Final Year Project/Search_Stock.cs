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
    public partial class Search_Stock : Form
    {
        public Search_Stock()
        {
            InitializeComponent();
        }

        void count()
        {
            int val = 0;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                val += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                this.textBox2.Text = val.ToString();
            }

        }

        public void Update1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";

                string sql = "SELECT *from hussain.stock where Pname like '" + textBox1.Text + "%' order by Pname";
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

        public void upda1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";
                string sql = "SELECT * FROM hussain.stock ";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                upda1();
            }
            else
            {
                Update1();
            }
        }

        private void Search_Stock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'husainTradesDataSet.Stock' table. You can move, or remove it, as needed.
           // this.stockTableAdapter.Fill(this.husainTradesDataSet.Stock); upda1();
            upda1();
            count();
        }

        private void Search_Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            upda1();
                
        }
    }
}
