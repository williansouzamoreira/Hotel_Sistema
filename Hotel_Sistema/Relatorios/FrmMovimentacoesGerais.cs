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
    public partial class FrmMovimentacoesGerais : Form
    {
        public FrmMovimentacoesGerais()
        {
            InitializeComponent();
        }

        private void FrmMovimentacoesGerais_Load(object sender, EventArgs e)
        {
            DtInicial.Value = DateTime.Today;
            DtFinal.Value = DateTime.Today;
            BuscarData();
        }
        private void BuscarData()
        {
            this.movimentacoesGeraisTableAdapter.Fill(this.hotelDataSet.MovimentacoesGerais, Convert.ToDateTime(DtInicial.Text), Convert.ToDateTime(DtFinal.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", DtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", DtFinal.Text));
            this.reportViewer1.RefreshReport();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
