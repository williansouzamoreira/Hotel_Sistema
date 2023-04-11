namespace Hotel_Sistema.Movimentacoes
{
    partial class FrmNovoServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoServico));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.DtBuscar = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnHospede = new System.Windows.Forms.Button();
            this.TxtQuantidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtHospede = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cbservico = new System.Windows.Forms.ComboBox();
            this.CbQuarto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnRelatorio = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
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
            this.Grid.Location = new System.Drawing.Point(24, 203);
            this.Grid.Margin = new System.Windows.Forms.Padding(4);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersWidth = 51;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(732, 284);
            this.Grid.TabIndex = 129;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // DtBuscar
            // 
            this.DtBuscar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBuscar.Location = new System.Drawing.Point(641, 18);
            this.DtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.DtBuscar.Name = "DtBuscar";
            this.DtBuscar.Size = new System.Drawing.Size(115, 22);
            this.DtBuscar.TabIndex = 128;
            this.DtBuscar.Value = new System.DateTime(2020, 9, 2, 0, 0, 0, 0);
            this.DtBuscar.ValueChanged += new System.EventHandler(this.DtBuscar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 127;
            this.label4.Text = "Buscar:";
            // 
            // BtnHospede
            // 
            this.BtnHospede.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnHospede.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHospede.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnHospede.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHospede.Location = new System.Drawing.Point(270, 85);
            this.BtnHospede.Margin = new System.Windows.Forms.Padding(4);
            this.BtnHospede.Name = "BtnHospede";
            this.BtnHospede.Size = new System.Drawing.Size(31, 28);
            this.BtnHospede.TabIndex = 126;
            this.BtnHospede.Text = "+";
            this.BtnHospede.UseVisualStyleBackColor = false;
            this.BtnHospede.Click += new System.EventHandler(this.BtnHospede_Click);
            // 
            // TxtQuantidade
            // 
            this.TxtQuantidade.Enabled = false;
            this.TxtQuantidade.Location = new System.Drawing.Point(115, 151);
            this.TxtQuantidade.Margin = new System.Windows.Forms.Padding(4);
            this.TxtQuantidade.Name = "TxtQuantidade";
            this.TxtQuantidade.Size = new System.Drawing.Size(145, 22);
            this.TxtQuantidade.TabIndex = 119;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 123;
            this.label5.Text = "Quantidade:";
            // 
            // TxtValor
            // 
            this.TxtValor.Enabled = false;
            this.TxtValor.Location = new System.Drawing.Point(403, 151);
            this.TxtValor.Margin = new System.Windows.Forms.Padding(4);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(118, 22);
            this.TxtValor.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 122;
            this.label3.Text = "Valor:";
            // 
            // TxtHospede
            // 
            this.TxtHospede.Enabled = false;
            this.TxtHospede.Location = new System.Drawing.Point(115, 88);
            this.TxtHospede.Margin = new System.Windows.Forms.Padding(4);
            this.TxtHospede.Name = "TxtHospede";
            this.TxtHospede.Size = new System.Drawing.Size(145, 22);
            this.TxtHospede.TabIndex = 118;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 121;
            this.label2.Text = "Hóspede:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 125;
            this.label1.Text = "Serviço:";
            // 
            // Cbservico
            // 
            this.Cbservico.FormattingEnabled = true;
            this.Cbservico.Location = new System.Drawing.Point(403, 89);
            this.Cbservico.Name = "Cbservico";
            this.Cbservico.Size = new System.Drawing.Size(118, 24);
            this.Cbservico.TabIndex = 140;
            this.Cbservico.SelectedValueChanged += new System.EventHandler(this.Cbservico_SelectedValueChanged);
            // 
            // CbQuarto
            // 
            this.CbQuarto.FormattingEnabled = true;
            this.CbQuarto.Location = new System.Drawing.Point(641, 88);
            this.CbQuarto.Name = "CbQuarto";
            this.CbQuarto.Size = new System.Drawing.Size(115, 24);
            this.CbQuarto.TabIndex = 142;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 141;
            this.label6.Text = "Quarto:";
            // 
            // BtnRelatorio
            // 
            this.BtnRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRelatorio.Enabled = false;
            this.BtnRelatorio.FlatAppearance.BorderSize = 0;
            this.BtnRelatorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("BtnRelatorio.Image")));
            this.BtnRelatorio.Location = new System.Drawing.Point(488, 493);
            this.BtnRelatorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRelatorio.Name = "BtnRelatorio";
            this.BtnRelatorio.Size = new System.Drawing.Size(93, 80);
            this.BtnRelatorio.TabIndex = 139;
            this.BtnRelatorio.UseVisualStyleBackColor = true;
            this.BtnRelatorio.Click += new System.EventHandler(this.BtnRelatorio_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.FlatAppearance.BorderSize = 0;
            this.BtnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcluir.Image")));
            this.BtnExcluir.Location = new System.Drawing.Point(387, 493);
            this.BtnExcluir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(93, 80);
            this.BtnExcluir.TabIndex = 132;
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.Enabled = false;
            this.BtnSalvar.FlatAppearance.BorderSize = 0;
            this.BtnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalvar.Image")));
            this.BtnSalvar.Location = new System.Drawing.Point(286, 493);
            this.BtnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(93, 80);
            this.BtnSalvar.TabIndex = 131;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNovo.FlatAppearance.BorderSize = 0;
            this.BtnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Image = ((System.Drawing.Image)(resources.GetObject("BtnNovo.Image")));
            this.BtnNovo.Location = new System.Drawing.Point(184, 493);
            this.BtnNovo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(93, 80);
            this.BtnNovo.TabIndex = 130;
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // FrmNovoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(776, 589);
            this.Controls.Add(this.CbQuarto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Cbservico);
            this.Controls.Add(this.BtnRelatorio);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.DtBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnHospede);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtQuantidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtHospede);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNovoServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Serviço";
            this.Activated += new System.EventHandler(this.FrmNovoServico_Activated);
            this.Load += new System.EventHandler(this.FrmServicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRelatorio;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DateTimePicker DtBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnHospede;
        private System.Windows.Forms.TextBox TxtQuantidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtHospede;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cbservico;
        private System.Windows.Forms.ComboBox CbQuarto;
        private System.Windows.Forms.Label label6;
    }
}