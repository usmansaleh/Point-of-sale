using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Final_Year_Project
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
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



        private void CustomerForm_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            textBox1.Text = GetUniqueKey(4);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please enter name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }


            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please enter mobile no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
                return;
            }

            try
            {
                //     auto();
                //con = new MySqlConnection(cs);
                //con.Open();
                //string ct = "select CustomerID from Customer where CustomerID=@find";

                //cmd = new MySqlCommand(ct);
                //cmd.Connection = con;
                //cmd.Parameters.Add(new MySqlParameter("@find", System.Data.MySql.MySqlType.VarChar, 20, "CustomerID"));
                //cmd.Parameters["@find"].Value = txtCustomerID.Text;
                //rdr = cmd.ExecuteReader();

                //if (rdr.Read())
                //{
                //    MessageBox.Show("Customer ID Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    if ((rdr != null))
                //    {
                //        rdr.Close();
                //    }


                //}
                //else
                //{

                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;
                String cs = "datasource=localhost;port=3306;username=root;password=root";
                con = new MySqlConnection(cs);
                con.Open();

                string cb = "insert into hussain.Customer(idcustomer,CustomerName,Address,Cnic,MobPh,Phone,Debit,Date) VALUES ('" + textBox1.Text + "','" + txtCustomerName.Text + "','" + txtAddress.Text + "','" + txtCnic.Text + "','" + txtPhone.Text + "','" + txtMobileNo.Text + "','" + txtDebit.Text + "','" + txtDate.Text + "')";

                cmd = new MySqlCommand(cb);

                cmd.Connection = con;

                //cmd.Parameters.Add(new MySqlParameter("@d1", System.Data.MySql.MySqlType.VarChar, 20, "CustomerID"));
                // cmd.Parameters.Add(new MySqlParameter("@d2", System.Data.MySql.MySqlType.VarChar, 100, "Name"));
                // cmd.Parameters.Add(new MySqlParameter("@d4", System.Data.MySql.MySqlType.VarChar, 250, "Address"));
                // cmd.Parameters.Add(new MySqlParameter("@d5", System.Data.MySql.MySqlType.VarChar, 13, "Cnic"));

                // cmd.Parameters.Add(new MySqlParameter("@d6", System.Data.MySql.MySqlType.VarChar, 50, "OfficePh"));

                // cmd.Parameters.Add(new MySqlParameter("@d7", System.Data.MySql.MySqlType.VarChar, 50, "MobPh"));

                // cmd.Parameters.Add(new MySqlParameter("@d8", System.Data.MySql.MySqlType.VarChar, 10, "Debit"));

                // cmd.Parameters.Add(new MySqlParameter("@d9", System.Data.MySql.MySqlType.VarChar, 15, "Date"));


                //// cmd.Parameters["@d1"].Value = txtCustomerID.Text;
                // cmd.Parameters["@d2"].Value = txtCustomerName.Text;
                // cmd.Parameters["@d4"].Value = txtAddress.Text;
                // cmd.Parameters["@d5"].Value = txtCnic.Text;
                // cmd.Parameters["@d6"].Value = txtPhone.Text;
                // cmd.Parameters["@d7"].Value = txtMobileNo.Text;
                // cmd.Parameters["@d8"].Value = txtDebit.Text;
                // cmd.Parameters["@d9"].Value = txtDate.Text;


                cmd.ExecuteReader();
                MessageBox.Show("Successfully saved", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Close();

                textBox1.Text = GetUniqueKey(4);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtDebit.Text, out val1);
            int.TryParse(txtTotal.Text, out val2);
            int I = (val1 - val2);
            txtRemain.Text = I.ToString();
            if (txtRemain.Text != "")
            {
                btnUpdate.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                //conn.ConnectionString = @"Provider=Microsoft.Jet.MySql.4.0;Data Source=C:\DatabaseFolder\HusainTrades.mdb";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
 
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from hussain.customer WHERE MobPh = '" + txtCustomerID.Text + "'";
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        // MessageBox.Show("it's ok");
                        txtCustomerName.Text = dr.GetValue(1).ToString();
                        txtAddress.Text = dr.GetValue(2).ToString();
                        txtCnic.Text = dr.GetValue(3).ToString();
                        txtPhone.Text = dr.GetValue(4).ToString();
                        txtMobileNo.Text = dr.GetValue(5).ToString();
                        txtDebit.Text = dr.GetValue(6).ToString();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Customre_Record frm = new Customre_Record();
            frm.Show();
        }

        private void CustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            frm.Show();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;
                String cs = "datasource=localhost;port=3306;username=root;password=root";
                con = new MySqlConnection(cs);
                con.Open();

                string cb = "update hussain.customer set CustomerName = '" + txtCustomerName.Text + "',Address= '" + txtAddress.Text + "',Cnic= '" + txtCnic.Text + "',Phone= '" + txtPhone.Text + "',MobPh= '" + txtMobileNo.Text + "',Debit= '" + txtRemain.Text + "' where MobPh= '" + txtCustomerID.Text + "'";
                cmd = new MySqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MySqlDataReader rdr = null;
                    MySqlConnection con = null;
                    MySqlCommand cmd = null;
                    String cs = "datasource=localhost;port=3306;username=root;password=root";
                    con = new MySqlConnection(cs);
                    con.Open();

                    string cb = "Delete from hussain.customer where MobPh= '" + txtCustomerID.Text + "'";
                    cmd = new MySqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    MessageBox.Show("Delete Succesfuly", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnUpdate.Enabled = false;
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Close();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = GetUniqueKey(4);
            txtAddress.Text = "";
            //txtCity.Text = "";
            // txtEmail.Text = "";
            // txtFaxNo.Text = "";
            txtCustomerName.Text = "";
            txtCnic.Text = "";
            txtMobileNo.Text = "";
            txtDebit.Text = "";
            txtPhone.Text = "";
            txtCustomerID.Text = "";
            txtTotal.Text = "";
            txtRemain.Text = "";
            // txtZipCode.Text = "";
            // cmbState.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtCustomerName.Focus();
        }
    }
}
