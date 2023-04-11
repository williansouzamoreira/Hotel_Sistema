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

namespace Hotel_Sistema.Cadastros
{
    public partial class FrmServicos : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;

        public FrmServicos()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Serviço";
            Grid.Columns[2].HeaderText = "Valor";

            Grid.Columns[0].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[2].DefaultCellStyle.Format = "C2";
        }


        private void Listar()  // ==>Código comentado no Form Cargo
        {
            con.AbrirConnection();
            sql = "SELECT * FROM servicos order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void habilitarCampos()
        {
            TxtNome.Enabled = true;
            TxtValor.Enabled = true;
            TxtNome.Focus();
        }

        private void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtValor.Enabled = false;
        }
        private void limparCampos()
        {
            TxtNome.Text = "";
            TxtValor.Text = "";
        }

        private void FrmServicos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO SALVAR  ===> Código comentado na Form Cargo

            con.AbrirConnection();
            sql = "INSERT INTO servicos (nome, valor) VALUES (@nome, @valor)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            BtnNovo.Enabled = true;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtValor.Text = Grid.CurrentRow.Cells[2].Value.ToString();

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                return;
            }

            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO EDITAR
            con.AbrirConnection();
            sql = "UPDATE servicos SET nome = @nome, valor = @valor where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Alterado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excuir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO EXCLUIR ==> Código comentado no Form Cargo

                con.AbrirConnection();
                sql = "DELETE FROM servicos WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConnection();

                MessageBox.Show("Registro Excluído com Sucesso!", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                limparCampos();
                desabilitarCampos();
                Listar();
            }
        }
    }
}
