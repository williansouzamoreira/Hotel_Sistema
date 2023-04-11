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
    public partial class FrmQuarto : Form
    {
        
        Conexao con = new Conexao(); 
        string sql; 
        MySqlCommand cmd; 
        MySqlCommand cmdVerificar;
        string id;

        string quartoAntigo;
        public FrmQuarto()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Quarto";
            Grid.Columns[2].HeaderText = "Valor";
            Grid.Columns[3].HeaderText = "Pessoas";

            Grid.Columns[0].Visible = false;
        }


        private void Listar() //Listando os dados da tabela Cargos, do BD
        {
            con.AbrirConnection();
            sql = "SELECT * FROM quartos order by quarto asc";
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
            TxtQuarto.Enabled = true;
            TxtValor.Enabled = true;
            TxtPessoas.Enabled = true;
        }

        private void desabilitarCampos()
        {
            TxtQuarto.Enabled = false;
            TxtValor.Enabled = false;
            TxtPessoas.Enabled = false;
            
        }
        private void limparCampos()
        {
            TxtQuarto.Text = "";
            TxtValor.Text = "";
            TxtPessoas.Text = "";
        
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
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
            if (TxtQuarto.Text.ToString().Trim() == "")
            {
                TxtQuarto.Text = "";
                MessageBox.Show("Preencha o Quarto!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQuarto.Focus();
                return;
            }

            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO SALVAR  ===> Código comentado na Form Cargo

            con.AbrirConnection();
            sql = "INSERT INTO quartos (quarto, valor, pessoas) VALUES (@quarto, @valor, @pessoas)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", TxtQuarto.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text));
            cmd.Parameters.AddWithValue("@pessoas", TxtPessoas.Text);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            cmdVerificar = new MySqlCommand("SELECT * FROM quartos WHERE quarto = @quarto", con.con);
            cmdVerificar.Parameters.AddWithValue("@quarto", TxtQuarto.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Quarto já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtQuarto.Text = "";
                TxtQuarto.Focus();
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
            if (TxtQuarto.Text.ToString().Trim() == "")
            {
                TxtQuarto.Text = "";
                MessageBox.Show("Preencha o Quarto!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQuarto.Focus();
                return;
            }

            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO EDITAR ==> Código comentado no Form Cargo
            con.AbrirConnection();
            sql = "UPDATE quartos SET quarto = @quarto, valor = @valor, pessoas = @pessoas where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", TxtQuarto.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text));
            cmd.Parameters.AddWithValue("@pessoas", TxtPessoas.Text);

            cmd.Parameters.AddWithValue("@id", id);

            //VERIFICAR SE O USUÁRIO JÁ EXISTE
            if (TxtQuarto.Text != quartoAntigo)
            {
                cmdVerificar = new MySqlCommand("SELECT * FROM qaurtos WHERE quarto = @quarto", con.con);
                cmdVerificar.Parameters.AddWithValue("@quarto", TxtQuarto.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Quarto já Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtQuarto.Text = "";
                    TxtQuarto.Focus();
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
                sql = "DELETE FROM quartos WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConnection();


                MessageBox.Show("Registro Excluído com Sucesso!", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                limparCampos();
                habilitarCampos();
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
            TxtQuarto.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtValor.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtPessoas.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            
            quartoAntigo = TxtQuarto.Text = Grid.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
