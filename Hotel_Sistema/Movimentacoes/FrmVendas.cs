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
    public partial class FrmVendas : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;

        string idvenda;
        string iddetalhesvenda = "";
        string idProdutoExclusao;
        String totalVenda = "0";
        string ultimoIDvenda;
        string exclusaoVenda;

        public FrmVendas()
        {
            InitializeComponent();
        }

        private void FormatarDGVendas()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Valor total";
            Grid.Columns[2].HeaderText = "Funcionário";
            Grid.Columns[3].HeaderText = "Status";
            Grid.Columns[4].HeaderText = "Data";

            Grid.Columns[0].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            Grid.Columns[1].DefaultCellStyle.Format = "C2";


        }


        private void ListarVendas() 
        {
            con.AbrirConnection();
            sql = "SELECT * from vendas order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter(); 
            da.SelectCommand = cmd; 
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt; 
            con.FecharConnection();

            FormatarDGVendas();
            GridDetalhes.Visible = false;
        }

        private void FormatarDGDetalhesVendas()
        {
            GridDetalhes.Columns[0].HeaderText = "ID";
            GridDetalhes.Columns[1].HeaderText = "Código Venda";
            GridDetalhes.Columns[2].HeaderText = "Produto";
            GridDetalhes.Columns[3].HeaderText = "Quantidade";
            GridDetalhes.Columns[4].HeaderText = "Valor Unitário";
            GridDetalhes.Columns[5].HeaderText = "Valor Total";
            GridDetalhes.Columns[6].HeaderText = "Funcionário";
            GridDetalhes.Columns[7].HeaderText = "ID Produto";

            GridDetalhes.Columns[0].Visible = false;
            GridDetalhes.Columns[1].Visible = false;
            GridDetalhes.Columns[7].Visible = false;

            //FORMATANDO PARA FORMATO DE MOEDA
            GridDetalhes.Columns[4].DefaultCellStyle.Format = "C2";
            GridDetalhes.Columns[5].DefaultCellStyle.Format = "C2";

        }


        private void ListarDetalhesVendas() //Listando os dados da tabela Cargos, do BD
        {
            con.AbrirConnection();
            sql = "SELECT * from detalhes_venda where id_venda = @id_venda and funcionario = @funcionario";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", "0");
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            MySqlDataAdapter da = new MySqlDataAdapter(); 
            da.SelectCommand = cmd; 
            DataTable dt = new DataTable();
            da.Fill(dt); 
            GridDetalhes.DataSource = dt; 
            con.FecharConnection();

            FormatarDGDetalhesVendas();
            GridDetalhes.Visible = true;

        }


        private void habilitarCampos()
        {
            //TxtProduto.Enabled = true;
            TxtQuantidade.Enabled = true;
            //TxtEstoque.Enabled = true;
            //TxtValor.Enabled = true;
            BtnProduto.Enabled = true;
            TxtQuantidade.Focus();
            BtnAdd.Enabled = true;
            BtnRemove.Enabled = true;
        }

        private void desabilitarCampos()
        {
            TxtProduto.Enabled = false;
            TxtQuantidade.Enabled = false;
            TxtEstoque.Enabled = false;
            TxtValor.Enabled = false;
            BtnProduto.Enabled = false;
            BtnAdd.Enabled = false;
            BtnRemove.Enabled = false;
        }
        private void limparCampos()
        {
            TxtProduto.Text = "";
            TxtQuantidade.Text = "";
            TxtValor.Text = "";
            TxtEstoque.Text = "";
            LblTotal.Text = "0";
        }



        private void BuscarData() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT * FROM vendas WHERE data = @data order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DtBuscar.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDGVendas();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            totalVenda = "0";
            ListarVendas();
            desabilitarCampos();
            DtBuscar.Value = DateTime.Today;
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (LblTotal.Text == "0")
            {

                MessageBox.Show("É necessário inserir produtos para venda", "Venda Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            con.AbrirConnection();
            sql = "INSERT INTO vendas(valor_total, funcionario, status, data) VALUES (@valor_total, @funcionario, @status, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@valor_total", totalVenda.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@status", "Efetuada");

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //RECUPERAR O ULTIMO ID DA VENDA
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirConnection();
            FrmMenu form = new FrmMenu();
            cmdVerificar = new MySqlCommand("SELECT id FROM vendas order by id desc LIMIT 1", con.con);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA
                while (reader.Read())
                {
                    ultimoIDvenda = Convert.ToString(reader["id"]);
                }
            }

            //SALVAR VENDAS NA TABELA MOVIMENTAÇÕES
            con.AbrirConnection();
            sql = "INSERT INTO movimentacoes(tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Venda");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(totalVenda));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIDvenda);

            cmd.ExecuteNonQuery();
            con.FecharConnection();


            //RELACIONAR OS ITENS COM A VENDA.
            con.AbrirConnection();
            sql = "UPDATE detalhes_venda set id_venda = @id_venda where id_venda = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("id", "0");
            cmd.Parameters.AddWithValue("id_venda", ultimoIDvenda);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Venda Salva com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            ListarVendas();
            totalVenda = "0";
        }

        private void BtnProduto_Click(object sender, EventArgs e)
        {

            Program.ChamadaProdutos = "estoque";
            Produtos.FrmProdutos Form = new Produtos.FrmProdutos();
            Form.Show();
        }

        private void FrmVendas_Activated(object sender, EventArgs e)
        {
            TxtEstoque.Text = Program.EstoqueProduto;
            TxtProduto.Text = Program.NomeProduto;
            TxtValor.Text = Program.ValorProduto;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtQuantidade.Text.ToString().Trim() == "")
            {
                TxtQuantidade.Text = "";
                MessageBox.Show("Preencha a quantidade", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQuantidade.Focus();
                return;
            }

            if (Convert.ToDouble(TxtQuantidade.Text) > Convert.ToDouble(TxtEstoque.Text))
            {
                MessageBox.Show("Não possui produtos suficiente em estoque", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQuantidade.Focus();
                return;
            }

            con.AbrirConnection();
            sql = "INSERT INTO detalhes_venda (id_venda, produto, quantidade, valor_unitario, valor_total, funcionario, id_produto) VALUES (@id_venda, @produto, @quantidade, @valor_unitario, @valor_total, @funcionario, @idproduto)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", "0");
            cmd.Parameters.AddWithValue("@produto", TxtProduto.Text);
            cmd.Parameters.AddWithValue("@quantidade", TxtQuantidade.Text);
            cmd.Parameters.AddWithValue("@valor_unitario", Convert.ToDouble(TxtValor.Text));
            cmd.Parameters.AddWithValue("@valor_total", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.Parameters.AddWithValue("@idproduto", Program.IdProduto);

            cmd.ExecuteNonQuery();
            con.FecharConnection();



            //ABATENDO PRODUTO NO ESTOQUE
            con.AbrirConnection();
            sql = "UPDATE produtos set estoque = @estoque where id = @idproduto";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("idproduto", Program.IdProduto);
            cmd.Parameters.AddWithValue("estoque", Convert.ToInt32(TxtEstoque.Text) - Convert.ToInt32(TxtQuantidade.Text));

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            double total;
            total = Convert.ToDouble(totalVenda) + (Convert.ToDouble(TxtQuantidade.Text) * Convert.ToDouble(TxtValor.Text));
            totalVenda = total.ToString();
            LblTotal.Text = string.Format("{0:c2}", totalVenda);  //Convertento para o tipo moeda

            TxtQuantidade.Text = "";
            TxtProduto.Text = "";
            TxtValor.Text = "";
            TxtEstoque.Text = "0";
            iddetalhesvenda = "";
            ListarDetalhesVendas();

        }

        private void GridDetalhes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //RECUPERANDO O ID DA VENDA PARA O BOTÃO EXCLUIR
            iddetalhesvenda = GridDetalhes.CurrentRow.Cells[0].Value.ToString();
            idProdutoExclusao = GridDetalhes.CurrentRow.Cells[7].Value.ToString();


            //RECUPERANDO OS DADOS E EXIBINDO NOS CAMPOS, PARA CONFERÊNCIA ANTES DA EXCLUSÃO
            TxtProduto.Text = GridDetalhes.CurrentRow.Cells[2].Value.ToString();
            TxtQuantidade.Text = GridDetalhes.CurrentRow.Cells[3].Value.ToString();
            TxtValor.Text = GridDetalhes.CurrentRow.Cells[4].Value.ToString();


            //RECUPERANDO O TOTAL DO ESTOQUE
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirConnection();
            FrmMenu form = new FrmMenu(); //Instanciando o elemento (inicializando) - form é o nome do elemento.
            cmdVerificar = new MySqlCommand("SELECT * FROM produtos WHERE id = @id", con.con);
            cmdVerificar.Parameters.AddWithValue("@id", idProdutoExclusao);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA
                while (reader.Read())
                {
                    TxtEstoque.Text = Convert.ToString(reader["estoque"]);
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (iddetalhesvenda == "")
            {
                MessageBox.Show("Selecione o produto a ser excluído", "Selecione o Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            con.AbrirConnection();
            sql = "DELETE FROM detalhes_venda where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("id", iddetalhesvenda);

            cmd.ExecuteNonQuery();
            con.FecharConnection();


            //DEVOLVENDO PRODUTO AO ESTOQUE
            con.AbrirConnection();
            sql = "UPDATE produtos set estoque = @estoque where id = @idproduto";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("idproduto", idProdutoExclusao);
            cmd.Parameters.AddWithValue("estoque", Convert.ToInt32(TxtEstoque.Text) + Convert.ToInt32(TxtQuantidade.Text));

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            //TOTAL DA VENDA
            double total;
            total = Convert.ToDouble(totalVenda) - (Convert.ToDouble(TxtQuantidade.Text) * Convert.ToDouble(TxtValor.Text));
            totalVenda = total.ToString();
            LblTotal.Text = string.Format("{0:c2}", totalVenda);

            TxtQuantidade.Text = "";
            TxtProduto.Text = "";
            TxtValor.Text = "";
            iddetalhesvenda = "";

            if (exclusaoVenda == "1")
            {
                BuscarDetalhesVendas();
            }
            else
            {
                ListarDetalhesVendas();
            }
            

        }


        private void FrmVendas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (totalVenda != "0")
            {
                MessageBox.Show("A venda possui itens, favor remover antes de sair!");
                e.Cancel = true;
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idvenda = Grid.CurrentRow.Cells[0].Value.ToString();
            Program.IdVendaGL = Grid.CurrentRow.Cells[0].Value.ToString(); //Recuperar o ID para utilizar no relatório.
            totalVenda = Grid.CurrentRow.Cells[1].Value.ToString();
            LblTotal.Text = string.Format("{0:c2}", totalVenda);
            BuscarDetalhesVendas();
            BtnFechar.Visible = true;
            BtnAdd.Enabled = true;
            BtnRemove.Enabled = true;
            BtnExcluir.Enabled = true;
            exclusaoVenda = "1";
            BtnRelatorio.Enabled = true;

        }

        private void BuscarDetalhesVendas()
        {
            con.AbrirConnection();
            sql = "SELECT * from detalhes_venda where id_venda = @id_venda";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", idvenda);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridDetalhes.DataSource = dt;
            con.FecharConnection();

            FormatarDGDetalhesVendas();
            GridDetalhes.Visible = true;
            

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            GridDetalhes.Visible = false;
            BtnFechar.Visible = false;
            
            LblTotal.Text = "0";
            totalVenda = "0";
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (totalVenda == "0")
            {
                var resultado = MessageBox.Show("Deseja Realmente Cancelar a Venda?", "Cancelar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO EXCLUIR ==> Código comentado no Form Cargo

                    con.AbrirConnection();
                    sql = "UPDATE vendas SET status = @status WHERE id = @id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@status", "Cancelada");
                    cmd.Parameters.AddWithValue("@id", idvenda);
                    cmd.ExecuteNonQuery();
                    con.FecharConnection();


                    MessageBox.Show("Venda Cancelada com Sucesso!", "Registro Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnNovo.Enabled = true;
                    BtnExcluir.Enabled = false;
                    limparCampos();
                    desabilitarCampos();
                    ListarVendas();

                    LblTotal.Text = "0";
                    totalVenda = "0";
                    exclusaoVenda = "";

                    //EXCLUSÃO DO MOVIMENTO DA VENDA
                    con.AbrirConnection();
                    sql = "DELETE FROM movimentacoes WHERE id_movimento = @id and movimento = @movimento";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", idvenda);
                    cmd.Parameters.AddWithValue("@movimento", "Venda");
                    cmd.ExecuteNonQuery();
                    con.FecharConnection();

                }

            }
            else
            {
                MessageBox.Show("Você precisa antes, excluir todos os itens da venda!!");
            }



        }

        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void BtnRelatorio_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelatorioComprovante Form = new Relatorios.FrmRelatorioComprovante();
            Form.Show();
        }
    }
}