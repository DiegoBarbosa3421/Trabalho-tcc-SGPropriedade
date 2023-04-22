using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class Object_Produção
    {
        private string colaborador;
        private string talhão;
        private string observação;
        private double custoUnitario;
        private double quantidade;
        private double custoTotal;
        private string propriedade;
        private DateTime dataInicio;
        private DateTime dataFim;
       

        public string Colaborador { get => colaborador; set => colaborador = value; }

        public string Talhão { get => talhão; set => talhão = value; }

        public string Observação { get => observação; set => observação = value; }

        public double CustoUnitario { get => custoUnitario; set => custoUnitario = value; }

        public double Quantidade { get => quantidade; set => quantidade = value; }

        public double CustoTotal { get => custoTotal; set => custoTotal = value; }

        public string Propriedade { get => propriedade; set => propriedade = value; }

        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }

        public DateTime DataFim { get => dataFim; set => dataFim = value; }
    }
}
