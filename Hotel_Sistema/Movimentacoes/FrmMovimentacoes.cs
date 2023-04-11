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
    public partial class FrmMovimentacoes : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;

        string idvenda;

        Double totalEntradas, totalSaidas;

        public FrmMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmMovimentacoes_Load(object sender, EventArgs e)
        {
            CbBuscar.SelectedIndex = 0;
            DtInicial.Value = DateTime.Today;
            DtFinal.Value = DateTime.Today;

            Listar();
            BuscarData();
        }


        private void Listar()
        {
            con.AbrirConnection();
            sql = "SELECT * from movimentacoes order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Tipo";
            Grid.Columns[2].HeaderText = "Movimento";
            Grid.Columns[3].HeaderText = "Valor";
            Grid.Columns[4].HeaderText = "Funcionário";
            Grid.Columns[5].HeaderText = "Data";
            Grid.Columns[6].HeaderText = "ID Movimento";

            Grid.Columns[0].Visible = false;
            Grid.Columns[6].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[3].DefaultCellStyle.Format = "C2";

            totalizarEntradas();
            totalizarSaidas();
            totalizar();
        }

        private void BuscarData() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();

            if (CbBuscar.SelectedIndex == 0)
            {
                sql = "SELECT * FROM movimentacoes WHERE data >= @datainicial AND data <= @datafinal order by data desc";
                cmd = new MySqlCommand(sql, con.con);
            }
            else
            {
                sql = "SELECT * FROM movimentacoes WHERE data >= @datainicial AND data <= @datafinal and tipo = @tipo order by data desc";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@tipo", CbBuscar.Text);
            }

            cmd.Parameters.AddWithValue("@datainicial", Convert.ToDateTime(DtInicial.Text));
            cmd.Parameters.AddWithValue("@datafinal", Convert.ToDateTime(DtFinal.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void BuscarTipo() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM movimentacoes WHERE tipo = @tipo order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", CbBuscar.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void totalizarEntradas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells["Tipo"].Value.ToString() == "Entrada")
                {
                    total += Convert.ToDouble(linha.Cells["valor"].Value);
                }
            }
            totalEntradas = total;

            LblEntradas.Text = Convert.ToDouble(total).ToString("c2");
        }

        private void totalizarSaidas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells["Tipo"].Value.ToString() == "Saída")
                {
                    total += Convert.ToDouble(linha.Cells["valor"].Value);
                }
            }

            totalSaidas = total;

            LblSaidas.Text = Convert.ToDouble(total).ToString("c2");
        }

        private void totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                total = totalEntradas - totalSaidas;
            }

            LblTotal.Text = Convert.ToDouble(total).ToString("c2");

            if (total >= 0)
            {
                LblTotal.ForeColor = Color.Green;
            }
            else
            {
                LblTotal.ForeColor = Color.Red;
            }
        }
    }
}
