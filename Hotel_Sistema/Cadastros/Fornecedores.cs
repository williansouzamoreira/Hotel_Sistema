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
    public partial class FrmFornecedores : Form
    {

        Conexao con = new Conexao(); 
        string sql;
        MySqlCommand cmd; 
        MySqlCommand cmdVerificar;
        string id;


        string nomeAntigo;

        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "Endereço";
            Grid.Columns[2].HeaderText = "Telefone";
            
            Grid.Columns[0].Visible = false;
        }


        private void Listar() //Listando os dados da tabela Cargos, do BD
        {
            con.AbrirConnection();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter(); //Instanciando uma variável MySQL
            da.SelectCommand = cmd; //Recuperando as informações do SQL no adapter
            DataTable dt = new DataTable();
            da.Fill(dt); //Inserindo informações adapatadas no DataTable (propriedade da Grid)
            Grid.DataSource = dt; //Exibindo as informações no DataGrid
            con.FecharConnection();

            FormatarDG();
        }

        private void BuscarNome() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM fornecedores WHERE nome LIKE @nome order by nome asc";
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

        private void habilitarCampos()
        {
            TxtNome.Enabled = true;
            TxtEndereco.Enabled = true;
            TxtTelefone.Enabled = true;
            TxtNome.Focus();
        }

        private void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtEndereco.Enabled = false;
            TxtTelefone.Enabled = false;
        }
        private void limparCampos()
        {
            TxtNome.Text = "";
            TxtEndereco.Text = "";
            TxtTelefone.Text = "";
        }



        private void label1_Click(object sender, EventArgs e)
        {

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
            sql = "INSERT INTO fornecedores (nome, endereco, telefone, data) VALUES (@nome, @endereco, @telefone, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
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

            //CÓDIGO DO BOTÃO EDITAR ==> Código comentado no Form Cargo
            con.AbrirConnection();
            sql = "UPDATE fornecedores SET nome = @nome, endereco = @endereco, telefone = @telefone where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
            cmd.Parameters.AddWithValue("@id", id);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            if (TxtNome.Text != nomeAntigo)
            {
                cmdVerificar = new MySqlCommand("SELECT * FROM fornecedores WHERE nome = @nome", con.con);
                cmdVerificar.Parameters.AddWithValue("@nome", TxtNome.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Fornecedor já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtNome.Text = "";
                    TxtNome.Focus();
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

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            BtnNovo.Enabled = true;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtEndereco.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtTelefone.Text = Grid.CurrentRow.Cells[3].Value.ToString();

            nomeAntigo = TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excuir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO EXCLUIR ==> Código comentado no Form Cargo

                con.AbrirConnection();
                sql = "DELETE FROM fornecedores WHERE id = @id";
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

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }
    }
}
