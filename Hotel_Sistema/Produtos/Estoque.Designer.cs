namespace Hotel_Sistema.Produtos
{
    partial class FrmEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstoque));
            this.TxtEstoque = new System.Windows.Forms.TextBox();
            this.CbFornecedor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtProduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnProduto = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtEstoque
            // 
            this.TxtEstoque.Enabled = false;
            this.TxtEstoque.Location = new System.Drawing.Point(105, 80);
            this.TxtEstoque.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtEstoque.Name = "TxtEstoque";
            this.TxtEstoque.Size = new System.Drawing.Size(119, 22);
            this.TxtEstoque.TabIndex = 81;
            // 
            // CbFornecedor
            // 
            this.CbFornecedor.Enabled = false;
            this.CbFornecedor.FormattingEnabled = true;
            this.CbFornecedor.Location = new System.Drawing.Point(444, 26);
            this.CbFornecedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CbFornecedor.Name = "CbFornecedor";
            this.CbFornecedor.Size = new System.Drawing.Size(175, 24);
            this.CbFornecedor.TabIndex = 82;
            this.CbFornecedor.SelectedIndexChanged += new System.EventHandler(this.CbFornecedor_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 87;
            this.label6.Text = "Fornecedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 86;
            this.label5.Text = "Estoque:";
            // 
            // TxtValor
            // 
            this.TxtValor.Enabled = false;
            this.TxtValor.Location = new System.Drawing.Point(535, 79);
            this.TxtValor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(84, 22);
            this.TxtValor.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 85;
            this.label3.Text = "Valor";
            // 
            // TxtProduto
            // 
            this.TxtProduto.Enabled = false;
            this.TxtProduto.Location = new System.Drawing.Point(105, 22);
            this.TxtProduto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtProduto.Name = "TxtProduto";
            this.TxtProduto.Size = new System.Drawing.Size(175, 22);
            this.TxtProduto.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 84;
            this.label2.Text = "Produto:";
            // 
            // TxtQuantidade
            // 
            this.TxtQuantidade.Enabled = false;
            this.TxtQuantidade.Location = new System.Drawing.Point(328, 79);
            this.TxtQuantidade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtQuantidade.Name = "TxtQuantidade";
            this.TxtQuantidade.Size = new System.Drawing.Size(124, 22);
            this.TxtQuantidade.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 89;
            this.label1.Text = "Quantidade:";
            // 
            // BtnProduto
            // 
            this.BtnProduto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProduto.Location = new System.Drawing.Point(289, 22);
            this.BtnProduto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnProduto.Name = "BtnProduto";
            this.BtnProduto.Size = new System.Drawing.Size(31, 28);
            this.BtnProduto.TabIndex = 90;
            this.BtnProduto.Text = "+";
            this.BtnProduto.UseVisualStyleBackColor = false;
            this.BtnProduto.Click += new System.EventHandler(this.BtnProduto_Click);
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
            this.BtnSalvar.Location = new System.Drawing.Point(648, 26);
            this.BtnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(93, 80);
            this.BtnSalvar.TabIndex = 91;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // FrmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(777, 128);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.BtnProduto);
            this.Controls.Add(this.TxtQuantidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtEstoque);
            this.Controls.Add(this.CbFornecedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtProduto);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque";
            this.Activated += new System.EventHandler(this.FrmEstoque_Activated);
            this.Load += new System.EventHandler(this.FrmEstoque_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtEstoque;
        private System.Windows.Forms.ComboBox CbFornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnProduto;
        private System.Windows.Forms.Button BtnSalvar;
    }
}