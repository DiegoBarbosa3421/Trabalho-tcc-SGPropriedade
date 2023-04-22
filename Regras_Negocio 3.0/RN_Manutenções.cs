using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class RN_Manutenções
    {
        Database.manutenção_Eqp_Fer manutenção_Eqp_Fer ;
        DataTable listarTabela;
        
        public void ValidarDados(string tipoManutenção, double valorManutenção, string Ferramenta)
        {

            if (Ferramenta.Trim().Length == 0)
            {
                throw new Exception(" Campo  Ferramenta não pode ser Vazio!! Por favor selecione uma feramenta para continuar");
            }

           else if (tipoManutenção.Trim().Length == 0)
            {
                throw new Exception(" Campo Tipo de Manutenção não pode ser Vazio!! Por favor digite um tipo de manutenção para continuar, exemplo troca de peçãs");
            }

            else if (valorManutenção == 0)
            {
                throw new Exception("Valor da manutenção não pode ser agual a Zero!! Por favor digite um valor para esta manutenção");
            }

            

        }
        public void  SalvarManutenção(string tipoManutenção, double valorManutenção, DateTime dataManutenção, string Ferramentas)
         {
            manutenção_Eqp_Fer = new Database.manutenção_Eqp_Fer();
            Database.Ferramentas ferramentas = new Database.Ferramentas();
            DataTable listarTabela = new DataTable();
            int idFerramentas = 0;

            ValidarDados(tipoManutenção, valorManutenção, Ferramentas);

            listarTabela = ferramentas.PesquisarFerramentas(Ferramentas);

            idFerramentas = Convert.ToInt32(listarTabela.Rows[0]["idFerramentas"].ToString());

            manutenção_Eqp_Fer.SalvarManutenção(tipoManutenção, valorManutenção, dataManutenção, idFerramentas);
         }
        public void ExcluirManutenção(int idManutenção)
        {
            manutenção_Eqp_Fer = new Database.manutenção_Eqp_Fer();
            manutenção_Eqp_Fer.ExcluirManutenção(idManutenção);
        }

        public void AlterarManutenção(string tipoManutenção, double valorManutenção, DateTime dataManutenção, string Ferramentas, int idManutenção)
        {
            manutenção_Eqp_Fer = new Database.manutenção_Eqp_Fer();
            Database.Ferramentas ferramentas = new Database.Ferramentas();
            DataTable listarTabela = new DataTable();
            int idFerramentas = 0;

            ValidarDados(tipoManutenção, valorManutenção, Ferramentas);

            listarTabela = ferramentas.PesquisarFerramentas(Ferramentas);

            idFerramentas = Convert.ToInt32(listarTabela.Rows[0]["idFerramentas"].ToString());

            manutenção_Eqp_Fer.AlterarManutenção(tipoManutenção, valorManutenção, dataManutenção, idFerramentas, idManutenção);

        }

        public DataTable ListarMnutenção()
        {
            manutenção_Eqp_Fer = new Database.manutenção_Eqp_Fer();
            listarTabela = new DataTable();
            listarTabela = manutenção_Eqp_Fer.listarManutenção();

            return listarTabela;
        }

        public DataTable Pesquisar(string nomeFerramenta)
        {
            listarTabela = new DataTable();
            manutenção_Eqp_Fer = new Database.manutenção_Eqp_Fer();
            listarTabela = manutenção_Eqp_Fer.PesquisarManutenção(nomeFerramenta);

            return listarTabela;
        }
    }
}
