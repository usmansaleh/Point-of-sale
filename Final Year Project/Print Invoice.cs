using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Year_Project
{
    public partial class Print_Invoice : Form
    {
        public Print_Invoice()
        {
            InitializeComponent();
        }

        void delete()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = global ::Final_Year_Project.Properties.Settings.Default.HusainTradesConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            conn.Open();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete *from Invoice";
            cmd.ExecuteNonQuery();
            conn.Close();


        }




        private void Print_Invoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'HusainTradesDataSet.Invoice' table. You can move, or remove it, as needed.
            this.InvoiceTableAdapter.Fill(this.HusainTradesDataSet.Invoice);

            this.reportViewer1.RefreshReport();
           // this.reportViewer2.RefreshReport();
        }

        private void Print_Invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            delete();
        }
    }
}
