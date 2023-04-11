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
    public partial class FrmRelatorioServico : Form
    {
        public FrmRelatorioServico()
        {
            InitializeComponent();
        }

        private void FrmRelatorioServico_Load(object sender, EventArgs e)
        {

            BuscarPorData();
        }

        private void BuscarPorData()
        {
            this.comprovanteServicoPorDataTableAdapter.Fill(this.hotelDataSet.ComprovanteServicoPorData, Convert.ToDateTime(DtInicial.Text), Convert.ToDateTime(DtFinal.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DataInicial", DtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DataFinal", DtFinal.Text));
            this.reportViewer1.RefreshReport();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorData();
        }
    }
}
