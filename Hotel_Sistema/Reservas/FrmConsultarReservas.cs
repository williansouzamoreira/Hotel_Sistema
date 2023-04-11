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
    public partial class FrmConsultarReservas : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;

        string id;
        string valor;
        public FrmConsultarReservas()
        {
            InitializeComponent();
        }

        private void FormatarDGVendas()
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

            Grid.Columns[1].Width = 60;
            Grid.Columns[4].Width = 50;
            Grid.Columns[5].Width = 80;
            Grid.Columns[8].Width = 80;
            Grid.Columns[10].Width = 80;
            Grid.Columns[11].Width = 60;
            Grid.Columns[12].Width = 60;
            Grid.Columns[13].Width = 60;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[5].DefaultCellStyle.Format = "C2";


        }


        private void ListarDatas()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where data = @data and status = @status order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtBuscarReserva.Text));
            cmd.Parameters.AddWithValue("@status", CbStatus.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDGVendas();
        }

        private void ListarDataInicio() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM reservas WHERE data = @data order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtInicio.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDGVendas();
        }

        private void ListarNome() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM reservas WHERE nome LIKE @nome order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text + "%");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDGVendas();
        }


        private void FrmConsultarReservas_Load(object sender, EventArgs e)
        {
            DtInicio.Value = DateTime.Today;
            DtBuscarReserva.Value = DateTime.Today;
            CbStatus.SelectedIndex = 0;
            ListarDatas();

            DesabilitarBotoes();
        }

        private void DesabilitarBotoes()
        {
            BtnPago.Enabled = false;
            BtnRelatorio.Enabled = false;
            BtnRemove.Enabled = false;
        }

        private void HabilitarBotoes()
        {
            BtnPago.Enabled = true;
            BtnRelatorio.Enabled = true;
            BtnRemove.Enabled = true;
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            ListarNome();
        }

        private void DtInicio_ValueChanged(object sender, EventArgs e)
        {
            ListarDataInicio();
        }

        private void DtBuscarReserva_ValueChanged(object sender, EventArgs e)
        {
            ListarDatas();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarBotoes();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            valor = Grid.CurrentRow.Cells[5].Value.ToString();
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
            con.AbrirConnection();
            sql = "UPDATE reservas SET pago = @pago where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@pago", "Sim");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //SALVAR VALOR DA RESERVA NA TABELA MOVIMENTAÇÕES
            con.AbrirConnection();
            sql = "INSERT INTO movimentacoes(tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Reserva");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(valor));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Lançamento de Valor Efetuado!", "Dados Lançados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListarDatas();
            DesabilitarBotoes();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            con.AbrirConnection();
            sql = "UPDATE reservas SET status = @status where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@status", "Cancelada");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            con.AbrirConnection();
            sql = "DELETE FROM ocupacoes where id_reserva = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();


            ListarDatas();
            DesabilitarBotoes();
        }

        private void CbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarDatas();
        }

        private void BtnRelatorio_Click(object sender, EventArgs e)
        {
            Program.IdReserva = id;
            Relatorios.FrmRelatorioDetalhesReserva Form = new Relatorios.FrmRelatorioDetalhesReserva();
            Form.Show();
        }
    }
}
