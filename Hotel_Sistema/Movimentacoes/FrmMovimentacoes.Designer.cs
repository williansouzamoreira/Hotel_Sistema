namespace Hotel_Sistema.Movimentacoes
{
    partial class FrmMovimentacoes
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DtInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblEntradas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblSaidas = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid.Location = new System.Drawing.Point(20, 59);
            this.Grid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersWidth = 51;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(819, 416);
            this.Grid.TabIndex = 108;
            // 
            // DtFinal
            // 
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(723, 20);
            this.DtFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(115, 22);
            this.DtFinal.TabIndex = 107;
            this.DtFinal.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtFinal.ValueChanged += new System.EventHandler(this.DtFinal_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(637, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 106;
            this.label4.Text = "Data Final:";
            // 
            // DtInicial
            // 
            this.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicial.Location = new System.Drawing.Point(513, 20);
            this.DtInicial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.Size = new System.Drawing.Size(115, 22);
            this.DtInicial.TabIndex = 110;
            this.DtInicial.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtInicial.ValueChanged += new System.EventHandler(this.DtInicial_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 109;
            this.label1.Text = "Data Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 111;
            this.label2.Text = "Entradas / Saídas:";
            // 
            // CbBuscar
            // 
            this.CbBuscar.FormattingEnabled = true;
            this.CbBuscar.Items.AddRange(new object[] {
            "Tudo",
            "Entrada",
            "Saída"});
            this.CbBuscar.Location = new System.Drawing.Point(153, 17);
            this.CbBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CbBuscar.Name = "CbBuscar";
            this.CbBuscar.Size = new System.Drawing.Size(160, 24);
            this.CbBuscar.TabIndex = 112;
            this.CbBuscar.SelectedIndexChanged += new System.EventHandler(this.CbBuscar_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 490);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 113;
            this.label3.Text = "Entradas:";
            // 
            // LblEntradas
            // 
            this.LblEntradas.AutoSize = true;
            this.LblEntradas.ForeColor = System.Drawing.Color.Green;
            this.LblEntradas.Location = new System.Drawing.Point(87, 490);
            this.LblEntradas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEntradas.Name = "LblEntradas";
            this.LblEntradas.Size = new System.Drawing.Size(16, 17);
            this.LblEntradas.TabIndex = 114;
            this.LblEntradas.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 490);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 115;
            this.label6.Text = "Saídas:";
            // 
            // LblSaidas
            // 
            this.LblSaidas.AutoSize = true;
            this.LblSaidas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LblSaidas.ForeColor = System.Drawing.Color.Red;
            this.LblSaidas.Location = new System.Drawing.Point(281, 490);
            this.LblSaidas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSaidas.Name = "LblSaidas";
            this.LblSaidas.Size = new System.Drawing.Size(16, 17);
            this.LblSaidas.TabIndex = 116;
            this.LblSaidas.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(669, 490);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 117;
            this.label8.Text = "Total:";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.ForeColor = System.Drawing.Color.Black;
            this.LblTotal.Location = new System.Drawing.Point(722, 490);
            this.LblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(16, 17);
            this.LblTotal.TabIndex = 118;
            this.LblTotal.Text = "0";
            // 
            // FrmMovimentacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(857, 521);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblSaidas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblEntradas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMovimentacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentações";
            this.Load += new System.EventHandler(this.FrmMovimentacoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DateTimePicker DtFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEntradas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblSaidas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblTotal;
    }
}