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

namespace Hotel_Sistema.Movimentacoes
{
    public partial class FrmGastos : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;

        string ultimoIDGasto;

        public FrmGastos()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Descricao";
            Grid.Columns[2].HeaderText = "Valor";
            Grid.Columns[3].HeaderText = "Funcionário";
            Grid.Columns[4].HeaderText = "Data";

            Grid.Columns[0].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[2].DefaultCellStyle.Format = "C2";

            Grid.Columns[1].Width = 150;
            Grid.Columns[2].Width = 75;
            Grid.Columns[4].Width = 75;

            totalizar();

        }


        private void Listar()  // ==>Código comentado no Form Cargo
        {
            con.AbrirConnection();
            sql = "SELECT * FROM gastos order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
            totalizar();
        }

        private void habilitarCampos()
        {
            TxtDescricao.Enabled = true;
            TxtValor.Enabled = true;
            TxtDescricao.Focus();
        }

        private void desabilitarCampos()
        {
            TxtDescricao.Enabled = false;
            TxtValor.Enabled = false;
        }
        private void limparCampos()
        {
            TxtDescricao.Text = "";
            TxtValor.Text = "";
        }

        private void BuscarData() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM gastos WHERE data = @data order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtBuscar.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void FrmGastos_Load(object sender, EventArgs e)
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
            if (TxtDescricao.Text.ToString().Trim() == "")
            {
                TxtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescricao.Focus();
                return;
            }

            if (TxtValor.Text.ToString().Trim() == "")
            {
                TxtValor.Text = "";
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO SALVAR  ===> Código comentado na Form Cargo

            con.AbrirConnection();
            sql = "INSERT INTO gastos (descricao, valor, funcionario, data) VALUES (@descricao, @valor, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", TxtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);

            cmd.ExecuteNonQuery();
            con.FecharConnection();


            //=============================================================
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

            //==================================================================
            //INSERINDO O GASTO NAS MOVIMENTAÇÕES.
            con.AbrirConnection();
            sql = "INSERT INTO movimentacoes(tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Gasto");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIDGasto);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (TxtDescricao.Text.ToString().Trim() == "")
            {
                TxtDescricao.Text = "";
                MessageBox.Show("Preencha a Descrição!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescricao.Focus();
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
            sql = "UPDATE gastos SET descricao = @descricao, valor = @valor, funcionario = @funcionario, data = curDate() where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", TxtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();


            //ATUALIZAR O VALOR NA MOVIMENTACAO
            con.AbrirConnection();
            sql = "UPDATE movimentacoes SET valor = @valor, funcionario = @funcionario, data = curDate() where id_movimento = @id and movimento = @movimento";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text.Replace(",", ".")));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@movimento", "Gasto");

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
                sql = "DELETE FROM gastos WHERE id = @id";
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


                //EXCLUSÃO DO MOVIMENTO DO GASTO
                con.AbrirConnection();
                sql = "DELETE FROM movimentacoes WHERE id_movimento = @id and movimento = @movimento";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@movimento", "Gasto");
                cmd.ExecuteNonQuery();
                con.FecharConnection();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            BtnNovo.Enabled = true;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            TxtDescricao.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtValor.Text = Grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void totalizar()
        {
            double total = 0;
            foreach(DataGridViewRow linha in Grid.Rows)
            {
                total += Convert.ToDouble(linha.Cells["valor"].Value);
            }

            LblTotal.Text = Convert.ToDouble(total).ToString("c2");
        }
    }
}
