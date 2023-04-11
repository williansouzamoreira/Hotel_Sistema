using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Sistema.Produtos
{
    public partial class FrmProdutos : Form
    {
        string foto;
        string alterou;

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;


        public FrmProdutos()
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


        private void Listar() //Listando os dados da tabela Cargos, do BD
        {
            con.AbrirConnection();
            sql = "SELECT pro.id, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.fornecedor FROM produtos as pro INNER JOIN fornecedores as forn ON pro.fornecedor = forn.id order by pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter(); //Instanciando uma variável MySQL
            da.SelectCommand = cmd; //Recuperando as informações do SQL no adapter
            DataTable dt = new DataTable();
            da.Fill(dt); //Inserindo informações adapatadas no DataTable (propriedade da Grid)
            Grid.DataSource = dt; //Exibindo as informações no DataGrid
            con.FecharConnection();

            FormatarDG();
        }

        private void BuscarNome() // ==>Código comentado no método Listar
        {
            con.AbrirConnection();
            sql = "SELECT pro.id, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.fornecedor FROM produtos as pro INNER JOIN fornecedores as forn ON pro.fornecedor = forn.id WHERE pro.nome LIKE @nome order by pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtBuscar.Text + "%");
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.FecharConnection();

            FormatarDG();
        }
        
        private void CarregarComboBox()
        {
            con.AbrirConnection();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CbFornecedor.DataSource = dt;
            CbFornecedor.ValueMember = "id";
            CbFornecedor.DisplayMember = "nome"; 

            con.FecharConnection();
        }


        private void habilitarCampos()
        {
            TxtNome.Enabled = true;
            TxtDescricao.Enabled = true;
            TxtValor.Enabled = true;
            //TxtEstoque.Enabled = true;
            CbFornecedor.Enabled = true;
            BtnImg.Enabled = true;
            TxtNome.Focus();
        }

        private void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtDescricao.Enabled = false;
            TxtValor.Enabled = false;
            TxtEstoque.Enabled = false;
            CbFornecedor.Enabled = false;
            BtnImg.Enabled = false;
        }
        private void limparCampos()
        {
            TxtNome.Text = "";
            TxtDescricao.Text = "";
            TxtValor.Text = "";
            TxtEstoque.Text = "";
            LimparFoto();
        }


        private void LimparFoto()
        {
            Img.Image = Properties.Resources.sem_foto;
            foto = "img/sem-foto.jpg";
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            LimparFoto();
            CarregarComboBox();
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            if (CbFornecedor.Text == "")
            {
                MessageBox.Show("Cadastre, Antes, um Fornecedor!");
                Close();
            }
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                return;
            }

            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO SALVAR

            con.AbrirConnection();
            sql = "INSERT INTO produtos (nome, descricao, fornecedor, valor_venda, data, imagem) VALUES (@nome, @descricao, @fornecedor, @valor_venda, curDate(), @imagem)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@descricao", TxtDescricao.Text);
            //cmd.Parameters.AddWithValue("@estoque", TxtEstoque.Text);
            cmd.Parameters.AddWithValue("@fornecedor", CbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@valor_venda", TxtValor.Text.Replace(",", "."));//Replace -> Fazendo com que o sistema reconheça a virguala como ponto, (No BD não recohece virgula esta é uma gabiruzação).
            cmd.Parameters.AddWithValue("@imagem", ImgProdutos());

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

            if (TxtNome.Text.ToString().Trim() == "")
            {
                TxtNome.Text = "";
                MessageBox.Show("Preencha o Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Focus();
                return;
            }

            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO EDITAR
            con.AbrirConnection();

            if (alterou == "1")
            {
                sql = "UPDATE produtos SET nome = @nome, descricao = @descricao, fornecedor = @fornecedor, valor_venda = @valor, imagem = @imagem where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@imagem", ImgProdutos());
            }
            else
            {
                sql = "UPDATE produtos SET nome = @nome, descricao = @descricao, fornecedor = @fornecedor, valor_venda = @valor where id = @id";
                cmd = new MySqlCommand(sql, con.con);

            }
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@descricao", TxtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@fornecedor", CbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharConnection();

            MessageBox.Show("Registro Alterado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
            alterou = "0";

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excuir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO EXCLUIR ==> Código comentado no Form Cargo

                con.AbrirConnection();
                sql = "DELETE FROM produtos WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConnection();


                MessageBox.Show("Registro Excluído com Sucesso!", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                limparCampos();
                desabilitarCampos();
                Listar();
            }
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Arquivos de Imagens (*.jpg;*.png) |*.jpg;*.png| Todos os Arquivos (*.*)|*.*";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                foto = Dialog.FileName.ToString();
                Img.ImageLocation = foto;
                alterou = "1";
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
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtDescricao.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtEstoque.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            CbFornecedor.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            TxtValor.Text = Grid.CurrentRow.Cells[5].Value.ToString();

            if (Grid.CurrentRow.Cells[8].Value != DBNull.Value)
            {
                byte[] imagem = (byte[])Grid.CurrentRow.Cells[8].Value; //O VALOR (byte[]) É APENAS CONVERSÃO DOS DADOS PARA O TIPO BYTE
                MemoryStream ms = new MemoryStream(imagem);
                Img.Image = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                Img.Image = Properties.Resources.sem_foto;
            }

            

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Program.ChamadaProdutos == "estoque")
            {
                Program.NomeProduto = Grid.CurrentRow.Cells[1].Value.ToString();
                Program.EstoqueProduto = Grid.CurrentRow.Cells[3].Value.ToString();
                Program.ValorProduto = Grid.CurrentRow.Cells[5].Value.ToString();
                Program.IdProduto = Grid.CurrentRow.Cells[0].Value.ToString();

                Close();
            }
        }


        //CÓDIGO PARA SUBIR IMAGEM PARA O BANCO DE DADOS (ESTE CÓDIGO É PADRÃO)
        private byte[] ImgProdutos() //MÉTODO DO TIPO BYTE PARA ARMAZENAMENTO DA IMAGEM DO PRODUTO.
        {
            byte[] imagem_byte = null;  //DECLARANDO UMA VARIÁVELD O TIPO BYTE PARA RECEBER A IMAGEM.

            if (foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagem_byte = br.ReadBytes((int)fs.Length);
            return imagem_byte;
        }
    }
}
