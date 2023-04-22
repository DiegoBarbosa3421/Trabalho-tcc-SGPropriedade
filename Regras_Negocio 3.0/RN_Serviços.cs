using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class RN_Serviços
    {
        Database.CadastroServiço serviços;
        DataTable ListarTabela;
        public DataTable retornarServiços()
        {
            serviços = new Database.CadastroServiço();
            ListarTabela = new DataTable();

            ListarTabela = serviços.ListarServiço();
            return ListarTabela;
        }

        private void ValidarServiços(string tipoServiço, double valorServiços)
        {
            if (tipoServiço.Trim().Length == 0)
            {
                throw new Exception("Campo tipo serviços não pode ser vazio!! Por favor insira um nome para este serviço");
            }

            else if (valorServiços == 0)
            {
                throw new Exception("Campo valor serviços não pode ser vazio!! Por favor insira um valor para continuar");
            }
        }

        public void SalvarServiços(string tipoServiço, double valorServiços , DateTime data)
        {
            serviços = new Database.CadastroServiço();

            ValidarServiços(tipoServiço, valorServiços);

            serviços.CadastrarServiços(tipoServiço, valorServiços, data);
        }

        public void ExcluirServiços(int id)
        {
            serviços = new Database.CadastroServiço();

            serviços.ExcluirServiços(id);
        }

        public void AlterarServiços(int codigo, string tipoServiço, double valorServiços , DateTime data)
        {
            serviços = new Database.CadastroServiço();

            ValidarServiços(tipoServiço, valorServiços);

            serviços.AlterarServiço(codigo, tipoServiço, valorServiços, data);
        }

        public DataTable PesquisarServiços(string Serviços)
        {
            serviços = new Database.CadastroServiço();

            ListarTabela = serviços.PesquisarServiço(Serviços);
            return ListarTabela;
        }
    }
}
