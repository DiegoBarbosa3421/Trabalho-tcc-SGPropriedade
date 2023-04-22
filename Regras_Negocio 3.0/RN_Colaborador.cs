using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{

    public class RN_Colaborador
    {
        Database.Colaborador colaborador;
        DataTable listarTabela;

        private void ValidarColaborador(string nome, string contato, string endereço, string situação)
        {
            if (nome.Trim().Length == 0) 
            {
                throw new Exception("Campo Nome do Colaborador não pode ser vazio!! Por favor insira um nome para o colaborador para continuar");
            }

           else if (contato.Trim().Length == 0)
            {
                throw new Exception("Campo Contato não pode ser vazio!! Por favor insira um contato para continuar");
            }

            else if (endereço.Trim().Length == 0)
            {
                throw new Exception("Campo Endereço não pode ser vazio!! Por favor insira um endereço para continuar ");
            }

          else if (situação.Trim().Length == 0)
            {
                throw new Exception("Campo Situação não pode ser vazio!! Por favor selecione uma das opções de situação para continuar");
            }

        }

        public void SalvarColaborador(string nome, string contato, string endereço, string situação)
        {
            colaborador = new Database.Colaborador();
            ValidarColaborador(nome, contato, endereço, situação);
            colaborador.SalvarColaborador(nome, contato, endereço, situação);
        }

        public void ExcluirColaborador(int id)
        {
            colaborador = new Database.Colaborador();
            colaborador.ExcluirColaborador(id);
        }

        public void AlteraColaborador(int id, string nome, string contato, string endereço, string situação)
        {
            colaborador = new Database.Colaborador();
            ValidarColaborador(nome, contato, endereço, situação);
            colaborador.AlteraColaborador(id, nome, contato, endereço, situação);
        }

        public DataTable PesquisarColaborador(string nome)
        {
            listarTabela = new DataTable();

            colaborador = new Database.Colaborador();

            listarTabela = colaborador.PesquisarColaborador(nome);

            return listarTabela;
        }

        public DataTable ListarColaborador()
        {
            colaborador = new Database.Colaborador();
            listarTabela = new DataTable();

            listarTabela = colaborador.RetornarColaborador();

            return listarTabela;
        }

    }
}
