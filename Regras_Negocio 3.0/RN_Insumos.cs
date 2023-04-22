using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class RN_Insumos
    {
        Database.Insumos insumos;

        public DataTable retornarInsumos()
        {

                insumos = new Database.Insumos();

                DataTable listartabela = new DataTable();

                listartabela = insumos.RetornarInsumos();

                return listartabela;
           
        }

        public void ValidarInsumos(string insumo, double preçoUnitario, double valorTotal, double quantidade, string observação)
        {
            if ( insumo.Trim().Length == 0)
            {
                throw new Exception("Campo nome de insumos não pode ser vazio !! por favor insira um nome de insumos");
            }

         else  if (quantidade == 0)
            {
                throw new Exception("Campo quantidade não pode ser vazio!! por favor insira uma quantidade");
            }

         else   if (preçoUnitario == 0)
            {
                throw new Exception("Campo Valor Unitario não pode ser vazio!! por favor insira um valor para unidade");
            }

         else if (observação.Trim().Length == 0)
            {
                throw new Exception("Campo observação não pode ser vazio!! por favor insira uma informação para o campo observação!!   exemplo: para Fertilizantes  sacos 50 kg   ");
            }

         else  if (valorTotal == 0)
            {
                throw new Exception("Campo valor total não pode ser vazio!! por favor insira o valor total que foi pago");
            }

           
        }

        public void salvarInsumos(string insumo, double preçoUnitario, double valorTotal, double quantidade,  string observação, DateTime data)
        {
           
            insumos = new Database.Insumos();
            ValidarInsumos(insumo, preçoUnitario, valorTotal, quantidade, observação);
             insumos.SalvarInsumos(insumo, preçoUnitario, valorTotal, quantidade, observação, data);

        }

        public void alterarInsumos(int id, string insumo, double preçoUnitario, double valorTotal, double quantidade, string observação, DateTime data)
        {
          
            insumos = new Database.Insumos();
            ValidarInsumos(insumo, preçoUnitario, valorTotal, quantidade, observação);
            insumos.AlterarInsumos(id, insumo, preçoUnitario, valorTotal, quantidade, observação, data);
         
        }

        public void excluirInsumos(int id)
        {
           
                insumos = new Database.Insumos();

                insumos.ExcluirInsumos(id);
          
        }

        public DataTable pesquisarInsumos(string nome)
        {
           
                DataTable listarTabela = new DataTable();

                insumos = new Database.Insumos();

                listarTabela = insumos.PesquisarInsumos(nome);

                return listarTabela;
          
        }
    }
}


