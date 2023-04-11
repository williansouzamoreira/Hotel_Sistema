using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Sistema
{
    static class Program
    {
        //DECLARANDO VARIAVEIS GLOBAIS DO SISTEMA.
        public static string NomeUsuario;
        public static string CargoUsuario;

        public static string ChamadaProdutos;
        public static string ChamadaHospedes;

        public static string idNovoServico;

        public static string NomeHospede;
        

        public static string NomeProduto;
        public static string EstoqueProduto;
        public static string IdProduto;
        public static string ValorProduto;

        public static string IdVendaGL;
        public static string IdReserva;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
