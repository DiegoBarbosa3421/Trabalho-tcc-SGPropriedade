using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RegrasNegocio
{

    public class RN_Faturamento
    {
        Database.Faturamento faturamento;
        Util util;
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  // Metodo de validação verifica se os campos estão com valores que não correspondem aos criterios para serem salvos no bamco de dados.

        private void ValidarFAturamento(string Talhão, double quantidade, double valorUnitarioArrecadado, double valorTortalArrecadado, double quantidadeDisponivel, string tipoDeCafé, int idFaturamento)
        {

               if (Talhão.Trim().Length == 0)
            {
                throw new Exception("Campo talhão não pode ser vazio !!Por favor  Selecione um talhão para continuar");
            }

            else if (tipoDeCafé.Trim().Length  == 0)
            {
                throw new Exception("Campo tipo de café não pode ser vazio!! Por favor Selecione uma oção para continuar");
            }

            else if (quantidade == 0)
            {
                throw new Exception("Campo quantidade não pode ser vazio!! Por favor insira uma quantidade para continuar");
            }
            else if(valorUnitarioArrecadado == 0)
            {
                throw new Exception("Campo Valor arrecadado por unidade não pode vazio!! Por favor ser insira um valor no campo Valor arrecadado por unidade para continuar");
            }
            else if (valorTortalArrecadado == 0)
            {
                throw new Exception("Campo valor total arrecadado não pode ser vazio!! Por favor insira uma valor para valor total arrecadado para prosseguir ");
            }

            else if (quantidadeDisponivel - quantidade < 0 && idFaturamento == 0)
            {
                throw new Exception(" Faturamento não pode ser salvo nobanco pois a quantidade informada para faturamento estrapola aquantidade disponivel, informe um valor dentro do limite disponivel ");
            }

        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Metodo salvar da classe faturamento, cria uma conecção entre a cmada de visualização e o banco de para salvar o faturamento.

        public void SalvarFaturamento(string Talhão, double quantidade, DateTime dataFAturamento, double valorUnitarioArrecadado, double valorTortalArrecadado, double quantidadeDisponivel, string tipoDeCafé)
        {
            faturamento = new Database.Faturamento();
            util = new Util();
            int idTalhão;

            ValidarFAturamento(Talhão, quantidade, valorUnitarioArrecadado, valorTortalArrecadado, quantidadeDisponivel, tipoDeCafé, 0);

            idTalhão = util.RetornarIdTalhão(Talhão);

            faturamento.Salvar_Faturamento(valorTortalArrecadado, valorUnitarioArrecadado, dataFAturamento, quantidade, tipoDeCafé, idTalhão);

        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       // Metodo de alteração da classe faturamento.
        public void AlterarFaturamento(int codigo, string talhão, double quantidade, DateTime datFaturamento, double valorUnitarioArrecadado, double valorTortalArrecadado, double quantidadeDisponivel ,string tipoDeCafé)
        {
            faturamento = new Database.Faturamento();
            util = new Util();
            int idTalhão;

            ValidarFAturamento(talhão, quantidade, valorUnitarioArrecadado, valorTortalArrecadado, quantidadeDisponivel, tipoDeCafé, codigo);

            idTalhão = util.RetornarIdTalhão(talhão);

            faturamento.Alterar_Faturamento(codigo, valorTortalArrecadado, valorUnitarioArrecadado, datFaturamento, quantidade, tipoDeCafé, idTalhão);


        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Metodo de exclusão responsavel por fazer concção com banco de dados para exclusão de dados.
        public void ExcluirFaturamento(int idFaturamento)
        {
            faturamento = new Database.Faturamento();

            faturamento.Excluir_Faturamento(idFaturamento);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Metodo Listar faturamento retorna uma lista de faturamento quando solicitado.
        public DataTable ListarFaturamento()
        {
            DataTable listarTabela = new DataTable();
            faturamento = new Database.Faturamento();

            listarTabela = faturamento.RetornarFaturamento();

            return listarTabela;
           
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Metodo Retornar Quantidade, este metodo busca na tabela produção por poduções especifiucas, "Despolpado" e "Descascado" que são o produto de café ja em estado de comercialização retorna suas quantidades 
        // de acordo com o talhão que o café foi colhido.
        public double RetornarQuantidadeProduzida(string talhão, string observação, string ano)
        {

            if (talhão.Trim().Length == 0)
            {
                throw new Exception("Selecione um talhão para continuar");
            }

            try
            {
                    
                util = new Util();
                DataTable listarTabela = new DataTable();
                DataTable listarTabelaauxiliar = new DataTable();
                faturamento = new Database.Faturamento();
                DateTime ano1 = DateTime.ParseExact(ano, "yyyy", CultureInfo.InvariantCulture);

                int idTalhão;
                double quantidadeDisponivel = 0;

                idTalhão = util.RetornarIdTalhão(talhão);

                listarTabela = faturamento.Retornar_Quatidade_Produzida(talhão, observação, ano1);

                listarTabelaauxiliar = faturamento.Retornar_Quantidade_já_faturada(idTalhão , observação);

                if (listarTabelaauxiliar.Rows.Count != 0 && listarTabela.Rows.Count != 0)
                {
                    quantidadeDisponivel = Convert.ToDouble(listarTabela.Rows[0]["totalProduzido"].ToString()) - Convert.ToDouble(listarTabelaauxiliar.Rows[0]["quantidadeTotalFaturado"].ToString());
                }

                else if (listarTabelaauxiliar.Rows.Count == 0 && listarTabela.Rows.Count != 0)
                {
                    quantidadeDisponivel = Convert.ToDouble(listarTabela.Rows[0]["totalProduzido"].ToString());
                }

                else if ( listarTabelaauxiliar.Rows.Count == 0 &&  listarTabela.Rows.Count == 0)
                {
                    quantidadeDisponivel = 0;
                }

                return quantidadeDisponivel;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao retornar a quantidade produzida parametros de entrada não encontrados" + ex);
            }

        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
