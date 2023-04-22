using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegrasNegocio
{
    public class RN_Relatorios
    {
        Database.Relatorios relatorios;
        DataTable listarTabela;

        private DateTime dataAtual;
        private DateTime dataInicio;
        private DateTime dataFim;
        private double totalValorServiços;
        private double totalValorInsumos;
        private double totalArecadadoFaturamento;
        private double totalCustoProdução;
        private double totalGastoscomFerramentas;
        private double totalGastoManutenções;

        public DateTime DataAtual { get => dataAtual; private set => dataAtual = value; }

        public DateTime DataInicio { get => dataInicio; private set => dataInicio = value; }

        public DateTime DataFim { get => dataFim; private set => dataFim = value; }

        public double TotalValorServiços { get => totalValorServiços; private set => totalValorServiços = value; }

        public double TotalValorInsumos { get => totalValorInsumos; private set => totalValorInsumos = value; }

        public double TotalArecadadoFaturamento { get => totalArecadadoFaturamento;private  set => totalArecadadoFaturamento = value; }

        public double TotalCustoProdução { get => totalCustoProdução; private set => totalCustoProdução = value; }

        public double TotalGastoscomFerramentas { get => totalGastoscomFerramentas; private  set => totalGastoscomFerramentas = value; }

        public double TotalGastoManutenções { get => totalGastoManutenções; private set => totalGastoManutenções = value; }


        private List<Object_serviços> relatorioServiços;
        public List<Object_serviços> RelatoriosServiços { get => relatorioServiços; private set => relatorioServiços = value; }

        private List<Object_Produção> relatorioProdução;
        public List<Object_Produção> RelatorioProdução { get => relatorioProdução; private set => relatorioProdução = value; }

        private List<Object_Insumos> relatorioInsumos;
        public List<Object_Insumos> RelatorioInsumos { get => relatorioInsumos; private set => relatorioInsumos = value; }

        private List<Object_Faturamento> relatorioFaturamento;
        public List<Object_Faturamento> RelatorioFaturamento { get => relatorioFaturamento; private set => relatorioFaturamento = value; }
        
        private List<Object_Ferramentas> relatorioFerramenta;
        public List<Object_Ferramentas> RelatorioFerramenta { get => relatorioFerramenta; private set => relatorioFerramenta = value; }

        private List<Object_Manutenção> relatorioManutenção;
        public List<Object_Manutenção> RelatorioManutenção { get => relatorioManutenção; private set => relatorioManutenção = value; }
       
        private List<Object_Rendimento> relatorioRendimento;
        public List<Object_Rendimento> RelatorioRendimento { get => relatorioRendimento; private set => relatorioRendimento = value; }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Relatorios_Por_Serviços(DateTime dataConsultaInicio, DateTime dataConsultaFim)
        {
            RelatoriosServiços = new List<Object_serviços>();
            listarTabela = new DataTable();
            relatorios = new Database.Relatorios();

            DataAtual = DateTime.Today;
            DataFim = dataConsultaFim;
            DataInicio = dataConsultaInicio;

            listarTabela = relatorios.Relatorios_de_Serviços(dataConsultaInicio, dataConsultaFim);

            try
            {

                for (int i = 0; i < listarTabela.Rows.Count; i++)
                {
                    Object_serviços rl = new Object_serviços()
                    {
                        Colaborador = Convert.ToString(listarTabela.Rows[i]["colaborador"].ToString()),
                        ValorServiços = Convert.ToDouble(listarTabela.Rows[i]["valorServiços"].ToString()),
                        NomeServiços = Convert.ToString(listarTabela.Rows[i]["serviços"].ToString()),
                        Talhão = Convert.ToString(listarTabela.Rows[i]["talhão"].ToString()),
                        DataInicio = Convert.ToDateTime(listarTabela.Rows[i]["dataInicio"].ToString()),
                        DataFim = Convert.ToDateTime(listarTabela.Rows[i]["dataTermino"].ToString()),



                    };
                    RelatoriosServiços.Add(rl);

                    TotalValorServiços = TotalValorServiços + Convert.ToDouble(listarTabela.Rows[i]["valorServiços"].ToString());

                }
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Relatorio_Produção(DateTime dataConsultaInicio, DateTime dataConsultaFim, string talhão, string colaborador, string propriedade)
        {
            RelatorioProdução = new List<Object_Produção>();
            listarTabela = new DataTable();
            relatorios = new Database.Relatorios();

            DataAtual = DateTime.Today;
            DataFim = dataConsultaFim;
            DataInicio = dataConsultaInicio;

            listarTabela = relatorios.Relatorios_de_Produção(dataConsultaInicio, dataConsultaFim, talhão, colaborador, propriedade);

            try
            {
                for (int i = 0; i < listarTabela.Rows.Count; i++)
                {
                    Object_Produção op = new Object_Produção()
                    {
                        Propriedade = Convert.ToString(listarTabela.Rows[i]["propriedade"].ToString()),
                        Quantidade = Convert.ToDouble(listarTabela.Rows[i]["quantidade"].ToString()),
                        CustoUnitario = Convert.ToDouble(listarTabela.Rows[i]["custoUnitario"].ToString()),
                        DataInicio = Convert.ToDateTime(listarTabela.Rows[i]["dataInicio"].ToString()),
                        DataFim = Convert.ToDateTime(listarTabela.Rows[i]["dataTermino"].ToString()),
                        Colaborador = Convert.ToString(listarTabela.Rows[i]["colaborador"].ToString()),
                        Talhão = Convert.ToString(listarTabela.Rows[i]["talhão"].ToString()),
                        CustoTotal = Convert.ToDouble(listarTabela.Rows[i]["quantidade"].ToString()) * Convert.ToDouble(listarTabela.Rows[i]["custoUnitario"].ToString()),
                        Observação = Convert.ToString(listarTabela.Rows[i]["observação"].ToString()),

                       
                    };
                    RelatorioProdução.Add(op);

                    totalCustoProdução = totalCustoProdução + Convert.ToDouble(listarTabela.Rows[i]["quantidade"].ToString()) * Convert.ToDouble(listarTabela.Rows[i]["custoUnitario"].ToString());
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex);
            }

        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
        public void Relatorios_de_Insumos(DateTime dataConsultaInicio, DateTime dataFim)
        {
            RelatorioInsumos = new List<Object_Insumos>();
            relatorios = new Database.Relatorios();
            listarTabela = new DataTable();

            DataAtual = DateTime.Today;
            DataFim = dataFim;
            DataInicio = dataConsultaInicio;

            listarTabela = relatorios.Relatorios_de_Insumos(dataConsultaInicio, dataFim);


            try
            {
                for (int i = 0; i < listarTabela.Rows.Count; i++)
                {
                    Object_Insumos oi = new Object_Insumos()
                    {
                        NomeInsumo = Convert.ToString(listarTabela.Rows[i]["nomeInsumos"].ToString()),
                        DataAquisição = Convert.ToDateTime(listarTabela.Rows[i]["dataAquisiçao"].ToString()),
                        Quantidade = Convert.ToDouble(listarTabela.Rows[i]["quantidadeComprada"].ToString()),
                        ValorUnitario = Convert.ToDouble(listarTabela.Rows[i]["valorUnitario"].ToString()),
                        ValorTotal = Convert.ToDouble(listarTabela.Rows[i]["valortotal"].ToString()),
                        Observação = Convert.ToString(listarTabela.Rows[i]["observação"].ToString()),

                    };

                    RelatorioInsumos.Add(oi);

                    TotalValorInsumos = TotalValorInsumos + Convert.ToDouble(listarTabela.Rows[i]["valortotal"].ToString());

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Relatorios_de_Ferramentas(DateTime dataConsultaInicio, DateTime dataConsultaFim)
        {
            RelatorioFerramenta = new List<Object_Ferramentas>();
            listarTabela = new DataTable();
            relatorios = new Database.Relatorios();

            DataAtual = DateTime.Today;
            DataFim = dataConsultaFim;
            DataInicio = dataConsultaInicio;

            try
            {
                listarTabela = relatorios.Relatoriosa_Ferramentas(dataConsultaInicio, dataConsultaFim);

                for (int i = 0; i < listarTabela.Rows.Count; i++)
                {
                    Object_Ferramentas of = new Object_Ferramentas() {
                        NomeFerramenta = Convert.ToString(listarTabela.Rows[i]["nomeFerramenta"].ToString()),
                        ValorFerramenta = Convert.ToDouble(listarTabela.Rows[i]["valorFerramenta"].ToString()),
                        DataAquisição = Convert.ToDateTime(listarTabela.Rows[i]["datadeAquisição"].ToString())
                    };

                    RelatorioFerramenta.Add(of);

                    TotalGastoscomFerramentas = TotalGastoscomFerramentas + Convert.ToDouble(listarTabela.Rows[i]["valorFerramenta"].ToString());
                } 

 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message  + ex);
            }

            Relatorio_Manutenções(dataConsultaInicio, dataConsultaFim);
        }

        private void Relatorio_Manutenções(DateTime dataConsultaInicio, DateTime dataConsultaFim)
        {
            RelatorioManutenção = new List<Object_Manutenção>();
            listarTabela = new DataTable();
            relatorios = new Database.Relatorios();

            DataAtual = DateTime.Today;
            DataFim = DataFim;
            DataInicio = DataInicio;


            try
            {
                listarTabela = relatorios.Relatoriosa__Manutenções(dataConsultaInicio, dataConsultaFim);
                for (int i = 0; i < listarTabela.Rows.Count; i++)
                {
                    Object_Manutenção om = new Object_Manutenção()
                    {
                        NomeFerramenta = Convert.ToString(listarTabela.Rows[i]["nomeFerramenta"].ToString()),
                        ValorManutenção = Convert.ToDouble(listarTabela.Rows[i]["valorManutenção"].ToString()),
                        DataManutenção = Convert.ToDateTime(listarTabela.Rows[i]["dataManutenção"].ToString()),
                        TipoManutenção = Convert.ToString(listarTabela.Rows[i]["tipoManutenção"].ToString())

                    };
                    RelatorioManutenção.Add(om);

                    TotalGastoManutenções = TotalGastoManutenções + Convert.ToDouble(listarTabela.Rows[i]["valorManutenção"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Relatorio_Faturamento(DateTime dataConsultaInicio, DateTime dataConsultaFim)
        {
            RelatorioFaturamento = new List<Object_Faturamento>();
            listarTabela = new DataTable();
            relatorios = new Database.Relatorios();

            DataAtual = DateTime.Today;
            DataFim = dataConsultaFim;
            DataInicio = dataConsultaInicio;

            try
            {
                listarTabela = relatorios.Relatorio__Faturamento(dataConsultaInicio, dataConsultaFim);

                for (int i = 0; i < listarTabela.Rows.Count; i++)
                {
                    Object_Faturamento of = new Object_Faturamento()
                    {
                        Propriedade = Convert.ToString(listarTabela.Rows[i]["nomePropriedade"].ToString()),
                        NomeTalhão = Convert.ToString(listarTabela.Rows[i]["nomeTalhão"].ToString()),
                        ValorUnitario = Convert.ToDouble(listarTabela.Rows[i]["valorUnitarioArrecadado"].ToString()),
                        Valortotal = Convert.ToDouble(listarTabela.Rows[i]["valorTotalArrecadado"].ToString()),
                        Quantidade = Convert.ToDouble(listarTabela.Rows[i]["quantidadeFaturamento"].ToString()),
                        Data = Convert.ToDateTime(listarTabela.Rows[i]["dataFAturamento"].ToString()),
                        TipoCafé = Convert.ToString(listarTabela.Rows[i]["tipoDeCafé"].ToString()),
                    };

                    RelatorioFaturamento.Add(of);

                    TotalArecadadoFaturamento = TotalArecadadoFaturamento + Convert.ToDouble(listarTabela.Rows[i]["valorTotalArrecadado"].ToString());
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Relatorio_Completo(DateTime dataConsultaInicio, DateTime dataConsultaFim)
        {
            Relatorios_Por_Serviços(dataConsultaInicio, dataConsultaFim);
            Relatorios_de_Ferramentas(dataConsultaInicio, dataConsultaFim);
            Relatorio_Produção(dataConsultaInicio, dataConsultaFim , "", "", "");
            Relatorios_de_Insumos(dataConsultaInicio, dataConsultaFim);
            Relatorio_Faturamento(dataConsultaInicio, dataConsultaFim);
            Relatorio_Rendimento(RelatoriosServiços, RelatorioInsumos, RelatorioFerramenta, RelatorioManutenção, RelatorioFaturamento, RelatorioProdução);
        }

        private void Relatorio_Rendimento(List<Object_serviços> obServiços, List<Object_Insumos> obInsumos, List<Object_Ferramentas> obFerramentas, List<Object_Manutenção> obManutenções, List<Object_Faturamento> obFaturamento, List<Object_Produção> obProdução)
        {
            RelatorioRendimento = new List<Object_Rendimento>();

            double custoTotal;
            try
            {


                var grupoInsumos = new Object_Insumos
                {
                    ValorTotal = obInsumos.Sum(s => s.ValorTotal)
                };

                var grupoFerramentas = new Object_Ferramentas
                {
                    ValorFerramenta = obFerramentas.Sum(s => s.ValorFerramenta)
                };

                var grupoManutenções = new Object_Manutenção
                {
                    ValorManutenção = obManutenções.Sum(s => s.ValorManutenção)
                };

                var grupoProdução = RelatorioProdução
                   .Where(p => p.Observação == "descascado" || p.Observação == "despolpado")
                   .GroupBy(p => new { p.Talhão, p.Propriedade })
                   .Select(g => new Object_Produção
                   {
                       Talhão = g.Key.Talhão,
                       Propriedade = g.Key.Propriedade,
                       CustoTotal = g.Sum(p => p.CustoTotal),
                       Quantidade = g.Sum(p => p.Quantidade)
                   })
                   .ToList();

                int numeroTalhão = grupoProdução.Count();
                custoTotal = grupoFerramentas.ValorFerramenta + grupoManutenções.ValorManutenção + grupoInsumos.ValorTotal;

                var grupoServicos = obServiços
                     .GroupBy(s => s.Talhão)
                     .Select(g => new Object_serviços
                     {
                         Talhão = g.Key,
                         ValorServiços = g.Sum(s => s.ValorServiços) + custoTotal / numeroTalhão
                     })
                     .ToList();  


                var grupoFaturamento = obFaturamento
                    .GroupBy(s => s.NomeTalhão)
                    .Select(g => new Object_Faturamento
                    {
                        NomeTalhão = g.Key,
                        Valortotal = g.Sum(s => s.Valortotal),
                        Quantidade = g.Sum(s => s.Quantidade),
                        Propriedade = g.FirstOrDefault()?.Propriedade,
                        Data = Convert.ToDateTime(g.FirstOrDefault()?.Data),

                    })
                    .ToList();


                foreach (var grupo in grupoFaturamento)
                {
                    var talhao = grupo.NomeTalhão;
                    var custoProducao = grupoProdução.FirstOrDefault(s => s.Talhão == talhao)?.CustoTotal ?? 0;
                    var valorServicos = grupoServicos.FirstOrDefault(s => s.Talhão == talhao)?.ValorServiços ?? 0;
                    var quantidade = grupoProdução.FirstOrDefault(s => s.Talhão == talhao)?.Quantidade ?? 0;
                    var ano = Convert.ToInt32(grupoFaturamento.FirstOrDefault(s => s.NomeTalhão == talhao)?.Data.Year ?? DateTime.MinValue.Year);
                    var custosProducaoPorSaca = (grupo.Valortotal - (valorServicos + custoProducao)) / quantidade;

                    Object_Rendimento or = new Object_Rendimento()
                    {
                        Talhão = talhao,
                        CustosdeProduçãoPorSaca = Convert.ToDouble(custosProducaoPorSaca),
                        Rendimento = Convert.ToDouble(grupo.Valortotal - (valorServicos + custoProducao)),
                        FaturamentoTotalTalhão = Convert.ToDouble(grupoFaturamento.FirstOrDefault(s => s.NomeTalhão == talhao)?.Valortotal ?? 0),
                        Propriedade = Convert.ToString(grupoFaturamento.FirstOrDefault(s => s.NomeTalhão == talhao)?.Propriedade ?? ""),
                        Ano = Convert.ToInt32(ano)

                    };

                    RelatorioRendimento.Add(or);
                }




            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
