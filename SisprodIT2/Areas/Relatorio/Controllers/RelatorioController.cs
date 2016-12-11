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
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                .SetTitle(new Title { Text = "Historic World Population by Region" })
                .SetSubtitle(new Subtitle { Text = "Source: Wikipedia.org" })
                .SetXAxis(new XAxis
                {
                    Categories = new[] { "Africa", "America", "Asia", "Europe", "Oceania" },
                    Title = new XAxisTitle { Text = string.Empty }
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle
                    {
                        Text = "Population (millions)",
                        Align = AxisTitleAligns.High
                    }
                })
                .SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y +' millions'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Bar = new PlotOptionsBar
                    {
                        DataLabels = new PlotOptionsBarDataLabels { Enabled = true }
                    }
                })
                .SetLegend(new Legend
                {
                    Layout = Layouts.Vertical,
                    Align = HorizontalAligns.Right,
                    VerticalAlign = VerticalAligns.Top,
                    X = -100,
                    Y = 100,
                    Floating = true,
                    BorderWidth = 1,
                    BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                    Shadow = true
                })
                .SetCredits(new Credits { Enabled = false })
                .SetSeries(new[]
                {
                    new Series { Name = "Year 1800", Data = new Data(new object[] { 107, 31, 635, 203, 2 }) },
                    new Series { Name = "Year 1900", Data = new Data(new object[] { 133, 156, 947, 408, 6 }) },
                    new Series { Name = "Year 2008", Data = new Data(new object[] { 973, 914, 4054, 732, 34 }) }
                });

            return View(chart);
        }

    }
}
