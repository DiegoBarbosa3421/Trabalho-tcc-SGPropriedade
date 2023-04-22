using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
   public class RN_CriarBancoDeDados
    {
        Database.CriarBancoDeDados novobanco;
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Metodo para verificar se ha um banco de dados correspondente no sistema
        public DataTable VerificarBanco()
        {
            try
            {
               
                novobanco = new Database.CriarBancoDeDados();
                return novobanco.VerificarBanco("sgagricolatcc");
            }
            catch (Exception)
            {

                throw;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Metodo que cria um banco de dados para uso do sistema 
        public void CriarBancodeDados()
        {
            try
            {

                novobanco = new Database.CriarBancoDeDados();
                string scripBancoDeDados = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\Sgagricolatcc2.sql";
                novobanco.CriarBancodeDados(scripBancoDeDados);

            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }
    }
}
