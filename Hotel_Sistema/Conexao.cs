using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Sistema
{
    class Conexao   
    {
        //CONEXÃO COM O BANCO DE DADOS LOCAL 
        public string conect = "SERVER=localhost; DATABASE=hotel; UID=root; PWD=; PORT=;"; //Caminho de acesso ao Banco de Dados

        //CONEXÃO COM O BANCO DE DADOS WEB 
        //public string conect = "SERVER=mysql669.umbler.com; DATABASE=hoteltestte; UID=willianshotel; PWD=hotelwillians; PORT=41890;"; //Caminho de acesso ao Banco de Dados

        //public string conect = "SERVER=sql213.byethost12.com; DATABASE=b12_26798935_hotel; UID=b12_26798935; PWD=hotelteste; PORT=3306;"; //Caminho de acesso ao Banco de Dados



        public MySqlConnection con = null;

        public void AbrirConnection()
        {
            try // Testando a conexão com o MySql
            {
                con = new MySqlConnection(conect); //Instanciando
                con.Open();
            }
            catch (Exception ex) //Se tiver erro o Catch pega e exibe no Throw pela variável ex do tipo Exception
            {

                throw ex;
            }

        }

        public void FecharConnection()
        {
            try
            {
                con = new MySqlConnection(conect);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
