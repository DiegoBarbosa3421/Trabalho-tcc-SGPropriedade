using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class RN_Talhão
    {
        Util util ;
        Database.talhão talhão;
        DataTable listarTabela;
        public DataTable listarTalhão()
        {
           
               listarTabela = new DataTable();
                talhão = new Database.talhão();

                listarTabela = talhão.RetornarTalhão();

                return listarTabela;
           
        }


        public void ValidarTalhão(string nomeTalhão, string tipodePlanta, double espaçamento, double hareaequitares, int quantidadedePlantas, string propriedade )
        {
            if (nomeTalhão.Trim().Length == 0)
            {
                throw new Exception("Campo Talhão não pode ser vazio !! Por favor insira uma identificação para o talhão para continuar, exemplo talhão A ou A1 ");
            }

            else if (hareaequitares == 0)
            {
                throw new Exception("Campo Harea em Hectares  não pode ser vazio!! Por favor insira um valor de harea hec");
            }

            else if (quantidadedePlantas == 0)
            {
                throw new Exception("Campo quantidade de plantas não pode ser vazio!! Por favor insira quantas plantas foram planatdas neste talhão");
            }

            else if (propriedade.Trim().Length == 0)
            {
                throw new Exception("Campo propriedade  não pode ser vazio !! Selecione uma opção de propriedade para continuar");
            }

            else if (tipodePlanta.Trim().Length == 0)
            {
                throw new Exception("Campo Tipo de Planta  não pode ser vazio !! Por favor insira um tipo de planta para continuar, exemplo Conilonou ou Arara");
            }

            else if (espaçamento == 0)
            {
                throw new Exception("Campo espaçamento não pode ser vazio !! Por favor insira um expaçamento para continuar, exemplo 50 ou 100");
            }

           
 
        }


        public void SalvarTalhão(string nomeTalhão, string tipodePlanta, double espaçamento, double hareaHectares, DateTime data, int quantidadedePlantas, string propriedade)
        {
       
                util = new Util();

                talhão = new Database.talhão();
       
                ValidarTalhão(nomeTalhão, tipodePlanta, espaçamento, hareaHectares, quantidadedePlantas, propriedade);

                int idpropriedade = util.RetornaridPropriedade(propriedade);

                talhão.SalvarTalhão(nomeTalhão, hareaHectares, tipodePlanta, espaçamento, quantidadedePlantas, data, idpropriedade);
     
        }

        public void AlterarTalhão(int idTalhão , string nomeTalhão, string tipodePlanta, double espaçamento, double hareaHectares, DateTime dataPlantio, int quantidadedePlantas, string propriedade)
        {
            util = new Util();

            talhão = new Database.talhão();

            ValidarTalhão(nomeTalhão, tipodePlanta, espaçamento, hareaHectares, quantidadedePlantas, propriedade);

            int idpropriedade = util.RetornaridPropriedade(propriedade);

            talhão.AlterarTalhão(idTalhão,nomeTalhão, hareaHectares, tipodePlanta, espaçamento, dataPlantio, quantidadedePlantas, idpropriedade);
        }

        public void ExcluirTalhão(int idtalhão)
        {
            talhão = new Database.talhão();

            talhão.ExcluirTalhão(idtalhão);
        }

        public DataTable PesquisarTalhão(string nomeTalhão)
        {
           
            listarTabela = new DataTable();
            talhão = new Database.talhão();
            listarTabela = talhão.PesquisarTalhão(nomeTalhão);
            return listarTabela;
        }

     
    }
}
 