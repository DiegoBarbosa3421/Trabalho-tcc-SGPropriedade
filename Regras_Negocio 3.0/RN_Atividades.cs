using System;
using System.Data;

namespace RegrasNegocio
{
    public class RN_Atividades
    {
        DataTable listarTabela;
        Database.ExecuçãoAtividades exatividade;
        Util Util;
        public DataTable ListarAtividades()
        {
            exatividade = new Database.ExecuçãoAtividades();
            listarTabela = new DataTable();
            listarTabela = exatividade.ListarEXServiços();
            return listarTabela;
        }

        public void ValidarDados(string situação, string talhão, string colaborador, string serviço)
        {
            if (serviço.Trim().Length == 0)
            {
                throw new Exception("Selecione uma serviço para continuar");
            }

            else if (talhão.Trim().Length == 0)
            {
                throw new Exception("Selecione um talhão para continuar");
            }

            else if (colaborador.Trim().Length == 0)
            {
                throw new Exception("Selecione um colaborador para continuar");
            }

            else if (situação.Trim().Length == 0)
            {
                throw new Exception("Escolha uma opção em situação para proceguir ");
            }

        }

        public void SalvarAtividade(string situação, DateTime dataInicio , DateTime dataTermino, string talhão, string colaborador, string serviço)
        {
            Util = new Util();
            exatividade = new Database.ExecuçãoAtividades();
            int idserviço = 0;
            int idTalhão = 0;
            int idColaborador = 0;
            

            ValidarDados(situação, talhão, colaborador, serviço);

            Database.CadastroServiço serviços = new Database.CadastroServiço();

            idTalhão = Util.RetornarIdTalhão(talhão);
            idserviço = Util.RetornaridServiços(serviço);
            idColaborador = Util.RetornaridColaborador(colaborador);
          
            exatividade.SalvarExServiços(situação, dataInicio, dataTermino, idserviço, idColaborador, idTalhão);
        }

       
        public void AlterarAtividade(int codigo, string situação, DateTime dataInicio, DateTime dataTermino, string talhão, string colaborador, string serviço)
        {


            Util = new Util();
            exatividade = new Database.ExecuçãoAtividades();
            int idserviço = 0;
            int idTalhão = 0;
            int idColaborador = 0;
        

            ValidarDados(situação, talhão, colaborador, serviço);

            Database.CadastroServiço serviços = new Database.CadastroServiço();

            idTalhão = Util.RetornarIdTalhão(talhão);
            idserviço = Util.RetornaridServiços(serviço);
            idColaborador = Util.RetornaridColaborador(colaborador);
          
            exatividade.AlterarExServiço(codigo, situação, dataInicio, dataTermino, idserviço, idTalhão, idColaborador);
        }

        public void ExcluirAtividade(int idatividade)
        {
            exatividade = new Database.ExecuçãoAtividades();
            exatividade.DeletarExServiço(idatividade);
        }

        public DataTable PesquisarAtividade(string serviço)
        {
            listarTabela = new DataTable();
            Database.CadastroServiço serviços = new Database.CadastroServiço();
            int idserviço = 0;
            idserviço = Util.RetornaridServiços(serviço);
            exatividade = new Database.ExecuçãoAtividades();
            listarTabela = exatividade.PesquisarAtividades(Convert.ToInt32(idserviço));
            return listarTabela;
        }

    }
}