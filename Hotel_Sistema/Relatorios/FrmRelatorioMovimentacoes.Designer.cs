namespace Hotel_Sistema.Relatorios
{
    partial class FrmRelatorioMovimentacoes
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
            this.CbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.movimentacoesPorDataTipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hotel_Sistema.hotelDataSet();
            this.movimentacoesPorDataTipoTableAdapter = new Hotel_Sistema.hotelDataSetTableAdapters.MovimentacoesPorDataTipoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacoesPorDataTipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CbTipo
            // 
            this.CbTipo.AutoCompleteCustomSource.AddRange(new string[] {
            "Efetuada",
            "Cancelada"});
            this.CbTipo.FormattingEnabled = true;
            this.CbTipo.Items.AddRange(new object[] {
            "Entrada",
            "Saída"});
            this.CbTipo.Location = new System.Drawing.Point(58, 14);
            this.CbTipo.Name = "CbTipo";
            this.CbTipo.Size = new System.Drawing.Size(121, 21);
            this.CbTipo.TabIndex = 116;
            this.CbTipo.SelectedIndexChanged += new System.EventHandler(this.CbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 115;
            this.label2.Text = "Tipo:";
            // 
            // DtFinal
            // 
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(590, 11);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(87, 20);
            this.DtFinal.TabIndex = 114;
            this.DtFinal.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtFinal.ValueChanged += new System.EventHandler(this.DtFinal_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "Data Final:";
            // 
            // DtInicial
            // 
            this.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicial.Location = new System.Drawing.Point(384, 12);
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.Size = new System.Drawing.Size(87, 20);
            this.DtInicial.TabIndex = 112;
            this.DtInicial.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtInicial.ValueChanged += new System.EventHandler(this.DtInicial_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "Data Incial:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSMovimentacoes";
            reportDataSource1.Value = this.movimentacoesPorDataTipoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hotel_Sistema.Relatorios.RelatorioMovimentacoes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(662, 430);
            this.reportViewer1.TabIndex = 117;
            // 
            // movimentacoesPorDataTipoBindingSource
            // 
            this.movimentacoesPorDataTipoBindingSource.DataMember = "MovimentacoesPorDataTipo";
            this.movimentacoesPorDataTipoBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "hotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // movimentacoesPorDataTipoTableAdapter
            // 
            this.movimentacoesPorDataTipoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatorioMovimentacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(694, 483);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.CbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtInicial);
            this.Controls.Add(this.label4);
            this.Name = "FrmRelatorioMovimentacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Movimentações";
            this.Load += new System.EventHandler(this.FrmRelatorioMovimentacoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movimentacoesPorDataTipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtInicial;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource movimentacoesPorDataTipoBindingSource;
        private hotelDataSet hotelDataSet;
        private hotelDataSetTableAdapters.MovimentacoesPorDataTipoTableAdapter movimentacoesPorDataTipoTableAdapter;
    }
}