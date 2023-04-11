namespace Hotel_Sistema.Relatorios
{
    partial class FrmRelatorioServico
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
            this.comprovanteServicoPorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hotel_Sistema.hotelDataSet();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comprovanteServicoPorDataTableAdapter = new Hotel_Sistema.hotelDataSetTableAdapters.ComprovanteServicoPorDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.comprovanteServicoPorDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comprovanteServicoPorDataBindingSource
            // 
            this.comprovanteServicoPorDataBindingSource.DataMember = "ComprovanteServicoPorData";
            this.comprovanteServicoPorDataBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "hotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DtFinal
            // 
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(660, 19);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(87, 20);
            this.DtFinal.TabIndex = 112;
            this.DtFinal.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtFinal.ValueChanged += new System.EventHandler(this.DtFinal_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Data Final:";
            // 
            // DtInicial
            // 
            this.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicial.Location = new System.Drawing.Point(454, 20);
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.Size = new System.Drawing.Size(87, 20);
            this.DtInicial.TabIndex = 110;
            this.DtInicial.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtInicial.ValueChanged += new System.EventHandler(this.DtInicial_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "Data Incial:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSServicos";
            reportDataSource1.Value = this.comprovanteServicoPorDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hotel_Sistema.Relatorios.RelatorioServico.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(735, 362);
            this.reportViewer1.TabIndex = 113;
            // 
            // comprovanteServicoPorDataTableAdapter
            // 
            this.comprovanteServicoPorDataTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatorioServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtInicial);
            this.Controls.Add(this.label4);
            this.Name = "FrmRelatorioServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Serviço";
            this.Load += new System.EventHandler(this.FrmRelatorioServico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comprovanteServicoPorDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtInicial;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource comprovanteServicoPorDataBindingSource;
        private hotelDataSet hotelDataSet;
        private hotelDataSetTableAdapters.ComprovanteServicoPorDataTableAdapter comprovanteServicoPorDataTableAdapter;
    }
}