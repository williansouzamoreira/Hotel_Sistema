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
    public partial class FrmHospedes : Form
    {
        Conexao con = new Conexao(); //Instanciando a Classe Conexao
        string sql; //Variável global para receber a linha de comando SQL
        MySqlCommand cmd; //Variável global para instanciar o comando SQL
        MySqlCommand cmdVerificar;
        string id;

        string cpfAntigo;

        public FrmHospedes()
        {
            InitializeComponent();
        }


        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "CPF";
            Grid.Columns[3].HeaderText = "Endereço";
            Grid.Columns[4].HeaderText = "Telefone";
            Grid.Columns[5].HeaderText = "Funcionario";
            Grid.Columns[6].HeaderText = "Data";

            Grid.Columns[0].Visible = false;
            Grid.Columns[5].Visible = false;

        }


        private void Listar()
        {
            con.AbrirConnection();
            sql = "SELECT * FROM hospedes order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void BuscarNome()
        {
            con.AbrirConnection();
            sql = "SELECT * FROM hospedes WHERE nome LIKE @nome order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtBuscarNome.Text + "%");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void BuscarCPF()
        {
            con.AbrirConnection();
            sql = "SELECT * FROM hospedes WHERE cpf = @cpf order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cpf", TxtBuscarCPF.Text);
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
            TxtCPF.Enabled = true;
            TxtEndereco.Enabled = true;
            TxtTelefone.Enabled = true;
            TxtNome.Focus();
        }

        private void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtCPF.Enabled = false;
            TxtEndereco.Enabled = false;
            TxtTelefone.Enabled = false;
        }
        private void limparCampos()
        {
            TxtNome.Text = "";
            TxtCPF.Text = "";
            TxtEndereco.Text = "";
            TxtTelefone.Text = "";
        }

        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            Listar();
            RbNome.Checked = true;
        }

        private void RbNome_CheckedChanged(object sender, EventArgs e)
        {
            TxtBuscarNome.Visible = true;
            TxtBuscarCPF.Visible = false;

            TxtBuscarNome.Focus();

            TxtBuscarNome.Text = "";
            TxtBuscarCPF.Text = "";
        }

        private void RbCPF_CheckedChanged(object sender, EventArgs e)
        {
            TxtBuscarCPF.Visible = true;
            TxtBuscarNome.Visible = false;

            TxtBuscarCPF.Focus();

            TxtBuscarNome.Text = "";
            TxtBuscarCPF.Text = "";
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

            if (TxtCPF.Text == "   .   .   .-")
            {
                MessageBox.Show("Preencha o CPF!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCPF.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO SALVAR  ===> Código comentado na Form Cargo

            con.AbrirConnection();
            sql = "INSERT INTO hospedes (nome, cpf, endereco, telefone, funcionario, data) VALUES (@nome, @cpf, @endereco, @telefone, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", TxtCPF.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            cmdVerificar = new MySqlCommand("SELECT * FROM hospedes WHERE cpf = @cpf", con.con);
            cmdVerificar.Parameters.AddWithValue("@cpf", TxtCPF.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CPF já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCPF.Text = "";
                TxtCPF.Focus();
                return;
            }


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
            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                return;
            }

            if (TxtCPF.Text == "   .   .   .-")
            {
                MessageBox.Show("Preencha o CPF!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCPF.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO EDITAR ==> Código comentado no Form Cargo
            con.AbrirConnection();
            sql = "UPDATE hospedes SET nome = @nome, cpf = @cpf, endereco = @endereco, telefone = @telefone, funcionario = @funcionario where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", TxtCPF.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            if (TxtCPF.Text != cpfAntigo)
            {
                cmdVerificar = new MySqlCommand("SELECT * FROM hospedes WHERE cpf = @cpf", con.con);
                cmdVerificar.Parameters.AddWithValue("@cpf", TxtCPF.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCPF.Text = "";
                    TxtCPF.Focus();
                    return;
                }
            }

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
                sql = "DELETE FROM hospedes WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConnection();


                MessageBox.Show("Registro Excluído com Sucesso!", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                TxtNome.Text = "";
                TxtNome.Enabled = false;
                Listar();
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
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtCPF.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtEndereco.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            TxtTelefone.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            
            cpfAntigo = TxtCPF.Text = Grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void TxtBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            limparCampos();
            if (TxtBuscarCPF.Text == "   .   .   .-")
            {
                Listar();
            }
            else
            {
                BuscarCPF();
            }
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            limparCampos();
            BuscarNome();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.ChamadaHospedes == "hospedes")
            {
                Program.NomeHospede = Grid.CurrentRow.Cells[1].Value.ToString();
                Close();
            }
        }
    }
}
