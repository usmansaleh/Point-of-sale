using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Final_Year_Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Cus_upda1();
        }

        public void Cus_Update1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";


                string sql = "SELECT *  from hussain.customer where CustomerName like '" + textBox2.Text + "%' order by CustomerName";
                MySqlConnection connection = new MySqlConnection(connetionString);
                MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Stock");
                connection.Close();
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Stock";
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
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Stock";
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



       

        public void Update1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";

                string sql = "SELECT *  from hussain.stock where Pname like '" + textBox1.Text + "%' order by Pname";
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
  

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Today.ToString("dd-MM-yyyy");
            
            // TODO: This line of code loads data into the 'husainTradesDataSet.Customer' table. You can move, or remove it, as needed.
          //  this.customerTableAdapter.Fill(this.husainTradesDataSet.Customer);
            // TODO: This line of code loads data into the 'husainTradesDataSet.Stock' table. You can move, or remove it, as needed.
          //  this.stockTableAdapter.Fill(this.husainTradesDataSet.Stock);
            upda1();
            

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                Cus_upda1();
            }
            else
            {
                Cus_Update1();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sale frm = new Sale();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        //    DateTime dt = new DateTime();
        //    textBox4.Text = dt.ToString();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void wordPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm frm = new CustomerForm();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Stock frm = new Search_Stock();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            New_Stock frm = new New_Stock();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp frm = new SignUp();
            frm.Show();
        }

        private void saleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History hr = new History();
            hr.Show();
        }

        private void contectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contect frm = new Contect();
            frm.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
