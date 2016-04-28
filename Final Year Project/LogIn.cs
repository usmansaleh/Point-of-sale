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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {


                    //string connetionString = "datasource=localhost;port=3306;username=root;password=root";


                    MySqlConnection con = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=root");
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from hussain.signup where Name='" + textBox1.Text + "' and signupPass='" + textBox2.Text + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        Main frm = new Main();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials, Please Re-Enter");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Recovery_Form frm = new Recovery_Form();
            frm.Show();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
