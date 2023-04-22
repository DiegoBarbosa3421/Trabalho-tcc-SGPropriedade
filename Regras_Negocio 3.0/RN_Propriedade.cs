using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class RN_Propriedade
    {
        Database.Propriedade propriedade;

        public void Validardados(string Propriedade, string tipoCultivo, double valor, double harea, String Proprietario)
        {

                if (Propriedade.Trim().Length == 0)
                {
                    throw new Exception("Campo Propriedade não Pode ser vazio!! Por favor insira uma identificação para sua propriedade, exemplo Sitio dos Pereira ");

                }
                else if (tipoCultivo.Trim().Length == 0)
                {
                    throw new Exception("Campo Tipo de Cultivo  não Pode ser vazio!! Por favor digite o seu tipo de cultivo de cafe caso nesta propriedade seja apenas uma variedade caso contrrio digite apenas café");
                }
                else if (valor == 0)
                {
                    throw new Exception("Campo Valor da Propriedade não Pode ser vazio!!Por favor Digite um valor desta propriedade para contibnuar");
                }
                else if (harea == 0)
                {
                    throw new Exception("O campo Harea Hectares  não pode ser vazio !! Por favor Digite um valor para o campo Harea em hectares");

                }
                else if (Proprietario.Trim().Length == 0)
                {
                    throw new Exception("O campo Proprietario não pode ser vazio!! Por favor selecione um proprietario para continuar");
            }
        }
      
        public void SalvarPropriedade(string Propriedade, string tipoCultivo, Date data, double valor, double harea , string Proprietario  )
        {
          
            propriedade = new Database.Propriedade();

            DataTable listarTabela = new DataTable();
            
            int idProprietario = 0;

            Validardados(Propriedade, tipoCultivo, valor, harea, Proprietario);

            Database.Proprietario proprietario = new Database.Proprietario();

            listarTabela = proprietario.RetornarProprietario_id(Proprietario);

            idProprietario = Convert.ToInt32(listarTabela.Rows[0]["idproprietario"].ToString());

            propriedade.SalvarPropriedade(Propriedade,tipoCultivo,data,valor,harea,idProprietario);

        }

        public void AlterarPropriedade(int idPropriedade, string Propriedade, string tipoCultivo, Date data, double valor, double harea, string  Proprietario)
        {
           
            propriedade = new Database.Propriedade();

            int idProprietario = 0;

            DataTable listarTabela = new DataTable();

            Database.Proprietario proprietario = new Database.Proprietario();

            listarTabela = proprietario.RetornarProprietario_id(Proprietario);

            idProprietario = Convert.ToInt32(listarTabela.Rows[0]["idproprietario"].ToString());

            Validardados(Propriedade, tipoCultivo, valor, harea, Proprietario);

           propriedade.AlterarPropriedade(idPropriedade, Propriedade, tipoCultivo, data, valor, harea, idProprietario);
           
        }

        public void ExclluirPropriedade(int id)
        {
         
               propriedade = new Database.Propriedade();

                propriedade.EscluirPropriedade(id);
          
        }

        public DataTable RetornarPropriedade()
        {
            
                DataTable listarTabela = new DataTable();

                propriedade = new Database.Propriedade();

                listarTabela = propriedade.ListarPropriedade();

                return listarTabela;
           
        }

        public DataTable PesquisarPropriedade(string nome)
        {
           
                DataTable listarTabela = new DataTable();

                propriedade = new Database.Propriedade();

                listarTabela = propriedade.PesquisarPropriedade(nome);

                return listarTabela;
          
        }

    }
}
