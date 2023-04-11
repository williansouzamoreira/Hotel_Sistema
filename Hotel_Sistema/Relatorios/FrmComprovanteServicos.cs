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
    public partial class FrmComprovanteServicos : Form
    {
        public FrmComprovanteServicos()
        {
            InitializeComponent();
        }

        private void FrmComprovanteServicos_Load(object sender, EventArgs e)
        {
            this.comprovanteServicoTableAdapter.Fill(this.hotelDataSet.ComprovanteServico, Convert.ToInt32(Program.idNovoServico));
            this.reportViewer1.RefreshReport();
        }
    }
}
