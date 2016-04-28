#load "load-references-debug.fsx"
open FSharp.Data
open FSharp.Charting
open System
open System.IO

// CSV Provider
type FootballData = CsvProvider< @"..\Results.csv">
let data = FootballData.GetSample()
data.Rows
|> Seq.filter(fun r -> r.``Full Time Away Goals`` > r.``Full Time Home Goals``)
|> Seq.countBy(fun r -> r.``Away Team``)
|> Seq.sortByDescending snd
|> Chart.Column
|> Chart.Show

// HTML Provider
type NugetStats = HtmlProvider< @"https://www.nuget.org/stats/packages/FSharp.Core?groupby=ClientName">
let getStatsForPackage packageName =
    NugetStats
        .Load(sprintf "https://www.nuget.org/stats/packages/%s?groupby=ClientName" packageName)
        .Tables
        .Table2
        .Rows
        |> Seq.map(fun row -> row.``Client Name``, row.Downloads)
        |> Seq.sortByDescending snd
        |> Seq.truncate 10

[ getStatsForPackage "FSharp.Core" 
  getStatsForPackage "FSharp.Data"
  getStatsForPackage "Paket" ]
|> Chart.StackedColumn
|> Chart.WithXAxis(LabelStyle = ChartTypes.LabelStyle(Angle = -90, Interval = 1.))
|> Chart.Show

// World Bank Provider
let ctx = FSharp.Data.WorldBankData.GetDataContext()
ctx.Countries.``United Kingdom``.Indicators.``Inflation, consumer prices (annual %)``
|> Chart.Line
|> Chart.Show