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
    public partial class FrmNovoServico : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;

        string ultimoIDservico;
        string ValorServico;

        string id;

        public FrmNovoServico()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Hóspede";
            Grid.Columns[2].HeaderText = "Serviço";
            Grid.Columns[3].HeaderText = "Quarto";
            Grid.Columns[4].HeaderText = "Valor";
            Grid.Columns[5].HeaderText = "Funcionário";
            Grid.Columns[6].HeaderText = "Data";


            Grid.Columns[0].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[4].DefaultCellStyle.Format = "C2";

        }

        private void Listar()
        {
            con.AbrirConnection();
            sql = "SELECT * from novo_servico order by data asc";
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
            TxtHospede.Enabled = true;
            TxtQuantidade.Enabled = true;
            TxtValor.Enabled = true;
            BtnHospede.Enabled = true;
            CbQuarto.Enabled = true;
            TxtQuantidade.Focus();
        }

        private void desabilitarCampos()
        {
            TxtHospede.Enabled = false;
            TxtQuantidade.Enabled = false;
            TxtValor.Enabled = false;
            BtnHospede.Enabled = false;
            CbQuarto.Enabled = false;
            TxtQuantidade.Focus();
        }
        private void limparCampos()
        {
            TxtHospede.Text = "";
            TxtQuantidade.Text = "";
            TxtValor.Text = "";
        }

        private void BuscarData() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM novo_servico WHERE data = @data order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtBuscar.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }

        private void CarregarComboBoxServicos() 
        {
            con.AbrirConnection();
            sql = "SELECT * FROM servicos order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Cbservico.DataSource = dt; 
            Cbservico.DisplayMember = "nome"; 

            con.FecharConnection();
        }


        private void CarregarComboBoxQuarto()
        {
            con.AbrirConnection();
            sql = "SELECT * FROM quartos order by quarto asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CbQuarto.DataSource = dt;
            CbQuarto.DisplayMember = "quarto";

            con.FecharConnection();
        }
        private void FrmServicos_Load(object sender, EventArgs e)
        {
            Listar();
            desabilitarCampos();
            DtBuscar.Value = DateTime.Today;
            CarregarComboBoxQuarto();
            CarregarComboBoxServicos();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (Cbservico.Text == "")
            {
                MessageBox.Show("Cadastre, Antes, um Serviço!");
                Close();
            }
            if (CbQuarto.Text == "")
            {
                MessageBox.Show("Cadastre, Antes, um Quarto!");
                Close();
            }
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (Cbservico.Text == "0")
            {

                MessageBox.Show("É necessário inserir um serviço!", "Venda Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            con.AbrirConnection();
            sql = "INSERT INTO novo_servico (hospede, servico, quarto, valor, funcionario, data) VALUES (@hospede, @servico, @quarto, @valor, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);            
            cmd.Parameters.AddWithValue("@hospede", TxtHospede.Text) ;
            cmd.Parameters.AddWithValue("@servico", Cbservico.Text);
            cmd.Parameters.AddWithValue("@quarto", CbQuarto.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //RECUPERAR O ULTIMO ID DO SERVIÇO
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirConnection();
            FrmMenu form = new FrmMenu();
            cmdVerificar = new MySqlCommand("SELECT id FROM novo_servico order by id desc LIMIT 1", con.con);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA
                while (reader.Read())
                {
                    ultimoIDservico = Convert.ToString(reader["id"]);
                }
            }

            //SALVAR VENDAS NA TABELA MOVIMENTAÇÕES
            con.AbrirConnection();
            sql = "INSERT INTO movimentacoes(tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Serviço");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIDservico);

            cmd.ExecuteNonQuery();
            con.FecharConnection();


            MessageBox.Show("Serciço Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnHospede_Click(object sender, EventArgs e)
        {
            Program.ChamadaHospedes = "hospedes";
            Cadastros.FrmHospedes Form = new Cadastros.FrmHospedes();
            Form.Show();
        }

        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void FrmNovoServico_Activated(object sender, EventArgs e)
        {
            TxtHospede.Text = Program.NomeHospede;
        }

        private void Cbservico_SelectedValueChanged(object sender, EventArgs e)
        {
            MySqlDataReader reader;
            con.AbrirConnection();
            FrmMenu form = new FrmMenu(); //Instanciando o elemento (inicializando) - form é o nome do elemento.
            cmdVerificar = new MySqlCommand("SELECT * FROM servicos WHERE nome = @nome", con.con);
            cmdVerificar.Parameters.AddWithValue("@nome", Cbservico.Text);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DO LOGIN
                while (reader.Read())
                {
                    ValorServico = Convert.ToString(reader["valor"]);
                }

                TxtValor.Text = ValorServico;
            }

            con.FecharConnection();

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {

            if (Program.CargoUsuario == "Gerente")
            {
                var resultado = MessageBox.Show("Deseja Realmente Excuir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO EXCLUIR ==> Código comentado no Form Cargo

                    con.AbrirConnection();
                    sql = "DELETE FROM novo_servico WHERE id = @id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.FecharConnection();


                    MessageBox.Show("Registro Excluído com Sucesso!", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //EXCLUSÃO DO MOVIMENTO DO SERVIÇO
                    con.AbrirConnection();
                    sql = "DELETE FROM movimentacoes WHERE id_movimento = @id and movimento = @movimento";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@movimento", "Serviço");
                    cmd.ExecuteNonQuery();
                    con.FecharConnection();

                    BtnNovo.Enabled = true;           
                    BtnExcluir.Enabled = false;
                    limparCampos();
                    habilitarCampos();
                    Listar();
                }
                else
                {
                    MessageBox.Show("Somente um Gerente tem permissão para excluir um serviço!", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            BtnNovo.Enabled = true;
            BtnRelatorio.Enabled = true;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();

            Program.idNovoServico = id;
        }

        private void BtnRelatorio_Click(object sender, EventArgs e)
        {
            BtnRelatorio.Enabled = false;
            Relatorios.FrmComprovanteServicos Form = new Relatorios.FrmComprovanteServicos();
            Form.Show();


        }
    }
}
