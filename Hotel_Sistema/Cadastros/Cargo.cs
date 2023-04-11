using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Sistema.Cadastros
{
    public partial class FrmCargo : Form
    {
        //VARIÁVEIS GLOBAIS
        Conexao con = new Conexao(); //Instanciando a Classe Conexao
        string sql; //Variável global para receber a linha de comando SQL
        MySqlCommand cmd; //Variável global para instanciar o comando SQL
        string id;

        public FrmCargo()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Cargo";

            Grid.Columns[0].Visible = false;
            Grid.Columns[1].Width = 200;
        }


        private void Listar() //Listando os dados da tabela Cargos, do BD
        {
            con.AbrirConnection();
            sql = "SELECT * FROM cargos order by cargo asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter(); //Instanciando uma variável MySQL
            da.SelectCommand = cmd; //Recuperando as informações do SQL no adapter
            DataTable dt = new DataTable();
            da.Fill(dt); //Inserindo informações adapatadas no DataTable (propriedade da Grid)
            Grid.DataSource = dt; //Exibindo as informações no DataGrid
            con.FecharConnection();

            FormatarDG();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Enabled = true;
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            TxtNome.Focus();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                BtnNovo.Enabled = false;
                return;
            }

            //PROGRAMANDO O BOTÃO SALVAR
            con.AbrirConnection();
            sql = "INSERT INTO cargos (cargo) VALUES (@cargo)"; //@cargo é um nome qualquer, ele receberá informação pela variável cmd
            cmd = new MySqlCommand(sql, con.con); //Instanciando (1° con é da instacia de Conexao neste form e o 2° é da classe Conexao)
            cmd.Parameters.AddWithValue("@cargo", TxtNome.Text); //Adicionando parametros com valores, na tabela do SQL
            cmd.ExecuteNonQuery(); //Executando os parametros informados anteriormente
            con.FecharConnection();

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            TxtNome.Enabled = false;
            TxtNome.Text = "";
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Cargo!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                return;
            }

            //PROGRAMANDO O BOTÃO EDITAR
            con.AbrirConnection();
            sql = "UPDATE cargos SET cargo = @cargo where id = @id"; //@variavel, é uma variável que receberá valores pelo CMD abaixo
            cmd = new MySqlCommand(sql, con.con); //Instanciando (1° con é da instacia de Conexao neste form e o 2° é da classe Conexao)
            cmd.Parameters.AddWithValue("@cargo", TxtNome.Text); //Adicionando parametros com valores, na tabela do SQL
            cmd.Parameters.AddWithValue("@id", id); //id é uma variável glogal que recura o id da tabela no método CellClick da Grid
            cmd.ExecuteNonQuery(); //Executando os parametros informados anteriormente
            con.FecharConnection();

            MessageBox.Show("Registro Alterado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            TxtNome.Text = "";
            TxtNome.Enabled = false;
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
           var resultado = MessageBox.Show("Deseja Realmente Excuir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO EXCLUIR  ==> Código comentado no botão Editar.
                con.AbrirConnection();
                sql = "DELETE FROM cargos WHERE id = @id"; 
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

        private void FrmCargo_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            BtnNovo.Enabled = true;
            TxtNome.Enabled = true;

            id = Grid.CurrentRow.Cells[0].Value.ToString(); //Recuperando o valor da linha 0 no Banco de dados (que é usado nos métodos EDITAR e EXCLUIR).
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();

        }
    }
}
