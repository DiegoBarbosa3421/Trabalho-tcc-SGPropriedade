using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    class Colaborador
    {
        Database.Colaborador colaborador;

        public void validarcloiaborador(string nome, string endereço, string contato, string situação)
        {
            if (nome.Trim().Length== 0)
            {
                throw new Exception("Campo nome não pode ser vazio");
            }

            if (endereço.Trim().Length == 0)
            {
                throw new Exception("Campo endereço não pode ser vazio");
            }

            if (contato.Trim().Length == 0)
            {
                throw new Exception("Campo contato não pode ser vazio");
            }

            if (situação.Trim().Length == 0)
            {
                throw new Exception("Campo situação não ser vazio");
            }

        }

        public void salvarColaborador(string nome, string endereço, string contato, string situação)
        {

            validarcloiaborador(nome, endereço, contato, situação);
            colaborador = new Database.Colaborador();

            DataTable listarTabela = new DataTable();

            listarTabela = colaborador.PesquisarColaborador(nome);

            if (listarTabela.Rows.Count > 0)
            {
                throw new Exception("Colaborador ja cadastrado" + listarTabela.Rows[0]["nomeColaborador"].ToString());
            }
            else
            {
                colaborador.SalvarColaborador(nome, endereço, contato, situação);
            }
        }
       
        public void alterarColaborador(int id, string nome, string endereço, string contato, string situação)
        {
          
                colaborador = new Database.Colaborador();

                if (id == 0)
                {
                    throw new Exception("Nenhum registro de Colaborador corespondente ");
                }
                else
                {
                    colaborador.AlteraColaborador(id, nome, contato, endereço, situação);

                }

        }
        public void excluirColaborador(int id )
        {
          
                if (id == 0)
                {
                    throw new Exception("Nenhum registro Corespondente");
                }
                else
                {
                    colaborador = new Database.Colaborador();

                    colaborador.ExcluirColaborador(id);
                }

        }
    }
}
