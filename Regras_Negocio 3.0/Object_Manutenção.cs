using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
   public class Object_Manutenção
    {
        private string nomeFerramenta;

        private string tipoManutenção;

        private double valorManutenção;

        private DateTime dataManutenção;

        public string NomeFerramenta { get => nomeFerramenta; set => nomeFerramenta = value; }

        public string TipoManutenção { get => tipoManutenção; set => tipoManutenção = value; }

        public double ValorManutenção { get => valorManutenção; set => valorManutenção = value; }

        public DateTime DataManutenção { get => dataManutenção; set => dataManutenção = value; }
    }
}
