#load "load-references.fsx"

open FSharp.Data
open FSharp.Data.Sql
open System.Linq

[<Literal>]
let DbConnection = "Data Source=(localdb)\ProjectsV12;Initial Catalog=AdventureWorksLT;Integrated Security=True;"

// FSharp.Data.SqlClient

// Compile-time safe queries
type SelectCustomers = SqlCommandProvider<"SELECT CustomerID, FirstName, LastName, CompanyName FROM [SalesLT].[Customer]", DbConnection>
let c =
    SelectCustomers.Create().Execute()
    |> Seq.map(fun r -> r.CompanyName)

// Building enums
type Categories = SqlEnumProvider<"SELECT ProductCategoryName, ProductCategoryId FROM SalesLT.vGetAllCategories", DbConnection>
Categories.``Tires and Tubes``

// Bulk insert and datatables
type Programmability = SqlProgrammabilityProvider<DbConnection>
let customerTable = new Programmability.SalesLT.Tables.Customer()



// FSharp.Data.SQLProvider
open FSharp.Data.Sql
open System.Linq

type AdventureWorks = SqlDataProvider<DbConnection>

let ctx = AdventureWorks.GetDataContext()

// Navigate through tables
ctx.``[SalesLT].[CustomerAddress]``

// get a customer back
let customer = ctx.``[SalesLT].[Customer]``.First()

// Individuals support
let tiresAndTubes = ctx.``[SalesLT].[ProductCategory]``.Individuals.``As Name``.``41, Tires and Tubes``

// Update entity
tiresAndTubes.Name <- "Tires and Tubes"
ctx.SubmitUpdates()

// IQueryable support
let customersMr =
    query {
        for customer in ctx.``[SalesLT].[Customer]`` do
        where (customer.Title = "Mr.")
        select (customer.FirstName, customer.LastName)
    } |> Seq.toArray

// Rich query support in F#
// https://msdn.microsoft.com/en-us/library/hh225374.aspx
let titles =
    query {
        for customer in ctx.``[SalesLT].[Customer]`` do
        select (customer.Title)
        distinct } |> Seq.toArray