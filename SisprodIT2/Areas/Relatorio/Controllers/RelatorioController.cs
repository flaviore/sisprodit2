using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Relatorio.Models;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts;
using System.Drawing;
using Point = DotNet.Highcharts.Options.Point;
using SisprodIT2.Map;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Areas.Relatorio.Controllers
{
    public class RelatorioController : Controller
    {
        //
        // GET: /Relatorio/Relatorio/

        private DataContext db = new DataContext();

        public ActionResult QtdChamados()
        {
            //ViewBag.QtdChamados = new List<QtdChamado>() { 
            //    new QtdChamado() { Name = "Atendido", Y = 40},
            //    new QtdChamado() { Name = "Não Atendido", Y = 60}
            //};

            int pendentes = db.Chamados.Where(x => x.Status == "Pendente").Count();
            int atribuidos = db.Chamados.Where(x => x.Status == "Atribuido").Count();

            ViewBag.Pendentes = pendentes;
            ViewBag.Atribuidos = atribuidos;
            ViewBag.Total = pendentes + atribuidos;

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { PlotShadow = false })
                .SetCredits(new Credits { Enabled = false })
                .SetTitle(new Title { Text = "Relatório de Chamados Pendentes e Atribuídos" })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ Math.round(this.percentage) + '%'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        Cursor = Cursors.Pointer,
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Color = ColorTranslator.FromHtml("#000000"),
                            ConnectorColor = ColorTranslator.FromHtml("#000000"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ Math.round(this.percentage) + '%'; }"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Chamados",
                    Data = new Data(new object[]
                    {
                        //new object[] { "Firefox", 45.0 },
                        //new object[] { "IE", 26.8 },
                        //new Point
                        //{
                        //    Name = "Chrome",
                        //    Y = 12.8,
                        //    Sliced = true,
                        //    Selected = true
                        //},
                        //new object[] { "Safari", 8.5 },
                        new object[] { "Pendente", pendentes },
                        new object[] { "Atribuido", atribuidos }
                    })
                });

            return View(chart);
        }

        public ActionResult QtdAtendimentoUsuario()
        {
            DataContext db2 = new DataContext();
            var usuarios = db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao));
            List<int> count = new List<int>();

            List<QtdAtendimentoUsuarioViewModel> QtdAtendimentoUsuario = new List<QtdAtendimentoUsuarioViewModel>();

            foreach (var item in usuarios)
            {
                int totalChamados = db2.Chamados.Where(x => x.FuncionarioCriadorId == item.FuncionarioModelId).Count();
                count.Add(totalChamados);

                QtdAtendimentoUsuario.Add(new QtdAtendimentoUsuarioViewModel() { usuario = item.Nome, total = totalChamados});
            }

            object[] total = count.Select(x => (object)x).ToArray();

            // Passando os usuarios e totais para a View
            ViewBag.Usuarios = QtdAtendimentoUsuario;


            // Iniciando o gráfico
            Highcharts chart = new Highcharts("chart");

            chart.InitChart(new Chart
                {
                    DefaultSeriesType = ChartTypes.Bar,
                    BorderWidth = 1,
                    BorderColor = Color.LightGray
                });
            
            chart.SetTitle(new Title { Text = "Quantitativo de chamados criados por usuários" });
            
            chart.SetSubtitle(new Subtitle { Text = "" });
            
            chart.SetXAxis(new XAxis
                {
                    Categories = usuarios.Select(u => u.Nome).ToArray(),
                    //Categories = new string[] { "A", "B", "C" },
                    Title = new XAxisTitle { Text = string.Empty }

                });
            
            chart.SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle
                    {
                        Text = "Chamados (total)",
                        Align = AxisTitleAligns.High
                    }
                });
            
            chart.SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y +' chamados'; }" });
            
            chart.SetPlotOptions(new PlotOptions
                {
                    Bar = new PlotOptionsBar
                    {
                        DataLabels = new PlotOptionsBarDataLabels { Enabled = true }
                    }
                });
            
            chart.SetLegend(new Legend
                {
                    Layout = Layouts.Vertical,
                    Align = HorizontalAligns.Right,
                    VerticalAlign = VerticalAligns.Top,
                    X = -30,
                    Y = 30,
                    Floating = true,
                    BorderWidth = 1,
                    BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                    Shadow = true
                });
            
            chart.SetCredits(new Credits { Enabled = false });

            
            chart.SetSeries(new[]{
                //new Series { Name = "Ocorrências", Data = new Data(new object[] {total.ToArray()})}
                new Series { Name = "Ocorrências", Data = new Data(total)}
            });

            //chart.SetSeries(series.Select(s => new Series { Type = s.Type, Name = s.Name, Data = s.Data }).ToArray());

            //chart.SetSeries(new[]
            //{
            //    //series.Select(s => (object)new Series { Name = s.Name, Data = s.Data}).ToArray()
            //    new Series { Name = "Year 1800", Data = new Data(new object[] { 107, 100, 80 }) }
            //});

            return View(chart);

        }
    }
}
