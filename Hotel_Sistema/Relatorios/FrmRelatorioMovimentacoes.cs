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
    public partial class FrmRelatorioMovimentacoes : Form
    {
        public FrmRelatorioMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmRelatorioMovimentacoes_Load(object sender, EventArgs e)
        {
            DtInicial.Value = DateTime.Today;
            DtFinal.Value = DateTime.Today;
            CbTipo.SelectedIndex = 0;
            BuscarData();
        }

        private void BuscarData()
        {
            this.movimentacoesPorDataTipoTableAdapter.Fill(this.hotelDataSet.MovimentacoesPorDataTipo, Convert.ToDateTime(DtInicial.Text), Convert.ToDateTime(DtFinal.Text), CbTipo.Text);
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DataInicial", DtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DataFinal", DtFinal.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tipo", CbTipo.Text));
            this.reportViewer1.RefreshReport();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void CbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
