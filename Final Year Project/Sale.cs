using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Final_Year_Project
{
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
            
        }
        public void Update1()
        {
            try
            {

                
                
                string connetionString = "datasource=localhost;port=3306;username=root;password=root";

                string sql = "SELECT *  from hussain.stock where Pname like '" + textBox8.Text + "%' order by Pname";
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

                string sql = "SELECT *FROM hussain.stock ";
                MySqlConnection connection = new MySqlConnection(connetionString);
                MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "stock");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "stock";

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader rdr;
        String cs;
        void UpQtn()
        {
            try{
            for (int i = 0; i <= ListView1.Items.Count - 1; i++)
            {
       
                OleDbConnection con = new OleDbConnection();
                string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\DatabaseFolder\HusainTrades.mdb";
                OleDbCommand cmd;
                    con = new OleDbConnection(cs);
                    string cd = "update Stock set Quantity = (Quantity) - '" + ListView1.Items[i].SubItems[5].Text + "' where ID1= ' + ListView1.Items[i].SubItems[6].Text + '";
                    cmd = new OleDbCommand(cd);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                 
            }

                
                    MessageBox.Show("updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        
        }

        private void auto()
        {
            textBox2.Text = GetUniqueKey(8);

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

        public double subtot()
        {

            int i = 0;
            int j = 0;
            int k = 0;

            try
            {
                j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(ListView1.Items[i].SubItems[6].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }

        void Reset()
        {
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            txtPrice.Text = "";
            txtAvailableQty.Text = "";
            txtSaleQty.Text = "";
            txtTotalAmount.Text = "";
            textBox5.Text = "";
            ListView1.Clear();

        }

        public void Print_()
        {            
               
            try
            {

                OleDbConnection con = new OleDbConnection();
                string cs = global::Final_Year_Project.Properties.Settings.Default.HusainTradesConnectionString;
                //Invientory.Properties.Settings.Default.inventoryConnectionString;
                OleDbCommand cmd;
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    con = new OleDbConnection(cs);
                    string cd = "Insert Into Invoice([Date],[Customer],[ProductName],[Quantity],[Size_],[Price],[TotalPrice],[SubTotal],[Discount],[GrandTotal],[ProductId],[InvoiceNumber]) VALUES ('" + textBox3.Text + "','" + txtCustomerName.Text + "','" + ListView1.Items[i].SubItems[2].Text + "','" + ListView1.Items[i].SubItems[5].Text + "','" + ListView1.Items[i].SubItems[3].Text + "','" + ListView1.Items[i].SubItems[4].Text + "','" + ListView1.Items[i].SubItems[6].Text + "','" + txtSubTotal.Text + "','" + txtTaxPer.Text + "','" + txtTotal.Text + "','" + ListView1.Items[i].SubItems[1].Text + "','" + textBox2.Text + "')";
                    cmd = new OleDbCommand(cd);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //try
                   

                }
                //    MessageBox.Show("Now go for Print");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Reset();
                
        }
        void history()
        {
            try
            {

                MySqlConnection con = new MySqlConnection();
                string cs = "datasource=localhost;port=3306;username=root;password=root";
                //Invientory.Properties.Settings.Default.inventoryConnectionString;
                MySqlCommand cmd;
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    con = new MySqlConnection(cs);
                    string cd = "Insert Into hussain.history(InvoiceNumber_,Customer_,ProductName_,Quantity_,Size_,Price_,TotalPrice_,Discount_,GrandTotal_,Date_,ProductId_) VALUES ('" + textBox2.Text + "','" + txtCustomerName.Text + "','" + ListView1.Items[i].SubItems[2].Text + "','" + ListView1.Items[i].SubItems[5].Text + "','" + ListView1.Items[i].SubItems[3].Text + "','" + ListView1.Items[i].SubItems[4].Text + "','" + ListView1.Items[i].SubItems[6].Text + "','" + txtSubTotal.Text + "','" + txtTaxPer.Text + "','" + txtTotal.Text + "','" + ListView1.Items[i].SubItems[1].Text + "')";
                    cmd = new MySqlCommand(cd);  //'" + textBox2.Text + "','" + txtCustomerName.Text + "','" + ListView1.Items[i].SubItems[2].Text + "','" + ListView1.Items[i].SubItems[5].Text + "','" + ListView1.Items[i].SubItems[3].Text + "','" + ListView1.Items[i].SubItems[4].Text + "','" + ListView1.Items[i].SubItems[6].Text + "','" + txtSubTotal.Text + "','" + txtTaxPer.Text + "','" + txtTotal.Text + "','" + ListView1.Items[i].SubItems[1].Text + "','" + textBox2.Text + "'
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //try


                }
                //    MessageBox.Show("Now go for Print");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }




        private void Sale_Load(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Today.ToString("dd-MM-yyyy");
            // TODO: This line of code loads data into the 'husainTradesDataSet.Stock' table. You can move, or remove it, as needed.
           // this.stockTableAdapter.Fill(this.husainTradesDataSet.Stock);
            auto();
            upda1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;
                // comboBox3.Items.Clear();
                // comboBox3.Text = "";
                // comboBox2.Items.Clear();
                // comboBox2.Text = "";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from hussain.history WHERE InvoiceNumber_ ='" + textBox2.Text + "'";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        txtCustomerName.Text = dr.GetValue(2).ToString();   //price
                        textBox3.Text = dr.GetValue(10).ToString();   //Aval Quat.
                        txtSubTotal.Text = dr.GetValue(7).ToString();   //Aval Quat.

                        //   comboBox2.Text = dr.GetValue(6).ToString();
                        txtTotal.Text = dr.GetString(9);
                        // string product = dr.GetValue(2).ToString();
                        //string Product = dr.GetValue(2).ToString();
                        //ListView1.Items.Add(product);

                        ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                        lv.SubItems.Add(dr.GetString(12));
                        lv.SubItems.Add(dr.GetString(2));
                        lv.SubItems.Add(dr.GetString(3));
                        lv.SubItems.Add(dr.GetString(4));
                        lv.SubItems.Add(dr.GetString(5));
                        lv.SubItems.Add(dr.GetString(6));

                        ListView1.Items.Add(lv);

                        //  comboBox3.Items.Add(Dealer);
                        //textBox7.Text = dr.GetValue(1).ToString();


                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Print_();
            Print_Invoice frm = new Print_Invoice();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customre_Record frm = new Customre_Record();
            frm.label1.Text = label6.Text;
            frm.Visible = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            if (txtSaleQty.Text == "")
            {
                MessageBox.Show("Plese give sale quantity", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSaleQty.Focus();
                return;
            }

            if (txtSaleQty.Text == "0")
            {
                MessageBox.Show("no. of sale quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSaleQty.Focus();
                return;
            }

            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Customer Name is Missing", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return;
            }

            else
            {
                try
                {
             //       UpQtn();
                    txtTotalAmount.Text = (double.Parse(txtSaleQty.Text) * double.Parse(textBox7.Text)).ToString();
                    txtSubTotal.Text = txtTotalAmount.Text;
                    if (ListView1.Items.Count == 0)
                    {

                        ListViewItem lst = new ListViewItem();
                        lst.SubItems.Add(textBox5.Text);
                        //  lst.SubItems.Add(textBox5.Text);

                        lst.SubItems.Add(comboBox1.Text);
                        lst.SubItems.Add(comboBox2.Text);
                        lst.SubItems.Add(txtPrice.Text);
                        lst.SubItems.Add(txtSaleQty.Text);
                        //            lst.SubItems.Add(textBox5.Text);

                        lst.SubItems.Add(txtTotalAmount.Text);
                        ListView1.Items.Add(lst);
                        //Reset();
                        return;

                    }

                    for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    {
                        if (ListView1.Items[j].SubItems[0].Text == textBox5.Text)
                        {
                            ListView1.Items[j].SubItems[0].Text = comboBox1.Text;
                            ListView1.Items[j].SubItems[1].Text = comboBox2.Text;
                            ListView1.Items[j].SubItems[2].Text = txtPrice.Text; //unit Price
                            //listView1.Items[j].SubItems[3].Text = textBox7.Text;
                            ListView1.Items[j].SubItems[3].Text = txtSaleQty.Text;
                            ListView1.Items[j].SubItems[4].Text = txtTotalAmount.Text;//total Amount

                            return;
                        }
                    }

                    ListViewItem lst1 = new ListViewItem();

                    lst1.SubItems.Add(textBox5.Text);
                    lst1.SubItems.Add(comboBox1.Text);
                    lst1.SubItems.Add(comboBox2.Text);
                    lst1.SubItems.Add(txtPrice.Text);
                    lst1.SubItems.Add(txtSaleQty.Text);
                    lst1.SubItems.Add(txtTotalAmount.Text);
                    ListView1.Items.Add(lst1);
                

                    //for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    //{
                    //    if (ListView1.Items[j].SubItems[1].Text == txtConfigID.Text)
                    //    {
                    //        ListView1.Items[j].SubItems[1].Text = comboBox1.Text;
                    //        ListView1.Items[j].SubItems[2].Text = comboBox2.Text;
                    //        ListView1.Items[j].SubItems[3].Text = txtPrice.Text;
                    //        ListView1.Items[j].SubItems[4].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[4].Text) + Convert.ToInt32(txtSaleQty.Text)).ToString();
                    //        ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(txtTotalAmount.Text)).ToString();
                    //        txtSubTotal.Text = subtot().ToString();
                    //        comboBox1.Text = "";
                    //        comboBox2.Text = "";
                    //        txtPrice.Text = "";
                    //        txtAvailableQty.Text = "";
                    //        txtSaleQty.Text = "";
                    //        txtTotalAmount.Text = "";

                    //        return;


                    //    }
                    //}

                   // Reset();
                    double value = 0;
                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                    {
                        value = value + Convert.ToDouble(ListView1.Items[i].SubItems[6].Text);
                        txtSubTotal.Text = Convert.ToString(value);
                    }


                    return;

                }





                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
        int val=0, total=0;
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "")
                {
                    textBox6.Focus();
                }
                else
                {

                    val = Convert.ToInt32(txtPrice.Text);
                    total = Convert.ToInt32(textBox6.Text);
                    total = (val * total / 100);
                    total = (val) - (total);
                    int a = total;
                    textBox7.Text = Convert.ToString(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTaxPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTaxPer.Text))
                {
                    txtTaxAmt.Text = "";
                    txtTotal.Text = "";
                    return;
                }
                txtTaxAmt.Text = Convert.ToInt32((Convert.ToInt32(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();
                txtTotal.Text = (Convert.ToInt32(txtSubTotal.Text) - Convert.ToInt32(txtTaxAmt.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {

                //int val = 0;

                //for (int i = 1; i <= ListView1.Items.Count - 1; i++)
                //{
                //    val = val + Convert.ToInt32(ListView1.Items[i].SubItems[5].Text);
                //    txtSubTotal.Text = Convert.ToString(val);
                //}

                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    ListView1.FocusedItem.Remove();
                    itmCnt = ListView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;
                        //      val = 0;


                    }
                    //val = 0;
                    //for (i = 1; i <= ListView1.Items.Count - 1; i++)
                    //{
                    //    val = val + Convert.ToInt32(ListView1.Items[i].SubItems[5].Text);
                    //    txtSubTotal.Text = Convert.ToString(val);
                    //}

                    txtSubTotal.Text = subtot().ToString();
                }


                if (ListView1.Items.Count == 0)
                {
                    btnRemove.Enabled = false;
                    txtSubTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtTotal.Text, out val1);
            int.TryParse(txtTotalPayment.Text, out val2);
            int I = (val1 - val2);
            txtPaymentDue.Text = I.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" && txtSubTotal.Text == "")
            {
                MessageBox.Show("No Input", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
            }

            else
            {
               // UpQtn();
                Print_();
                history();
                Print_Invoice fem = new Print_Invoice();
                fem.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void txtSaleQty_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtAvailableQty.Text, out val1);
            int.TryParse(txtSaleQty.Text, out val2);
            if (val2 > val1)
            {
                MessageBox.Show("Selling quantities are more than available quantities", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSaleQty.Text = "";
                txtTotalAmount.Text = "";
                txtSaleQty.Focus();
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            History hr = new History();
            hr.Show();
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                comboBox1.Text = dr.Cells[1].Value.ToString();
                comboBox3.Text = dr.Cells[2].Value.ToString();
                comboBox2.Text = dr.Cells[4].Value.ToString();
                textBox5.Text = dr.Cells[0].Value.ToString();
                txtPrice.Text = dr.Cells[8].Value.ToString();
                txtAvailableQty.Text = dr.Cells[3].Value.ToString();
                textBox6.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
