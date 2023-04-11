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
    public partial class FrmRelatorioDetalhesReserva : Form
    {
        public FrmRelatorioDetalhesReserva()
        {
            InitializeComponent();
        }

        private void FrmRelatorioDetalhesReserva_Load(object sender, EventArgs e)
        {
            this.detalhesReservaTableAdapter.Fill(this.hotelDataSet.DetalhesReserva, Convert.ToInt32(Program.IdReserva));
            this.reportViewer1.RefreshReport();
        }
    }
}
