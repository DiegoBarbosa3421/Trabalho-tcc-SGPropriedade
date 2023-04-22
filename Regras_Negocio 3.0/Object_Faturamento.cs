using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class Object_Faturamento
    {
        private string propriedade;

        private string nomeTalhão;

        private string tipoCafé;

        private double valorTotal;

        private double valorUnitario;

        private double quantidade;

        private DateTime data;

        public string Propriedade { get => propriedade; set => propriedade = value; }

        public string NomeTalhão { get => nomeTalhão; set => nomeTalhão = value; }

        public string TipoCafé { get => tipoCafé; set => tipoCafé = value; }

        public double Valortotal { get => valorTotal; set => valorTotal = value; }

        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }

        public double Quantidade { get => quantidade; set => quantidade = value; }

        public DateTime Data { get => data; set => data = value; }


    }
}
