using Microsoft.OData.Edm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class RN_Ferramentas
    {
        Database.Ferramentas ferramentas;


        private void ValidarFerramentas(string nomeFerramenta, double valor)
        {
            if (nomeFerramenta.Trim().Length == 0)
            {
                throw new Exception("Campo nome ferrameta vazio !! Por favor informe um nome ferramenta para ferramenta que deseja salvar");
            }

            else if (valor == 0)
            {
                throw new Exception("Campo valor ferrameta vazio !! Por favor informe um valor para a ferramenta para prosseguir");
            }
        }

    
        public void salvarFerramentas(string nomeFerramenta, double valor, DateTime data)
        {


            ferramentas = new Database.Ferramentas();

            ValidarFerramentas(nomeFerramenta, valor);

            ferramentas.SalvarFerramentas(nomeFerramenta, valor, data);


        }


        public void excluirFeramenta(int id)
        {

            ferramentas = new Database.Ferramentas();

            ferramentas.ExcluirFerramenta(id);

        }

        public void alterarFerramnta(int id, string nomeFerramenta, double valor, DateTime data)
        {
            ferramentas = new Database.Ferramentas();

            ValidarFerramentas(nomeFerramenta, valor);

            ferramentas.AlterarFerramenta(id, nomeFerramenta, valor, data);

        }
        public DataTable retornarFerrramenta()
        {
            DataTable listarTabela = new DataTable();
            ferramentas = new Database.Ferramentas();



            listarTabela = ferramentas.ListarFeramnta();

            return listarTabela;
        }


        public DataTable pesquisarFerramenta(string nome)
        {

            DataTable listarTabela = new DataTable();
            ferramentas = new Database.Ferramentas();

            listarTabela = ferramentas.PesquisarFerramentas(nome);

            return listarTabela;


        }


    }
}

   

