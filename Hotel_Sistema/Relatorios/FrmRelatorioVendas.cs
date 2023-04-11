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
    public partial class FrmRelatorioVendas : Form
    {
        public FrmRelatorioVendas()
        {
            InitializeComponent();
        }

        private void FrmRelatorioVendas_Load(object sender, EventArgs e)
        {
            DtInicial.Value = DateTime.Today;
            DtFinal.Value = DateTime.Today;
            CbStatus.SelectedIndex = 0;
            BuscarData();
            
        }

        private void BuscarData()
        {
            this.vendasPorDataTableAdapter.Fill(this.hotelDataSet.VendasPorData, Convert.ToDateTime(DtInicial.Text), Convert.ToDateTime(DtFinal.Text), CbStatus.Text);
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DataInicial", DtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DataFinal", DtFinal.Text));
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

        private void CbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
