using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegrasNegocio
{
    public class Util
    {
        DataTable listarTabela;
        public int RetornarIdTalhão(string talhão)
        {
            Database.talhão Talhão = new Database.talhão();

            int idtalhão = 0;

            listarTabela = new DataTable();

            listarTabela = Talhão.PesquisarTalhão(talhão);

            idtalhão = Convert.ToInt32(listarTabela.Rows[0]["idTalhão"].ToString());

            return idtalhão;
        }

        public int RetornaridColaborador(string colaborador)
        {
            Database.Colaborador Colaborador = new Database.Colaborador();

            int idcolaborador = 0;

            listarTabela = new DataTable();

            listarTabela = Colaborador.PesquisarColaborador(colaborador);

            idcolaborador = Convert.ToInt32(listarTabela.Rows[0]["idColaborador"].ToString());

            return idcolaborador;
        }
        public int RetornaridInsumos(string insumos)
        {
            Database.Insumos insumo = new Database.Insumos();
            int idInsumo = 0;

            listarTabela = new DataTable();

            listarTabela = insumo.PesquisarInsumos(insumos);

            idInsumo = Convert.ToInt32(listarTabela.Rows[0]["idInsumos"].ToString());

            return idInsumo;
        }

        public int RetornaridServiços(string serviços)
        {
            Database.CadastroServiço serviço = new Database.CadastroServiço();

            int idServiços = 0;

            listarTabela = new DataTable();

            listarTabela = serviço.PesquisarServiço(serviços);

            idServiços = Convert.ToInt32(listarTabela.Rows[0]["idserviço"].ToString());

            return idServiços;
        }

        public int RetornaridPropriedade(string propriedades)
        {
            Database.Propriedade propriedade = new Database.Propriedade();

            int idPropriedade = 0;

            listarTabela = new DataTable();

            listarTabela = propriedade.PesquisarPropriedade(propriedades);

            idPropriedade = Convert.ToInt32(listarTabela.Rows[0]["idPropriedade"].ToString());


            return idPropriedade;
        }
    }
}
