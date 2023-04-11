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
    public partial class FrmUsuarios : Form
    {

        //VARIÁVEIS GLOBAIS DE CONEXÃO COM O BD MYSQL
        Conexao con = new Conexao();
        string sql; 
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;

        string UsuarioAntigo;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "Cargo";
            Grid.Columns[3].HeaderText = "Usuário";
            Grid.Columns[4].HeaderText = "Senha";
            Grid.Columns[5].HeaderText = "Data";

            Grid.Columns[0].Visible = false;
        }


        private void Listar()  // ==>Código comentado no Form Cargo
        {
            con.AbrirConnection();
            sql = "SELECT * FROM usuarios order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter(); 
            da.SelectCommand = cmd; 
            DataTable dt = new DataTable();
            da.Fill(dt); 
            Grid.DataSource = dt; 
            con.FecharConnection();

            FormatarDG();
        }

        private void BuscarNome() // ==>Código comentado no Form Funcionários
        {
            con.AbrirConnection();
            sql = "SELECT * FROM usuarios WHERE nome LIKE @nome order by nome asc";
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

        private void CarregarComboBox() // ==>Código comentado no Form Funcionários
        {
            con.AbrirConnection();
            sql = "SELECT * FROM cargos order by cargo asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CBCargo.DataSource = dt; 
            CBCargo.DisplayMember = "cargo"; 

            con.FecharConnection();
        }

        private void habilitarCampos()
        {
            TxtNome.Enabled = true;
            CBCargo.Enabled = true;
            TxtUsuario.Enabled = true;
            TxtSenha.Enabled = true;
            TxtNome.Focus();
        }

        private void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            CBCargo.Enabled = false;
            TxtUsuario.Enabled = false;
            TxtSenha.Enabled = false;
        }
        private void limparCampos()
        {
            TxtNome.Text = "";
            TxtUsuario.Text = "";
            TxtSenha.Text = "";
        }



        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Listar();
            CarregarComboBox();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {

            if (CBCargo.Text == "")
            {
                MessageBox.Show("Cadastre, Antes, um Cargo!");
                Close();
            }

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
            sql = "INSERT INTO usuarios (nome, cargo, usuario, senha, data) VALUES (@nome, @cargo, @usuario, @senha, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cargo", CBCargo.Text);
            cmd.Parameters.AddWithValue("@usuario", TxtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", TxtSenha.Text);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            cmdVerificar = new MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario", con.con);
            cmdVerificar.Parameters.AddWithValue("@usuario", TxtUsuario.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Usuário já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUsuario.Text = "";
                TxtUsuario.Focus();
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

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excuir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO EXCLUIR ==> Código comentado no Form Cargo

                con.AbrirConnection();
                sql = "DELETE FROM usuarios WHERE id = @id";
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (TxtUsuario.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Usuário!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUsuario.Focus();
                return;
            }

            if (TxtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha a Senha!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSenha.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO EDITAR ==> Código comentado no Form Cargo
            con.AbrirConnection();
            sql = "UPDATE usuarios SET nome = @nome, cargo = @cargo, usuario = @usuario, senha = @senha where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cargo", CBCargo.Text);
            cmd.Parameters.AddWithValue("@usuario", TxtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", TxtSenha.Text);
            cmd.Parameters.AddWithValue("@id", id);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            if (TxtUsuario.Text != UsuarioAntigo)
            {
                cmdVerificar = new MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario", con.con);
                cmdVerificar.Parameters.AddWithValue("@usuario", TxtUsuario.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Usuário já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUsuario.Text = "";
                    TxtUsuario.Focus();
                    return;
                }
            }
            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Alterado com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CBCargo.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtUsuario.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            TxtSenha.Text = Grid.CurrentRow.Cells[4].Value.ToString();

            UsuarioAntigo = TxtUsuario.Text = Grid.CurrentRow.Cells[3].Value.ToString();
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }
    }
}