namespace Final_Year_Project
{
    partial class Print_Invoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HusainTradesDataSet = new Final_Year_Project.HusainTradesDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InvoiceTableAdapter = new Final_Year_Project.HusainTradesDataSetTableAdapters.InvoiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HusainTradesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // InvoiceBindingSource
            // 
            this.InvoiceBindingSource.DataMember = "Invoice";
            this.InvoiceBindingSource.DataSource = this.HusainTradesDataSet;
            // 
            // HusainTradesDataSet
            // 
            this.HusainTradesDataSet.DataSetName = "HusainTradesDataSet";
            this.HusainTradesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.InvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Final_Year_Project.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(729, 435);
            this.reportViewer1.TabIndex = 0;
            // 
            // InvoiceTableAdapter
            // 
            this.InvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // Print_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 459);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Print_Invoice";
            this.Text = "Print_Invoice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Print_Invoice_FormClosing);
            this.Load += new System.EventHandler(this.Print_Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HusainTradesDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InvoiceBindingSource;
        private HusainTradesDataSet HusainTradesDataSet;
        private HusainTradesDataSetTableAdapters.InvoiceTableAdapter InvoiceTableAdapter;

    }
}