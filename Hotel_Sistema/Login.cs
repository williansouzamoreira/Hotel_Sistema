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

namespace Hotel_Sistema
{
    public partial class FrmLogin : Form
    {
        Conexao con = new Conexao();
        public FrmLogin() //Método construtor da classe
        {
            InitializeComponent();
            pnlLogin.Visible = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e) //Método de carregamento
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170); //Deixando o formulário no centro da tela
            pnlLogin.Visible = true;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 114, 160); //Esta cor foi buscada no PhotoShop.
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 72, 103);  //Esta cor foi buscada no PhotoShop.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e) //Chamando o Login quando pressionar o Enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChamarLogin();
            }

        }

        private void ChamarLogin()
        {
            MySqlCommand cmdVerificar;

            //Validação do preenchimento dos campos Usuário e Senha.

            if (txtUsuario.Text.ToString().Trim()== "")
            {
                MessageBox.Show("Preencha o Usuário!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }

            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha a Senha!", "Campo Vazio", MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            //Código do Login - Chamada da tela principal
            MySqlDataReader reader;
            con.AbrirConnection();
            FrmMenu form = new FrmMenu(); //Instanciando o elemento (inicializando) - form é o nome do elemento.
            cmdVerificar = new MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario and senha =@senha", con.con);
            cmdVerificar.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmdVerificar.Parameters.AddWithValue("@senha", txtSenha.Text);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DO LOGIN
                while (reader.Read())
                {
                    Program.NomeUsuario = Convert.ToString(reader["nome"]);
                    Program.CargoUsuario = Convert.ToString(reader["cargo"]);
                }

                MessageBox.Show("Bem Vindo " + Program.NomeUsuario + "!", "Login Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                Limpar();
                form.Show(); //Exibindo o formulário Menu
            }
            else
            {
                MessageBox.Show("Dados Incorretos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpar();
            }

            con.FecharConnection();
        }

        private void Limpar()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170); //Deixando o formulário no centro da tela

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
