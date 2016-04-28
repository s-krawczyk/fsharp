#load "load-references-debug.fsx"
open FSharp.Data
open System
open System.Net

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

// 1. Download from land registry
let wc = new WebClient()
wc.DownloadFile(Uri "http://publicdata.landregistry.gov.uk/market-trend-data/price-paid-data/a/pp-2015-part1.csv", @"pp-2015-part1.csv")

// 2. Create schema from file
type HousePrices = CsvProvider<"pp-2015-part1.csv", HasHeaders=false, Schema = "Transaction unique identifier,Price,Date of Transfer,Postcode,Property Type,Old/New,Duration,PAON,SAON,Street,Locality,Town/City,District,County,PPD Category Type,Record Status">
let firstRow = HousePrices.GetSample().Rows |> Seq.head

// 3. Connect to SQL database
type DB = SqlProgrammabilityProvider<"Data Source=(localdb)\ProjectsV12;Initial Catalog=HousePrices;Integrated Security=True">

// 4. Insert every row and bulk insert
let propertyTable = new DB.dbo.Tables.PropertySale()
for row in HousePrices.GetSample().Rows do
    propertyTable.AddRow(row.``Transaction unique identifier``, row.Price, row.``Date of Transfer``, row.Postcode, row.``Property Type``, row.``Old/New``, row.Duration, row.PAON, row.SAON, row.Street, row.Locality, row.``Town/City``, row.District, row.County, row.``PPD Category Type``, Some row.``Record Status``)
propertyTable.BulkCopy()

