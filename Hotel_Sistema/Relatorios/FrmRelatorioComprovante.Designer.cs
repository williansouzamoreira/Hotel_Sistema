namespace Hotel_Sistema.Relatorios
{
    partial class FrmRelatorioComprovante
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.detalhesVendaIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hotel_Sistema.hotelDataSet();
            this.vendasPorIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vendasPorIDTableAdapter = new Hotel_Sistema.hotelDataSetTableAdapters.VendasPorIDTableAdapter();
            this.detalhesVendaIDTableAdapter = new Hotel_Sistema.hotelDataSetTableAdapters.detalhesVendaIDTableAdapter();
            this.detalhesVendaIDBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ComprovanteServicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comprovanteServicoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comprovanteServicoTableAdapter = new Hotel_Sistema.hotelDataSetTableAdapters.ComprovanteServicoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesVendaIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesVendaIDBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComprovanteServicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprovanteServicoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // detalhesVendaIDBindingSource
            // 
            this.detalhesVendaIDBindingSource.DataMember = "detalhesVendaID";
            this.detalhesVendaIDBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "hotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendasPorIDBindingSource
            // 
            this.vendasPorIDBindingSource.DataMember = "VendasPorID";
            this.vendasPorIDBindingSource.DataSource = this.hotelDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSVendas";
            reportDataSource1.Value = this.vendasPorIDBindingSource;
            reportDataSource2.Name = "DSDetalhesVenda";
            reportDataSource2.Value = this.detalhesVendaIDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hotel_Sistema.Relatorios.RelatorioComprovante.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(683, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // vendasPorIDTableAdapter
            // 
            this.vendasPorIDTableAdapter.ClearBeforeFill = true;
            // 
            // detalhesVendaIDTableAdapter
            // 
            this.detalhesVendaIDTableAdapter.ClearBeforeFill = true;
            // 
            // detalhesVendaIDBindingSource1
            // 
            this.detalhesVendaIDBindingSource1.DataMember = "detalhesVendaID";
            this.detalhesVendaIDBindingSource1.DataSource = this.hotelDataSet;
            // 
            // ComprovanteServicoBindingSource
            // 
            this.ComprovanteServicoBindingSource.DataMember = "ComprovanteServico";
            this.ComprovanteServicoBindingSource.DataSource = this.hotelDataSet;
            // 
            // comprovanteServicoBindingSource1
            // 
            this.comprovanteServicoBindingSource1.DataMember = "ComprovanteServico";
            this.comprovanteServicoBindingSource1.DataSource = this.hotelDataSet;
            // 
            // comprovanteServicoTableAdapter
            // 
            this.comprovanteServicoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatorioComprovante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelatorioComprovante";
            this.Text = "Comprovante Vendas";
            this.Load += new System.EventHandler(this.FrmRelatorioComprovante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detalhesVendaIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesVendaIDBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComprovanteServicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprovanteServicoBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vendasPorIDBindingSource;
        private hotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource detalhesVendaIDBindingSource;
        private hotelDataSetTableAdapters.VendasPorIDTableAdapter vendasPorIDTableAdapter;
        private hotelDataSetTableAdapters.detalhesVendaIDTableAdapter detalhesVendaIDTableAdapter;
        private System.Windows.Forms.BindingSource detalhesVendaIDBindingSource1;
        private System.Windows.Forms.BindingSource ComprovanteServicoBindingSource;
        private System.Windows.Forms.BindingSource comprovanteServicoBindingSource1;
        private hotelDataSetTableAdapters.ComprovanteServicoTableAdapter comprovanteServicoTableAdapter;
    }
}