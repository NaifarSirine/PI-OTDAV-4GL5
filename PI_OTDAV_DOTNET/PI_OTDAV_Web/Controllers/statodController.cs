using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PI_OTDAV_Web.Controllers
{
    public class statodController : Controller
    {
        // GET: statod
        public ActionResult Index()
        {
            return View();
        }




        OeuvreDeclarationController cntrl = new PI_OTDAV_Web.Controllers.OeuvreDeclarationController();
        PI_OTDAV_Services.Services.oeuvredeclarationservice od = new PI_OTDAV_Services.Services.oeuvredeclarationservice();

        // GET: Demo
        public ActionResult PieChart()
        {
            int total = cntrl.CalculerNbtTotalArtWork();
            long pourcentageMusical = (long)((cntrl.CalculerNbtTotalMusical() * 100) / total);
            long pourcentageTheatre = (long)((cntrl.CalculerNbtTotalTheatre() * 100) / total);
            long pourcentageDance = (long)((cntrl.CalculerNbtTotalDance() * 100) / total);
            long pourcentagePeinture = (long)((cntrl.CalculerNbtTotalPeinture() * 100) / total);
            long pourcentagePoterie = (long)((cntrl.CalculerNbtTotalPoterie() * 100) / total);
            long pourcentageLitterature = (long)((cntrl.CalculerNbtTotalLitterature() * 100) / total);
            long pourcentageSceneario = (long)((cntrl.CalculerNbtTotalScenario() * 100) / total);
            long pourcentageGraphic = (long)((cntrl.CalculerNbtTotalGraphic() * 100) / total);

           
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { PlotShadow = false })
                .SetTitle(new Title { Text = " oeuvres protégées par l\\'OTDAV" })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
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
                            //Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Browser share",
                    Data = new Data(new object[]
                    {
                        new object[] { "Musical", pourcentageMusical },
                        new object[] { "Theatre", pourcentageTheatre },
                        new object[] { "Litterature", pourcentageLitterature },
                        new object[] { "Scenario", pourcentageSceneario },
                        new object[] { "Peinture", pourcentagePeinture },
                        new object[] { "Dance", pourcentageDance },
                         new object[] { "Poteri", pourcentagePoterie },
                        new object[] { "Graphic",pourcentageGraphic }
                    }
                    )
                });

            return View(chart);
        }

        public ActionResult ColumnWithRotatedLabels()
        {
            Highcharts chart = new Highcharts("chart")
             .InitChart(new Chart { Type = ChartTypes.Column, Margin = new[] { 50, 50, 100, 80 } })
             .SetTitle(new Title { Text = "Etat de vos propres oeuvres" })
             .SetXAxis(new XAxis
             {
                 Categories = new[]
                                {
                        "Accepter", "En Attente", "Simple", "Refuser"
                                },
                 Labels = new XAxisLabels
                 {
                     Rotation = -45,
                     Align = HorizontalAligns.Right,
                     Style = "fontSize: '13px',fontFamily: 'Verdana, sans-serif'"
                 }
             })
                            .SetYAxis(new YAxis
                            {
                                Min = 0,
                                Title = new YAxisTitle { Text = "Nombre d\\'oeuvre" }
                            })
                            .SetLegend(new Legend { Enabled = false })
                            .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                            .SetPlotOptions(new PlotOptions
                            {
                                Column = new PlotOptionsColumn
                                {
                                    DataLabels = new PlotOptionsColumnDataLabels
                                    {
                                        Enabled = true,
                                        Rotation = -90,
                                        Color = ColorTranslator.FromHtml("#FFFFFF"),
                                        Align = HorizontalAligns.Right,
                                        X = 4,
                                        Y = 10,
                                        Formatter = "function() { return this.y; }",
                                        Style = "fontSize: '13px',fontFamily: 'Verdana, sans-serif',textShadow: '0 0 3px black'"
                                    }
                                }
                            })
                            .SetSeries(new Series
                            {
                                Name = "Population",
                                Data = new Data(new object[]
                                {
                        od.CountSimpleArtWork(1), od.CountEnAttenteArtWork(1), od.CountRefuserArtWork(1), od.CountAccepterArtWork(1)
                                }),
                            });

            return View(chart);
        }







        public ActionResult ColumnWithRotatedLabelsss()
        {
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { Type = ChartTypes.Column, Margin = new[] { 50, 50, 100, 80 } })
                .SetTitle(new Title { Text = "World\\'s largest cities per 2008" })
                .SetXAxis(new XAxis
                {
                    Categories = new[]
                    {
                        "Accepter", "En Attente", "Simple", "Refuser"
                    },
                    Labels = new XAxisLabels
                    {
                        Rotation = -45,
                        Align = HorizontalAligns.Right,
                        Style = "fontSize: '13px',fontFamily: 'Verdana, sans-serif'"
                    }
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle { Text = "Population (millions)" }
                })
                .SetLegend(new Legend { Enabled = false })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Rotation = -90,
                            Color = ColorTranslator.FromHtml("#FFFFFF"),
                            Align = HorizontalAligns.Right,
                            X = 4,
                            Y = 10,
                            Formatter = "function() { return this.y; }",
                            Style = "fontSize: '13px',fontFamily: 'Verdana, sans-serif',textShadow: '0 0 3px black'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = "Population",
                    Data = new Data(new object[]
                    {
                        od.CountSimpleArtWork(1), od.CountEnAttenteArtWork(1), od.CountRefuserArtWork(1), od.CountAccepterArtWork(1)
                    }),
                });

            return View(chart);
        }


    }
}