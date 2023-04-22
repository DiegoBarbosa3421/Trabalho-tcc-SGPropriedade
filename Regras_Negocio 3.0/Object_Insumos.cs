using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class Object_Insumos
    {
        private string nomeInsumo;

        private DateTime dataAquisição;

        private double quantidade;

        private double valorUnitario;

        private double valorTotal;

        private string observação;

        public string NomeInsumo { get => nomeInsumo; set => nomeInsumo = value; }

        public DateTime DataAquisição { get => dataAquisição; set => dataAquisição = value; }

        public double Quantidade { get => quantidade; set => quantidade = value; }

        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }

        public double ValorTotal { get => valorTotal; set => valorTotal = value; }

        public string Observação { get => observação; set => observação = value; }
    }
}
