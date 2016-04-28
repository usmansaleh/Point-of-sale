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
using System.Security.Cryptography;
namespace Final_Year_Project
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter User Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Email Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //try
                //{
                //    OleDbConnection conn = new OleDbConnection();
                //    conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\DatabaseFolder\HusainTrades.mdb";
                //    OleDbCommand cmd = new OleDbCommand();
                //    conn.Open();
                //    cmd.Connection = conn;

                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = "INSERT into Login ([Name], [Password],[Email]) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                //    cmd.ExecuteNonQuery();
                //    conn.Close();
                //    MessageBox.Show("User has been created");
                //    textBox1.Text = "";
                //    textBox2.Text = "";
                //    textBox3.Text = "";
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}


                string constring = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "insert into hussain.signup(Name,signupPass,signupEmail) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "'); ";
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader myreader;
                try
                {
                    con.Open();
                    //cmd.Parameters.Add(new MySqlParameter("@IMG", imagebt));
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("Save");
                    while (myreader.Read())
                    { }

                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    textBox4.Text = GetUniqueKey(4);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }















            }
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            frm.Show();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            //textBox4.Text = GetUniqueKey(4);
        }
    }
}
