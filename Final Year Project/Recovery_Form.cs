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
    public partial class Recovery_Form : Form
    {
        public Recovery_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from hussain.signup WHERE signupEmail ='" + textBox1.Text + "'";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr.GetValue(1).ToString();
                        textBox3.Text = dr.GetValue(2).ToString();
                        //textBox4.Text = dr.GetValue(3).ToString();
                        //textBox5.Text = dr.GetValue(4).ToString();
                        //textBox6.Text = dr.GetValue(5).ToString();
                        ////textBox7.Text = dr.GetValue(1).ToString();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
