using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class Object_Rendimento
    {
        private string propriedade;

        private string talhão;

        private double rendimento;

        private double custosdeProduçãoPorSaca;

        private double faturamentoTotalTalhão;

        private int ano;

        public string Propriedade { get => propriedade; set => propriedade = value; }

        public string Talhão { get => talhão; set => talhão = value; }

        public double Rendimento { get => rendimento; set => rendimento = value; }

        public double CustosdeProduçãoPorSaca { get => custosdeProduçãoPorSaca; set => custosdeProduçãoPorSaca = value; }

        public double FaturamentoTotalTalhão { get => faturamentoTotalTalhão; set => faturamentoTotalTalhão = value; }

        public int Ano { get => ano; set => ano = value; }
    }
}
