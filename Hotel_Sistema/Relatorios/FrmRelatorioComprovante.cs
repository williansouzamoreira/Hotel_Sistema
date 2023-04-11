using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Sistema.Relatorios
{
    public partial class FrmRelatorioComprovante : Form
    {
        public FrmRelatorioComprovante()
        {
            InitializeComponent();
        }

        private void FrmRelatorioComprovante_Load(object sender, EventArgs e)
        {
            this.vendasPorIDTableAdapter.Fill(this.hotelDataSet.VendasPorID, Convert.ToInt32(Program.IdVendaGL));
            this.detalhesVendaIDTableAdapter.Fill(this.hotelDataSet.detalhesVendaID, Convert.ToInt32(Program.IdVendaGL));

            this.reportViewer1.RefreshReport();
        }
    }
}
