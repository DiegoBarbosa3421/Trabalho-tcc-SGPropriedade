using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{

    public class RN_Produção
    {
        Database.Produção Produção;
        DataTable listarTabela;
        Util Util;


        public void ValidarDados(double quantidade, double custoUnitario, string colaborador, string tipo_Produção, string talhão)
        {

            if (tipo_Produção.Trim().Length == 0)
            {
                throw new Exception("Campo tipo de café não pode ser vazio!! Por favor selecione uma opição");
            }

            else if (quantidade == 0)
            {
                throw new Exception("Campo de quantidade não pode ser vazio!! Por favor insira uma quantidade");
            }

            else if (custoUnitario == 0)
            {
                throw new Exception("Campo de custo unitario não pode ser vazio!! Por favor insira um valor para o custos");
            }

            else if (colaborador.Trim().Length == 0)
            {
                throw new Exception("Campo colaborador não pode ser vazio!! Por favor selecione um colaborador");
            }

            else if (talhão.Trim().Length == 0)
            {
                throw new Exception("Campo Talhão não pode ser vazio!! Por favor selecione um talhão");
            }
        }
        public void SalvarProdução(string tipo_Produção, double quantidade, double custoUnitario, string colaborador, string talhão, DateTime data1, DateTime data2)
        {
            Produção = new Database.Produção();
            Util = new Util();
            int idTalhão;
            int idColaborador;

            ValidarDados(quantidade, custoUnitario, colaborador, tipo_Produção, talhão);

            idTalhão = Util.RetornarIdTalhão(talhão);
            idColaborador = Util.RetornaridColaborador(colaborador);

            Produção.salvarProdução(quantidade, data1, data2, custoUnitario, tipo_Produção, idTalhão, idColaborador);

        }

        public void AlterarProdução(int codigo, string tipo_Produção, double quantidade, double custoUnitario, string colaborador, string talhão, DateTime data1, DateTime data2)
        {
            Produção = new Database.Produção();
            Util = new Util();
            int idTalhão;
            int idColaborador;

            ValidarDados(quantidade, custoUnitario, colaborador, tipo_Produção, talhão);

            idTalhão = Util.RetornarIdTalhão(talhão);
            idColaborador = Util.RetornaridColaborador(colaborador);

            Produção.AlterarProdução(codigo, quantidade, data1, data2, custoUnitario, tipo_Produção, idTalhão, idColaborador);
        }

        public void EsxcluirProdução(int codigo)
        {
            Produção = new Database.Produção();
            Produção.EscluiProdução(codigo);
        }

        public DataTable  ListarProdução()
        {
             listarTabela = new DataTable();
            Produção = new Database.Produção();
            listarTabela = Produção.ListarProdução();
            return listarTabela; 
        }

        public DataTable PesquisarProdução(string tipodePesquisa, string valorPesquisa1, string valorPesquisa2)
        {
             listarTabela = new DataTable();
            Produção = new Database.Produção();

            if (tipodePesquisa == "Data")
            {
                listarTabela = Produção.PesquisarProdução(tipodePesquisa, null, Convert.ToDateTime(valorPesquisa1), Convert.ToDateTime(valorPesquisa2));
            }
            else
            {
                listarTabela = Produção.PesquisarProdução(tipodePesquisa, valorPesquisa1 , DateTime.Today, DateTime.Today);
            }

            return listarTabela;
        }
    }
}

