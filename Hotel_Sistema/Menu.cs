using Hotel_Sistema.Cadastros;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Sistema
{
    public partial class FrmMenu : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string TotalReserva;
        string TotalQuartosDisponiveis;
        string TotalQuartosOcupados;
        string TotalQuartos;

        Int32 TotalCheckIn;
        Int32 TotalChecOut;

        string id;
        string pago;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FormatarDGCheckin()
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
            Grid.Columns[5].Visible = false;
            Grid.Columns[8].Visible = false;
            Grid.Columns[9].Visible = false;
            Grid.Columns[10].Visible = false;
            Grid.Columns[12].Visible = false;
            Grid.Columns[13].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[5].DefaultCellStyle.Format = "C2";


        }


        private void FormatarDGCheckout()
        {
            Grid2.Columns[0].HeaderText = "ID";
            Grid2.Columns[1].HeaderText = "Quarto";
            Grid2.Columns[2].HeaderText = "Data Entrada";
            Grid2.Columns[3].HeaderText = "Data Saída";
            Grid2.Columns[4].HeaderText = "Dias";
            Grid2.Columns[5].HeaderText = "Valor";
            Grid2.Columns[6].HeaderText = "Nome";
            Grid2.Columns[7].HeaderText = "Telefone";
            Grid2.Columns[8].HeaderText = "Data";
            Grid2.Columns[9].HeaderText = "Funcionário";
            Grid2.Columns[10].HeaderText = "Status";
            Grid2.Columns[11].HeaderText = "Check-In";
            Grid2.Columns[12].HeaderText = "Check-out";
            Grid2.Columns[13].HeaderText = "Pago";

            Grid2.Columns[0].Visible = false;
            Grid2.Columns[5].Visible = false;
            Grid2.Columns[8].Visible = false;
            Grid2.Columns[9].Visible = false;
            Grid2.Columns[10].Visible = false;
            Grid2.Columns[11].Visible = false;
            Grid2.Columns[13].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid2.Columns[5].DefaultCellStyle.Format = "C2";


        }


        private void ListarCheckin()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where entrada = curDate() and status = @status and checkin = @checkin order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkin", "Não");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDGCheckin();
        }

        private void ListarCheckout()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where entrada = curDate() and status = @status and checkout = @checkout order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkout", "Não");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid2.DataSource = dt;
            con.FecharConnection();

            FormatarDGCheckout();
        }



        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            PnlTopo.BackColor = Color.FromArgb(230, 230, 230);
            PnlRight.BackColor = Color.FromArgb(130, 130, 130);

            LblUsuario.Text = Program.NomeUsuario;
            LblCargo.Text = Program.CargoUsuario;
            LblData.Text = DateTime.Today.ToString("dd/MM/yyyy");
            LblHora.Text = DateTime.Now.ToString("HH:mm:ss");

            VerificarNivelUsuario();

        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmFuncionarios Form = new Cadastros.FrmFuncionarios();
            Form.Show();
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmCargo Form = new Cadastros.FrmCargo();
            Form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produtos.FrmProdutos Form = new Produtos.FrmProdutos();
            Form.Show();
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produtos.FrmProdutos Form = new Produtos.FrmProdutos();
            Form.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmUsuarios Form = new Cadastros.FrmUsuarios();
            Form.Show();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmFornecedores Form = new Cadastros.FrmFornecedores();
            Form.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produtos.FrmEstoque Form = new Produtos.FrmEstoque();
            Form.Show();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmServicos Form = new Cadastros.FrmServicos();
            Form.Show();
        }

        private void relatórioDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelProdutos Form = new Relatorios.FrmRelProdutos();
            Form.Show();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movimentacoes.FrmVendas Form = new Movimentacoes.FrmVendas();
            Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Movimentacoes.FrmVendas Form = new Movimentacoes.FrmVendas();
            Form.Show();
        }

        private void relatórioDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelatorioVendas Form = new Relatorios.FrmRelatorioVendas();
            Form.Show();
        }

        private void entradasESaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movimentacoes.FrmMovimentacoes Form = new Movimentacoes.FrmMovimentacoes();
            Form.Show();
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movimentacoes.FrmGastos Form = new Movimentacoes.FrmGastos();
            Form.Show();
        }

        private void hóspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmHospedes Form = new Cadastros.FrmHospedes();
            Form.Show();
        }

        private void quartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmQuarto Form = new Cadastros.FrmQuarto();
            Form.Show();
        }

        private void novoServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movimentacoes.FrmNovoServico Form = new Movimentacoes.FrmNovoServico();
            Form.Show();
        }

        private void relatórioDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelatorioServico Form = new Relatorios.FrmRelatorioServico();
            Form.Show();
        }

        private void relatórioDeMovimentaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelatorioMovimentacoes Form = new Relatorios.FrmRelatorioMovimentacoes();
            Form.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.FrmMovimentacoesGerais Form = new Relatorios.FrmMovimentacoesGerais();
            Form.Show();
        }

        private void novaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas.FrmReservas Form = new Reservas.FrmReservas();
            Form.Show();
        }

        private void quadroDeReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas.FrmConsultarReservas Form = new Reservas.FrmConsultarReservas();
            Form.Show();
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas.FrmCheckin Form = new Reservas.FrmCheckin();
            Form.Show();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas.FrmCheckOut Form = new Reservas.FrmCheckOut();
            Form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void BuscarReservaDia()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where data = @data and status = @status";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            TotalReserva = dt.Rows.Count.ToString();
            LblReservas.Text = TotalReserva;
            con.FecharConnection();
        }

        private void BuscarQuartosDisponíveis()
        {
            con.AbrirConnection();
            sql = "SELECT * from ocupacoes where data = @data";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            TotalQuartosDisponiveis = dt.Rows.Count.ToString();

            //BUSCAR TOTAL DE QUARTOS
            sql = "SELECT * from quartos";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da2 = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            TotalQuartos = dt2.Rows.Count.ToString();
            double Total;
            Total = Convert.ToDouble(TotalQuartos) - Convert.ToDouble(TotalQuartosDisponiveis);


            LblRoomAvailable.Text = Total.ToString();
            con.FecharConnection();
        }
        private void BuscarQuartosOcupados()
        {
            con.AbrirConnection();
            sql = "SELECT * from ocupacoes where data = @data";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            TotalQuartosOcupados = dt.Rows.Count.ToString();
            LblRoomUnavailable.Text = TotalQuartosOcupados;
            con.FecharConnection();
        }

        private void FrmMenu_Activated(object sender, EventArgs e)
        {
            BuscarReservaDia();
            BuscarQuartosDisponíveis();
            BuscarQuartosOcupados();
            BuscarTotalCheckIn();
            BuscarTotalCheckOut();
            VerificarEstoque();

            ListarCheckin();
            ListarCheckout();
        }

        private void BuscarTotalCheckIn()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where entrada = @data and status = @status";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            TotalCheckIn = dt.Rows.Count;
            LblCheckIn.Text = TotalCheckIn.ToString();
            con.FecharConnection();
        }

        private void BuscarTotalCheckOut()
        {
            con.AbrirConnection();
            sql = "SELECT * from reservas where saida = @data and status = @status";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", DateTime.Today);
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            TotalChecOut = dt.Rows.Count;
            LblCheckOut.Text = TotalChecOut.ToString();
            con.FecharConnection();
        }

        private void VerificarEstoque()
        {
            con.AbrirConnection();
            sql = "SELECT * from produtos where estoque < @estoque";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@estoque", 15);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count < 15)
            {
                LblEstoque.Text = "ESTOQUE BAIXO!";
                PibEstoque.Image = Properties.Resources.baixo;
            }
            else
            {
                LblEstoque.Text = "ESTOQUE BOM";
                PibEstoque.Image = Properties.Resources.bom;
            }

            con.FecharConnection();
        }


        private void estoqueBaixoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produtos.FrmEstoquebaixo Form = new Produtos.FrmEstoquebaixo();
            Form.Show();
        }

        private void LblEstoque_Click(object sender, EventArgs e)
        {
            Produtos.FrmEstoquebaixo Form = new Produtos.FrmEstoquebaixo();
            Form.Show();
        }

        private void PibEstoque_Click(object sender, EventArgs e)
        {
            Produtos.FrmEstoquebaixo Form = new Produtos.FrmEstoquebaixo();
            Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservas.FrmConsultarReservas Form = new Reservas.FrmConsultarReservas();
            Form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reservas.FrmReservas Form = new Reservas.FrmReservas();
            Form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reservas.FrmCheckin Form = new Reservas.FrmCheckin();
            Form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reservas.FrmCheckOut Form = new Reservas.FrmCheckOut();
            Form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelatorioMovimentacoes Form = new Relatorios.FrmRelatorioMovimentacoes();
            Form.Show();
        }

        private void VerificarNivelUsuario()
        {
            if (LblCargo.Text == "Gerente")
            {
                MsFuncionarios.Enabled = true;
                MsQuartos.Enabled = true;
                MsServicos.Enabled = true;
                MsUsuarios.Enabled = true;
                MsCargos.Enabled = true;
                MsEntradasESaidas.Enabled = true;
            }

        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAddCheckIn.Enabled = true;

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            pago = Grid.CurrentRow.Cells[13].Value.ToString();
        }

        private void BtnAddCheckIn_Click(object sender, EventArgs e)
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
                ListarCheckin();
                BtnAddCheckIn.Enabled = false;


            }
            else
            {
                MessageBox.Show("Você precisa antes confirmar o pagamento!");
                BtnAddCheckIn.Enabled = false;
            }
        }

        private void Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAddCheckout.Enabled = true;

            id = Grid2.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnAddCheckout_Click(object sender, EventArgs e)
        {
            con.AbrirConnection();
            sql = "UPDATE reservas SET checkout = @checkout where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@checkout", "Sim");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();
            ListarCheckout();
            BtnAddCheckout.Enabled = false;

            con.AbrirConnection();
            sql = "DELETE FROM ocupacoes WHERE id_reserva = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.FecharConnection();
        }

        private void limparDadosReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 ano;
            DateTime Data = DateTime.Now;
            ano = Data.Year - 1;

            var resultado = MessageBox.Show("Deseja Realmente Limpar todas as reservas de ", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
            }
        }

        private void backUpDoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void Backup()
        {
            string constring = con.conect;  //"server=localhost;user=root;pwd=;database=hotel;";

            // Important Additional Connection Options
            constring += "charset=utf8;convertzerodatetime=true;";
            string Data = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
            string file = "backup/backup-" + Data + ".sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }

            MessageBox.Show("Backup efetuado - Data: " + Data, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
