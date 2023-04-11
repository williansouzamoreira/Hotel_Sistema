namespace Hotel_Sistema.Relatorios
{
    partial class FrmRelatorioVendas
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
            this.vendasPorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hotel_Sistema.hotelDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DtInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbStatus = new System.Windows.Forms.ComboBox();
            this.vendasPorDataTableAdapter = new Hotel_Sistema.hotelDataSetTableAdapters.VendasPorDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // vendasPorDataBindingSource
            // 
            this.vendasPorDataBindingSource.DataMember = "VendasPorData";
            this.vendasPorDataBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "hotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSVendas";
            reportDataSource1.Value = this.vendasPorDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hotel_Sistema.Relatorios.RelatorioVendas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 558);
            this.reportViewer1.TabIndex = 0;
            // 
            // DtInicial
            // 
            this.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicial.Location = new System.Drawing.Point(496, 17);
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.Size = new System.Drawing.Size(87, 20);
            this.DtInicial.TabIndex = 106;
            this.DtInicial.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtInicial.ValueChanged += new System.EventHandler(this.DtInicial_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 105;
            this.label4.Text = "Data Incial:";
            // 
            // DtFinal
            // 
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(702, 16);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(87, 20);
            this.DtFinal.TabIndex = 108;
            this.DtFinal.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtFinal.ValueChanged += new System.EventHandler(this.DtFinal_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Data Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Status:";
            // 
            // CbStatus
            // 
            this.CbStatus.AutoCompleteCustomSource.AddRange(new string[] {
            "Efetuada",
            "Cancelada"});
            this.CbStatus.FormattingEnabled = true;
            this.CbStatus.Items.AddRange(new object[] {
            "Efetuada",
            "Cancelada"});
            this.CbStatus.Location = new System.Drawing.Point(56, 20);
            this.CbStatus.Name = "CbStatus";
            this.CbStatus.Size = new System.Drawing.Size(121, 21);
            this.CbStatus.TabIndex = 110;
            this.CbStatus.SelectedIndexChanged += new System.EventHandler(this.CbStatus_SelectedIndexChanged);
            // 
            // vendasPorDataTableAdapter
            // 
            this.vendasPorDataTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.CbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtInicial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelatorioVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vendas";
            this.Load += new System.EventHandler(this.FrmRelatorioVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker DtInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource vendasPorDataBindingSource;
        private hotelDataSet hotelDataSet;
        private hotelDataSetTableAdapters.VendasPorDataTableAdapter vendasPorDataTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbStatus;
    }
}