module DataAccess
open FSharp.Data

[<Literal>]
let DbConnection = "Data Source=(localdb)\ProjectsV12;Initial Catalog=HousePrices;Integrated Security=True"

//TODO: Update this query to find the top 50 rows by town with min and max price limits.
type FindByTownPrice = SqlCommandProvider<"SELECT TOP 10 * FROM dbo.PropertySale", DbConnection>