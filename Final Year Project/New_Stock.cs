using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Final_Year_Project
{
    public partial class New_Stock : Form
    {
        
        public New_Stock()
        {
            InitializeComponent();
        }

        void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            //textBox6.Text = "";
            comboBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
           

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

        public void Update1()
        {
            try
            {
                string connetionString = "datasource=localhost;port=3306;username=root;password=root";

                string sql = "SELECT *  from hussain.stock where Pname like '" + textBox8.Text + "%' order by Pname";
                MySqlConnection connection = new MySqlConnection(connetionString);
                MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
                
                //string connetionString = @"Provider=Microsoft.Jet.MySql.4.0;Data Source=C:\DatabaseFolder\HusainTrades.mdb";

                
                //MySqlConnection connection = new MySqlConnection(connetionString);
                //MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
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




        int val;
        int total;

        public void Check()
        {
            try
            {
                comboBox1.Items.Clear();
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString ="datasource=localhost;port=3306;username=root;password=root";
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from hussain.stock WHERE PName ='" + textBox1.Text + "'";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                       // textBox9.Text = dr.GetString(6);
                        textBox9.Text = dr.GetString(0);
                        textBox2.Text = dr.GetString(2);
                        textBox3.Text = dr.GetString(3);
                        textBox6.Text = dr.GetString(7);
                        textBox4.Text = dr.GetString(4);
                        string size = dr.GetString(6);

                        comboBox1.Items.Add(size);
                        textBox7.Text = dr.GetString(8);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }










        void FillCombo()
        {

            comboBox1.Items.Add("10 ml");
            comboBox1.Items.Add("25 ml");
            comboBox1.Items.Add("50 ml");
            comboBox1.Items.Add("75 ml");
            comboBox1.Items.Add("100 ml");
            comboBox1.Items.Add("150 ml");
            comboBox1.Items.Add("250 ml");
            comboBox1.Items.Add("300 ml");

            comboBox1.Items.Add("500 ml");
            comboBox1.Items.Add("600 ml");

            comboBox1.Items.Add("1000 ml");

        }



        public void EnterStock()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Product Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Company Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {



                //MySqlConnection conn = new MySqlConnection();

                //conn.ConnectionString = @"Provider=Microsoft.Jet.MySql.4.0;Data Source=C:\DatabaseFolder\HusainTrades.mdb";
                //MySqlCommand cmd = new MySqlCommand();
                //conn.Open();
                //cmd.Connection = conn;

                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "INSERT into Stock ([ID1],[Pname], [Dname],[Price],[Quantity],[size_] ,[Date],[Percent_],[SalePrice]) Values ('" + textBox9.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //MessageBox.Show("Data Entered");

                string constring = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "insert into hussain.stock(idstock,Pname,Dname,Price,Quantity,Psize,Date,Ppercent,SalePrice) values ('" + textBox9.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";
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

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    FillCombo();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }









        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void New_Stock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'husainTradesDataSet.Stock' table. You can move, or remove it, as needed.
           // this.stockTableAdapter.Fill(this.husainTradesDataSet.Stock);
            textBox5.Text = DateTime.Today.ToString("dd-MM-yyyy");
            FillCombo();
            upda1();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EnterStock();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Please Entet Product Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                comboBox1.Text = "";
                Check();
            }
        }
        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox6.Text == "")
            {
                textBox7.Text = "";
                textBox6.Focus();
            }
            if (
                textBox3.Text != "" && textBox6.Text != "")
            {

                val = Convert.ToInt32(textBox3.Text);
                total = Convert.ToInt32(textBox6.Text);
                total = (val * total / 100);
                total = total + val;
                textBox7.Text = Convert.ToString(total);
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                upda1();
            }
            else
            {
                Update1();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Product Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Company Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //MySqlDataReader rdr = null;
                    MySqlConnection con = null;
                    MySqlCommand cmd = null;
                    String cs = "datasource=localhost;port=3306;username=root;password=root";
                    con = new MySqlConnection(cs);
                    con.Open();

                    string cb = "update hussain.stock Set Pname ='" + textBox1.Text + "',Dname ='" + textBox2.Text + "',Price= '" + textBox3.Text + "',Quantity= '" + textBox4.Text + "',PSize= '" + comboBox1.Text + "',Ppercent= '" + textBox6.Text + "',SalePrice='" + textBox7.Text + "' where idstock = '" + textBox9.Text + "'";
                    cmd = new MySqlCommand(cb);
                    cmd.Connection = con;
                    //  //,Price= '" + textBox3.Text + "',Quantity= '" + textBox4.Text + "',Size= '" + comboBox1.Text + "',Percent= '" + textBox6.Text + "',SalePrice='"+textBox7.Text+"'
                    cmd.ExecuteReader();
                    MessageBox.Show("Successfully updated", "Stock Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //   btnUpdate.Enabled = false;
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void New_Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            frm.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                textBox9.Text = dr.Cells[0].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                textBox2.Text = dr.Cells[2].Value.ToString();
                textBox3.Text = dr.Cells[3].Value.ToString();
                textBox4.Text = dr.Cells[4].Value.ToString();
                textBox6.Text = dr.Cells[7].Value.ToString();
                comboBox1.Text = dr.Cells[6].Value.ToString();
                textBox6.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox9.Text =  GetUniqueKey(8);
            Reset();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            upda1();
        }
    }
}
