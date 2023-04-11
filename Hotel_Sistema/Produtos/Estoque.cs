using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Sistema.Produtos
{
    public partial class FrmEstoque : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;

        string ultimoIDGasto;

        public FrmEstoque()
        {
            InitializeComponent();
        }

        private void CarregarComboBox()
        {
            con.AbrirConnection();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CbFornecedor.DataSource = dt;
            CbFornecedor.ValueMember = "id";
            CbFornecedor.DisplayMember = "nome";

            con.FecharConnection();
        }

        private void habilitarCampos()
        {
            //TxtProduto.Enabled = true;
            TxtValor.Enabled = true;
           // TxtEstoque.Enabled = true;
            CbFornecedor.Enabled = true;
            TxtQuantidade.Enabled = true;
            TxtQuantidade.Focus();
            BtnSalvar.Enabled = true;
        }

        private void desabilitarCampos()
        {
            TxtProduto.Enabled = false;
            TxtValor.Enabled = false;
            TxtEstoque.Enabled = false;
            CbFornecedor.Enabled = false;
            TxtQuantidade.Enabled = false;
            BtnSalvar.Enabled = false;

        }
        private void limparCampos()
        {
            TxtProduto.Text = "";
            TxtValor.Text = "";
            TxtEstoque.Text = "";
            TxtQuantidade.Text = "";
        }


        private void FrmEstoque_Load(object sender, EventArgs e)
        {
            desabilitarCampos();
            CarregarComboBox();
        }

        private void BtnProduto_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            limparCampos();

            Program.ChamadaProdutos = "estoque";
            Produtos.FrmProdutos Form = new Produtos.FrmProdutos();
            Form.Show();
        }

        private void FrmEstoque_Activated(object sender, EventArgs e)
        {
            TxtEstoque.Text = Program.EstoqueProduto;
            TxtProduto.Text = Program.NomeProduto;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtProduto.Text.ToString().Trim() == "")
            {
                TxtProduto.Text = "";
                MessageBox.Show("Seleciono um Produto!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProduto.Focus();
                return;
            }

            if (TxtQuantidade.Text == "")
            {
                MessageBox.Show("Preencha a Quantidade!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQuantidade.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO SALVAR
            con.AbrirConnection();
            sql = "UPDATE produtos SET fornecedor = @fornecedor, valor_compra = @valor, estoque = @estoque where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToDouble(TxtQuantidade.Text) + Convert.ToDouble(TxtEstoque.Text));
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@fornecedor", CbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@id", Program.IdProduto);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Feito com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //===========================================================================

            //INSERINDO VALOR NA TABELA GASTOS.
            con.AbrirConnection();
            sql = "INSERT INTO gastos (descricao, valor, funcionario, data) VALUES (@descricao, @valor, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", "Saída");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
   
            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //RECUPERANDO ULTIMO ID DO GASTO.
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirConnection();
            FrmMenu form = new FrmMenu();
            cmdVerificar = new MySqlCommand("SELECT id FROM gastos order by id desc LIMIT 1", con.con);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA
                while (reader.Read())
                {
                    ultimoIDGasto = Convert.ToString(reader["id"]);
                }
            }


            //===========================================================================

            //INSERINDO VALOR NA TABELA MOVIMENTAÇÕES.
            con.AbrirConnection();
            sql = "INSERT INTO movimentacoes(tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Compra de Produto");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIDGasto);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //===========================================================================

            limparCampos();
            desabilitarCampos();
        }

        private void CbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
