using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class Object_Ferramentas
    {
        private string nomeFerramenta;

        private DateTime dataAquisição;

        private double valorFerramenta;

        public string NomeFerramenta { get => nomeFerramenta; set => nomeFerramenta = value; }

        public DateTime DataAquisição { get => dataAquisição; set => dataAquisição = value; }

        public double ValorFerramenta { get => valorFerramenta; set => valorFerramenta = value; }
    }
}
