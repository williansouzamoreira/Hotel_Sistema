namespace Hotel_Sistema.Reservas
{
    partial class FrmConsultarReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarReservas));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.DtInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbStatus = new System.Windows.Forms.ComboBox();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.DtBuscarReserva = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnRelatorio = new System.Windows.Forms.Button();
            this.BtnPago = new System.Windows.Forms.Button();
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
            this.Grid.Location = new System.Drawing.Point(15, 93);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersWidth = 51;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(1098, 220);
            this.Grid.TabIndex = 116;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // DtInicio
            // 
            this.DtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicio.Location = new System.Drawing.Point(670, 15);
            this.DtInicio.Name = "DtInicio";
            this.DtInicio.Size = new System.Drawing.Size(87, 20);
            this.DtInicio.TabIndex = 115;
            this.DtInicio.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtInicio.ValueChanged += new System.EventHandler(this.DtInicio_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(572, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Início da Reserva:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Status:";
            // 
            // CbStatus
            // 
            this.CbStatus.FormattingEnabled = true;
            this.CbStatus.Items.AddRange(new object[] {
            "Confirmada",
            "Cancelada"});
            this.CbStatus.Location = new System.Drawing.Point(58, 18);
            this.CbStatus.Name = "CbStatus";
            this.CbStatus.Size = new System.Drawing.Size(121, 21);
            this.CbStatus.TabIndex = 122;
            this.CbStatus.SelectedIndexChanged += new System.EventHandler(this.CbStatus_SelectedIndexChanged);
            // 
            // TxtNome
            // 
            this.TxtNome.Location = new System.Drawing.Point(303, 18);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(113, 20);
            this.TxtNome.TabIndex = 123;
            this.TxtNome.TextChanged += new System.EventHandler(this.TxtNome_TextChanged);
            // 
            // DtBuscarReserva
            // 
            this.DtBuscarReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBuscarReserva.Location = new System.Drawing.Point(896, 15);
            this.DtBuscarReserva.Name = "DtBuscarReserva";
            this.DtBuscarReserva.Size = new System.Drawing.Size(87, 20);
            this.DtBuscarReserva.TabIndex = 125;
            this.DtBuscarReserva.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtBuscarReserva.ValueChanged += new System.EventHandler(this.DtBuscarReserva_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(814, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 124;
            this.label3.Text = "Data Reserva:";
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColor = System.Drawing.Color.Transparent;
            this.BtnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnRemove.BackgroundImage")));
            this.BtnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemove.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.Location = new System.Drawing.Point(1053, 60);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(27, 27);
            this.BtnRemove.TabIndex = 126;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnRelatorio
            // 
            this.BtnRelatorio.BackColor = System.Drawing.Color.Transparent;
            this.BtnRelatorio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnRelatorio.BackgroundImage")));
            this.BtnRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRelatorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.BtnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRelatorio.Location = new System.Drawing.Point(1086, 60);
            this.BtnRelatorio.Name = "BtnRelatorio";
            this.BtnRelatorio.Size = new System.Drawing.Size(27, 27);
            this.BtnRelatorio.TabIndex = 119;
            this.BtnRelatorio.UseVisualStyleBackColor = false;
            this.BtnRelatorio.Click += new System.EventHandler(this.BtnRelatorio_Click);
            // 
            // BtnPago
            // 
            this.BtnPago.BackColor = System.Drawing.Color.Transparent;
            this.BtnPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPago.BackgroundImage")));
            this.BtnPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPago.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.BtnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPago.Location = new System.Drawing.Point(1020, 60);
            this.BtnPago.Name = "BtnPago";
            this.BtnPago.Size = new System.Drawing.Size(27, 27);
            this.BtnPago.TabIndex = 118;
            this.BtnPago.UseVisualStyleBackColor = false;
            this.BtnPago.Click += new System.EventHandler(this.BtnPago_Click);
            // 
            // FrmConsultarReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1135, 332);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.DtBuscarReserva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.CbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnRelatorio);
            this.Controls.Add(this.BtnPago);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.DtInicio);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConsultarReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Reservas";
            this.Load += new System.EventHandler(this.FrmConsultarReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRelatorio;
        private System.Windows.Forms.Button BtnPago;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DateTimePicker DtInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbStatus;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.DateTimePicker DtBuscarReserva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnRemove;
    }
}