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
    public partial class FrmEstoquebaixo : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;

        public FrmEstoquebaixo()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "Descrição";
            Grid.Columns[3].HeaderText = "Estoque";
            Grid.Columns[4].HeaderText = "Fornecedor";
            Grid.Columns[5].HeaderText = "Valor Venda";
            Grid.Columns[6].HeaderText = "Valor Compra";
            Grid.Columns[7].HeaderText = "Data";
            Grid.Columns[8].HeaderText = "Imagem";
            Grid.Columns[9].HeaderText = "Id Fornecedor";

            Grid.Columns[0].Visible = false;
            Grid.Columns[7].Visible = false;
            Grid.Columns[8].Visible = false;
            Grid.Columns[9].Visible = false;

            //AJUSTANDO TAMANHO DA COLUNA
            Grid.Columns[3].Width = 60;
            Grid.Columns[5].Width = 90;
            Grid.Columns[6].Width = 95;
            Grid.Columns[7].Width = 90;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[5].DefaultCellStyle.Format = "C2";
            Grid.Columns[6].DefaultCellStyle.Format = "C2";
        }


        private void Listar()
        {
            con.AbrirConnection();
            sql = "SELECT pro.id, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.fornecedor FROM produtos as pro INNER JOIN fornecedores as forn ON pro.fornecedor = forn.id where estoque < @estoque order by pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@estoque", 15);
            MySqlDataAdapter da = new MySqlDataAdapter(); 
            da.SelectCommand = cmd; 
            DataTable dt = new DataTable();
            da.Fill(dt); 
            Grid.DataSource = dt; 
            con.FecharConnection();

            FormatarDG();
        }

        private void FrmEstoquebaixo_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void FrmEstoquebaixo_Activated(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
