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
    public partial class FrmReservas : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        MySqlCommand cmdVerificar;
        string id;

        string ValorQuarto;
        int mes;
        string DataPainel;

        Int32 DiasMes;

        string ultimoIDreserva;

        string DataInicial;
        string DataFinal;

        double DiasReserva;
        double ValorTotal;

        public FrmReservas()
        {
            InitializeComponent();
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


        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Quarto";
            Grid.Columns[2].HeaderText = "Data";
            Grid.Columns[3].HeaderText = "Funcionário";
            Grid.Columns[4].HeaderText = "ID Reserva";


            Grid.Columns[0].Visible = false;
            Grid.Columns[3].Visible = false;
            Grid.Columns[4].Visible = false;
        }


        private void Listar() //Listando os dados da tabela Cargos, do BD
        {
            con.AbrirConnection();
            sql = "SELECT * FROM ocupacoes where id_reserva =@id and funcionario = @funcionario order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", "0");
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
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
            TxtNome.Enabled = true;
            TxtValorDiaria.Enabled = true;
            TxtTelefone.Enabled = true;
            CbQuarto.Enabled = true;
            CbMes.Enabled = true;
            CbAno.Enabled = true;
            TxtNome.Focus();
        }

        private void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtDias.Enabled = false;
            TxtValorDiaria.Enabled = false;
            TxtTelefone.Enabled = false;
            CbQuarto.Enabled = false;
            CbMes.Enabled = false;
            CbAno.Enabled = false;
            BtnRemove.Enabled = false;

        }
        private void limparCampos()
        {
            TxtNome.Text = "";
            TxtDias.Text = "";
            TxtTelefone.Text = "";
        }

        private void LimparOcupacoes()
        {
            pnl1.BackColor = Color.PaleGreen;
            pnl1.Enabled = true;
           
            pnl2.BackColor = Color.PaleGreen;
            pnl2.Enabled = true;

            pnl3.BackColor = Color.PaleGreen;
            pnl3.Enabled = true;
            
            pnl4.BackColor = Color.PaleGreen;
            pnl4.Enabled = true;
           
            pnl5.BackColor = Color.PaleGreen;
            pnl5.Enabled = true;

            pnl6.BackColor = Color.PaleGreen;
            pnl6.Enabled = true;
           
            pnl7.BackColor = Color.PaleGreen;
            pnl7.Enabled = true;
            
            pnl8.BackColor = Color.PaleGreen;
            pnl8.Enabled = true;
            
            pnl9.BackColor = Color.PaleGreen;
            pnl9.Enabled = true;
            
            pnl10.BackColor = Color.PaleGreen;
            pnl10.Enabled = true;
             
            pnl11.BackColor = Color.PaleGreen;
            pnl11.Enabled = true;
             
            pnl12.BackColor = Color.PaleGreen;
            pnl12.Enabled = true;
            
            pnl13.BackColor = Color.PaleGreen;
            pnl13.Enabled = true;
          
            pnl14.BackColor = Color.PaleGreen;
            pnl14.Enabled = true;
            
            pnl15.BackColor = Color.PaleGreen;
            pnl15.Enabled = true;
             
            pnl16.BackColor = Color.PaleGreen;
            pnl16.Enabled = true;
             
            pnl17.BackColor = Color.PaleGreen;
            pnl17.Enabled = true;
             
            pnl18.BackColor = Color.PaleGreen;
            pnl18.Enabled = true;
          
            pnl19.BackColor = Color.PaleGreen;
            pnl19.Enabled = true;
            
            pnl20.BackColor = Color.PaleGreen;
            pnl20.Enabled = true;
          
            pnl21.BackColor = Color.PaleGreen;
            pnl21.Enabled = true;
            
            pnl22.BackColor = Color.PaleGreen;
            pnl22.Enabled = true;
             
            pnl23.BackColor = Color.PaleGreen;
            pnl23.Enabled = true;
           
            pnl24.BackColor = Color.PaleGreen;
            pnl24.Enabled = true;
             
            pnl25.BackColor = Color.PaleGreen;
            pnl25.Enabled = true;
             
            pnl26.BackColor = Color.PaleGreen;
            pnl26.Enabled = true;
           
            pnl27.BackColor = Color.PaleGreen;
            pnl27.Enabled = true;
            
            pnl28.BackColor = Color.PaleGreen;
            pnl28.Enabled = true;
            
            pnl29.BackColor = Color.PaleGreen;
            pnl29.Enabled = true;
            
            pnl30.BackColor = Color.PaleGreen;
            pnl30.Enabled = true;
             
            pnl31.BackColor = Color.PaleGreen;
            pnl31.Enabled = true;

        }

        private void VerificarOcupacoes()
        {
            string data;
            Color cor;

            LimparOcupacoes();

            Int32 mes;
            mes = Convert.ToInt32(CbMes.Text);
            con.AbrirConnection();

            for (int i = 1; i <= 31; i += 1)
            {
                if (i < 10)
                {
                    if (mes < 10)
                    {
                        //data = 0 + i.ToString() + "/0" + Convert.ToString(CbMes.Text) + "/" + Convert.ToString(CbAno.Text);
                        data = Convert.ToInt32(CbAno.Text) + "-0" + Convert.ToInt32(CbMes.Text) +"-"+ 0 + i;

                    }
                    else
                    {
                        //data = 0 + i.ToString() + "/" + Convert.ToString(CbMes.Text) + "/" + Convert.ToString(CbAno.Text);
                        data = Convert.ToInt32(CbAno.Text) + "-" + Convert.ToInt32(CbMes.Text) + "-" + 0 + i;
                    }
                    
                }
                else
                {
                    if (mes < 10)
                    {
                        //data = i + "/0" + Convert.ToString(CbMes.Text) + "/" + Convert.ToString(CbAno.Text);
                        data = Convert.ToInt32(CbAno.Text) + "-0" + Convert.ToInt32(CbMes.Text) + "-" + i;
                    }
                    else
                    {
                        //data = i + "/" + Convert.ToString(CbMes.Text) + "/" + Convert.ToString(CbAno.Text);
                        data = Convert.ToInt32(CbAno.Text) + "-" + Convert.ToInt32(CbMes.Text) + "-"+ i;
                    }
                    
                }

                
                sql = "SELECT * FROM ocupacoes where data = @data and quarto = @quarto";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@quarto", CbQuarto.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                if (i == 1 && dt.Rows.Count > 0)
                {
                    pnl1.BackColor = Color.Coral;
                    pnl1.Enabled = false;
                }
                if (i == 2 && dt.Rows.Count > 0)
                {
                    pnl2.BackColor = Color.Coral;
                    pnl2.Enabled = false;
                }
                if (i == 3 && dt.Rows.Count > 0)
                {
                    pnl3.BackColor = Color.Coral;
                    pnl3.Enabled = false;
                }
                if (i == 4 && dt.Rows.Count > 0)
                {
                    pnl4.BackColor = Color.Coral;
                    pnl4.Enabled = false;
                }
                if (i == 5 && dt.Rows.Count > 0)
                {
                    pnl5.BackColor = Color.Coral;
                    pnl5.Enabled = false;
                }
                if (i == 6 && dt.Rows.Count > 0)
                {
                    pnl6.BackColor = Color.Coral;
                    pnl6.Enabled = false;
                }
                if (i == 7 && dt.Rows.Count > 0)
                {
                    pnl7.BackColor = Color.Coral;
                    pnl7.Enabled = false;
                }
                if (i == 8 && dt.Rows.Count > 0)
                {
                    pnl8.BackColor = Color.Coral;
                    pnl8.Enabled = false;
                }
               
                if (i == 9 && dt.Rows.Count > 0)
                {
                    pnl9.BackColor = Color.Coral;
                    pnl9.Enabled = false;
                }
                if (i == 10 && dt.Rows.Count > 0)
                {
                    pnl10.BackColor = Color.Coral;
                    pnl10.Enabled = false;
                }

                if (i == 11 && dt.Rows.Count > 0)
                {
                    pnl11.BackColor = Color.Coral;
                    pnl11.Enabled = false;
                }
                if (i == 12 && dt.Rows.Count > 0)
                {
                    pnl12.BackColor = Color.Coral;
                    pnl12.Enabled = false;
                }
                if (i == 13 && dt.Rows.Count > 0)
                {
                    pnl13.BackColor = Color.Coral;
                    pnl13.Enabled = false;
                }
                if (i == 14 && dt.Rows.Count > 0)
                {
                    pnl14.BackColor = Color.Coral;
                    pnl14.Enabled = false;
                }
                if (i == 15 && dt.Rows.Count > 0)
                {
                    pnl15.BackColor = Color.Coral;
                    pnl15.Enabled = false;
                }
                if (i == 16 && dt.Rows.Count > 0)
                {
                    pnl16.BackColor = Color.Coral;
                    pnl16.Enabled = false;
                }
                if (i == 17 && dt.Rows.Count > 0)
                {
                    pnl17.BackColor = Color.Coral;
                    pnl17.Enabled = false;
                }
                if (i == 18 && dt.Rows.Count > 0)
                {
                    pnl18.BackColor = Color.Coral;
                    pnl18.Enabled = false;
                }
                if (i == 19 && dt.Rows.Count > 0)
                {
                    pnl19.BackColor = Color.Coral;
                    pnl19.Enabled = false;
                }
                if (i == 20 && dt.Rows.Count > 0)
                {
                    pnl20.BackColor = Color.Coral;
                    pnl20.Enabled = false;
                }
                if (i == 21 && dt.Rows.Count > 0)
                {
                    pnl21.BackColor = Color.Coral;
                    pnl21.Enabled = false;
                }
                if (i == 22 && dt.Rows.Count > 0)
                {
                    pnl22.BackColor = Color.Coral;
                    pnl22.Enabled = false;
                }

                if (i == 23 && dt.Rows.Count > 0)
                {
                    pnl23.BackColor = Color.Coral;
                    pnl23.Enabled = false;
                }
                if (i == 24 && dt.Rows.Count > 0)
                {
                    pnl24.BackColor = Color.Coral;
                    pnl24.Enabled = false;
                }
                if (i == 25 && dt.Rows.Count > 0)
                {
                    pnl25.BackColor = Color.Coral;
                    pnl25.Enabled = false;
                }
                if (i == 26 && dt.Rows.Count > 0)
                {
                    pnl26.BackColor = Color.Coral;
                    pnl26.Enabled = false;
                }
                if (i == 27 && dt.Rows.Count > 0)
                {
                    pnl27.BackColor = Color.Coral;
                    pnl27.Enabled = false;
                }
                if (i == 28 && dt.Rows.Count > 0)
                {
                    pnl28.BackColor = Color.Coral;
                    pnl28.Enabled = false;
                }
                if (i == 29 && dt.Rows.Count > 0)
                {
                    pnl29.BackColor = Color.Coral;
                    pnl29.Enabled = false;
                }
                if (i == 30 && dt.Rows.Count > 0)
                {
                    pnl30.BackColor = Color.Coral;
                    pnl30.Enabled = false;
                }
                if (i == 31 && dt.Rows.Count > 0)
                {
                    pnl31.BackColor = Color.Coral;
                    pnl31.Enabled = false;
                }

            }

            con.FecharConnection();

        }


        private void FrmReservas_Load(object sender, EventArgs e)
        {
            int mes = DateTime.Now.Month;
            CbMes.Text = Convert.ToString(mes);
            int ano = DateTime.Now.Year;
            CbAno.Text = Convert.ToString(ano);
            CarregarComboBoxQuarto();
            CbQuarto.SelectedIndex = 0;
            desabilitarCampos();
            Listar();
            LimparOcupacoes();
            VerificarOcupacoes();

            LblTotal.Text = "0";
            
        }


        private void CbQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlDataReader reader;
            con.AbrirConnection();
            FrmMenu form = new FrmMenu(); //Instanciando o elemento (inicializando) - form é o nome do elemento.
            cmdVerificar = new MySqlCommand("SELECT * FROM quartos WHERE quarto = @quarto", con.con);
            cmdVerificar.Parameters.AddWithValue("@quarto", CbQuarto.Text);
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DO LOGIN
                while (reader.Read())
                {
                    ValorQuarto = Convert.ToString(reader["valor"]);
                }

                TxtValorDiaria.Text = ValorQuarto;
            }

            con.FecharConnection();

            VerificarDias31();
            VerificarOcupacoes();
        }

        private void CbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarDias31();
            VerificarOcupacoes();
            mes = Convert.ToInt32(CbMes.Text);
            
        }

        private void VerificarDias31()
        {
            int resto = Convert.ToInt32(CbAno.Text) % 4;

            if (CbMes.Text == "02" || CbMes.Text == "2")
            {
                pnl31.Visible = false;
                lbl31.Visible = false;
                pnl30.Visible = false;
                lbl30.Visible = false;
                pnl29.Visible = false;
                lbl29.Visible = false;

                DiasMes = 28;

             if(resto == 0)
                {
                    pnl31.Visible = false;
                    lbl31.Visible = false;
                    pnl30.Visible = false;
                    lbl30.Visible = false;
                    pnl29.Visible = true;
                    lbl29.Visible = true;

                    DiasMes = 29;
                }
            }
            else
            {
                pnl31.Visible = true;
                lbl31.Visible = true;
                pnl30.Visible = true;
                lbl30.Visible = true;
                pnl29.Visible = true;
                lbl29.Visible = true;

                if (CbMes.Text == "01" || CbMes.Text == "1" || CbMes.Text == "03" || CbMes.Text == "3" || CbMes.Text == "05" || CbMes.Text == "5" || CbMes.Text == "07" || CbMes.Text == "7" || CbMes.Text == "08" || CbMes.Text == "8" || CbMes.Text == "10" || CbMes.Text == "12")
                {
                    pnl31.Visible = true;
                    lbl31.Visible = true;

                    DiasMes = 31;
                }
                else
                {
                    pnl31.Visible = false;
                    lbl31.Visible = false;

                    DiasMes = 30;
                }
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (CbQuarto.Text == "")
            {
                MessageBox.Show("Cadastre, Antes, um Quarto!");
                Close();
            }

            limparCampos();
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;

            

        }

        private void CbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarDias31();
            VerificarOcupacoes();
        }

        private void pnl2_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl2.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl2.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
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


            if (ValorTotal > 0)
            {
                DataInicial = Grid.Rows[0].Cells[2].Value.ToString();
                DataFinal = Grid.Rows[Grid.Rows.Count - 1].Cells[2].Value.ToString();

                var Resultado = MessageBox.Show("Deseja confirmar a reserva nas datas do dia " + Convert.ToDateTime(DataInicial).ToString("dd/mm/yyyy") + " até " + Convert.ToDateTime(DataFinal).ToString("dd/mm/yyyy") + "?", "Confirmar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Resultado == DialogResult.Yes)
                {
                    con.AbrirConnection();
                    sql = "INSERT INTO reservas (quarto, entrada, saida, dias, valor, nome, telefone, data, funcionario) VALUES (@quarto, @entrada, @saida, @dias, @valor, @nome, @telefone, curDate(), @funcionario)";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@quarto", CbQuarto.Text);
                    cmd.Parameters.AddWithValue("@entrada", Convert.ToDateTime(DataInicial));
                    cmd.Parameters.AddWithValue("@saida", Convert.ToDateTime(DataFinal));
                    cmd.Parameters.AddWithValue("@dias", TxtDias.Text);
                    cmd.Parameters.AddWithValue("@valor", ValorTotal);
                    cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
                    cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
                    cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);


                    cmd.ExecuteNonQuery();
                    con.FecharConnection();

                    //RECUPERAR O ULTIMO ID DA VENDA
                    MySqlCommand cmdVerificar;
                    MySqlDataReader reader;

                    con.AbrirConnection();
                    FrmMenu form = new FrmMenu();
                    cmdVerificar = new MySqlCommand("SELECT id FROM reservas order by id desc LIMIT 1", con.con);
                    reader = cmdVerificar.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //EXTRAINDO INFORMAÇÕES DA CONSULTA
                        while (reader.Read())
                        {
                            ultimoIDreserva = Convert.ToString(reader["id"]);
                        }
                    }

                    //RELACIONAR A OCUPAÇÃO COM A RESERVA.
                    con.AbrirConnection();
                    sql = "UPDATE ocupacoes set id_reserva = @id_reserva where id_reserva = @id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("id", "0");
                    cmd.Parameters.AddWithValue("id_reserva", ultimoIDreserva);

                    cmd.ExecuteNonQuery();
                    con.FecharConnection();

                    MessageBox.Show("Reserva efetuada com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnNovo.Enabled = true;
                    BtnSalvar.Enabled = false;
                    limparCampos();
                    desabilitarCampos();
                    Listar();
                    ValorTotal = 0;
                    LblTotal.Text = "0";
                    DiasReserva = 0;
                    DataPainel = "0";
                }
            }
            else
            {
                MessageBox.Show("A reserva não possui datas!");
                return;
            }
            
        }

        private void SalvarOcupacoes()
        {
            if (DataPainel == "")
            {
                MessageBox.Show("Informe, premeiro, uma data!");
                return;
            }
            
            //CÓDIGO DO BOTÃO SALVAR
            con.AbrirConnection();
            sql = "INSERT INTO ocupacoes (quarto, data, funcionario) VALUES (@quarto, @data, @funcionario)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", CbQuarto.Text);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(DataPainel));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);


            cmd.ExecuteNonQuery();
            con.FecharConnection();
            VerificarOcupacoes();
            CbQuarto.Enabled = false;
            Listar();
            AtualizarTotalReserva();
            DataPainel = "0";
           
        }

        private void AtualizarTotalReserva()
        {
            DiasReserva += 1;
            TxtDias.Text = Convert.ToString(DiasReserva);
            ValorTotal = Convert.ToDouble(TxtValorDiaria.Text) * DiasReserva;
            LblTotal.Text = string.Format("{0:c2}", Convert.ToString(ValorTotal));

        }

        private void AbaterTotalReserva()
        {
            if(DiasReserva > 0)
            {
                DiasReserva -= 1;
                TxtDias.Text = Convert.ToString(DiasReserva);
                ValorTotal = Convert.ToDouble(TxtValorDiaria.Text) * DiasReserva;
                LblTotal.Text = string.Format("{0:c2}", Convert.ToString(ValorTotal));
            }
            

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (ValorTotal >= 0 && Convert.ToInt32(id) > 0)
            {
                con.AbrirConnection();

                sql = "DELETE FROM ocupacoes WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConnection();
                AbaterTotalReserva();
                VerificarOcupacoes();
                Listar();
                id = "0";
            }
            else
            {
                MessageBox.Show("Informe a linha a ser removida!");
                return;
            }
            
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnRemove.Enabled = true;

            id = Grid.CurrentRow.Cells[0].Value.ToString();

        }

        private void pnl1_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl1.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl1.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl1.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl1.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl2_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl2.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl2.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl3_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl3.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = 
                    Lbl3.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl3_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl3.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl3.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl4_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl4.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl4.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl4_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl4.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl4.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl5_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl5.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl5.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl5_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl5.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl5.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl6_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl6.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl6.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl6_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl6.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl6.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl7_Click(object sender, EventArgs e)
        {
           
        
            if (mes < 10)
              {
            DataPainel = Lbl7.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                    DataPainel = Lbl7.Text + "/" + CbMes.Text + "/" + CbAno.Text;
             }

                SalvarOcupacoes();

        }

        private void Lbl7_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl7.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl7.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl8_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl8.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl8.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl8_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl8.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl8.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl9_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl9.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl9.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl9_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl9.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl9.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl10_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl10.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl10.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl10_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl10.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl10.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl11_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl11.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl11.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl11_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl11.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl11.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl12_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl12.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl12.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl12_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl12.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl12.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl13_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl13.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl13.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void Lbl13_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = Lbl13.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = Lbl13.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl14_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl14.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl14.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl14_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl14.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl14.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl15_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl15.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl15.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl15_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl15.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl15.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl16_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl16.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl16.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl16_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl16.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl16.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl17_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl17.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl17.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl17_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl17.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl17.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl18_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl18.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl18.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl18_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl18.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl18.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl19_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl19.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl19.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl19_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl19.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl19.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl20_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl20.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl20.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl20_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl20.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl20.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl21_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl21.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl21.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl21_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl21.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl21.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl22_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl22.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl22.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl22_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl22.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl22.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl23_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl23.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl23.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl23_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl23.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl23.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl24_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl24.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl24.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl24_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl24.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl24.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl25_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl25.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl25.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl25_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl25.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl25.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl26_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl26.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl26.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl26_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl26.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl26.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl27_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl27.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl27.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl27_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl27.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl27.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl28_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl28.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl28.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl28_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl28.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl28.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl29_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl29.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl29.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl29_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl29.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl29.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl30_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl30.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl30.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl30_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl30.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl30.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void pnl31_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl31.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl31.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void lbl31_Click(object sender, EventArgs e)
        {
            if (mes < 10)
            {
                DataPainel = lbl31.Text + "/0" + CbMes.Text + "/" + CbAno.Text;
            }
            else
            {
                DataPainel = lbl31.Text + "/" + CbMes.Text + "/" + CbAno.Text;
            }

            SalvarOcupacoes();
        }

        private void FrmReservas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ValorTotal != 0)
            {
                MessageBox.Show("Você possui agendamentos pendentes, salvar a reserva ou removê-la do agendamento!");
                e.Cancel = true;
            }
        }

        
    }
}
