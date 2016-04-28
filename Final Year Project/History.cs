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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }


        public void upda1()
        {
            try
            {

                string connetionString = "datasource=localhost;port=3306;username=root;password=root";

                string sql = "SELECT * FROM hussain.history ";
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

        private void History_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'husainTradesDataSet.History' table. You can move, or remove it, as needed.
            //this.historyTableAdapter.Fill(this.husainTradesDataSet.History);
            upda1();


        }
    }
}
