using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
   public class Object_serviços
    {
        
        private double valorServiços;
        private string nomeServiços;
        private string colaborador;
        private string talhão;
        private DateTime dataInicio;
        private DateTime dataFim;
   
        public double ValorServiços { get => valorServiços; set => valorServiços = value; }
        public string NomeServiços { get => nomeServiços; set => nomeServiços = value; }
        public string Colaborador { get => colaborador; set => colaborador = value; }
        public string Talhão { get => talhão; set => talhão = value; }
        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateTime DataFim { get => dataFim; set => dataFim = value; }
    }
}
