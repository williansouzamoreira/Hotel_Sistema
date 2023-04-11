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

namespace Hotel_Sistema.Reservas
{
    public partial class FrmCheckin : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string id;
        string pago;

        public FrmCheckin()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Quarto";
            Grid.Columns[2].HeaderText = "Data Entrada";
            Grid.Columns[3].HeaderText = "Data Saída";
            Grid.Columns[4].HeaderText = "Dias";
            Grid.Columns[5].HeaderText = "Valor";
            Grid.Columns[6].HeaderText = "Nome";
            Grid.Columns[7].HeaderText = "Telefone";
            Grid.Columns[8].HeaderText = "Data";
            Grid.Columns[9].HeaderText = "Funcionário";
            Grid.Columns[10].HeaderText = "Status";
            Grid.Columns[11].HeaderText = "Check-In";
            Grid.Columns[12].HeaderText = "Check-out";
            Grid.Columns[13].HeaderText = "Pago";

            Grid.Columns[0].Visible = false;
            Grid.Columns[4].Visible = false;
            Grid.Columns[5].Visible = false;
            Grid.Columns[8].Visible = false;
            Grid.Columns[9].Visible = false;
            Grid.Columns[10].Visible = false;
            Grid.Columns[12].Visible = false;
            Grid.Columns[13].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[5].DefaultCellStyle.Format = "C2";


        }


        private void ListarData()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where data = @data and status = @status and checkin = @checkin order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtEntrada.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkin", "Não");
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
            sql = "SELECT * from reservas where nome like @nome and data = @data and status = @status and checkin = @checkin order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text + "%");
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtEntrada.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkin", "Não");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }


        private void FrmCheckin_Load(object sender, EventArgs e)
        {
            DtEntrada.Value = DateTime.Today;
            ListarData();
            BtnAdd.Enabled = false;
        }

        private void DtEntrda_ValueChanged(object sender, EventArgs e)
        {
            ListarData();
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (pago == "Sim")
            {
                con.AbrirConnection();
                sql = "UPDATE reservas SET checkin = @checkin where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@checkin", "Sim");
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                con.FecharConnection();
                ListarData();
                BtnAdd.Enabled = false;
            }
            else
            {
                MessageBox.Show("Você precisa antes confirmar o pagamento!");
                BtnAdd.Enabled = false;
            }
        }

        private void Grid_Click(object sender, EventArgs e)
        {

        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAdd.Enabled = true;

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            pago = Grid.CurrentRow.Cells[13].Value.ToString();
        }
    }
}
