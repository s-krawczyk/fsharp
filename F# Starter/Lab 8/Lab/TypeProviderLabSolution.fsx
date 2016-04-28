#load "load-references.fsx"

open Microsoft.FSharp.Data.TypeProviders
open FSharp.Data

/// Here are URIs to generate a live schema from.
[<Literal>]
let CdyneSoapUri = "http://wsf.cdyne.com/WeatherWS/Weather.asmx?WSDL"
[<Literal>]
let ZipCodesHtmlUri = "http://www.zip-codes.com/search.asp?fld-city=beverly+hills&fld-state=CA&selectTab=2&Submit=Find+ZIP+Codes"
[<Literal>]
let YahooJsonUri = """https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22nome%2C%20ak%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys"""
[<Literal>]
let YahooXmlUri = """https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22nome%2C%20ak%22)&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys"""

type WeatherWsdl = WsdlService<CdyneSoapUri>
type ZipCodes = HtmlProvider<ZipCodesHtmlUri>
type JsonWeather = JsonProvider<YahooJsonUri>
type XmlWeather = XmlProvider<YahooXmlUri>

let getCdyneForecast zipCode =
    let client = WeatherWsdl.GetWeatherSoap()
    client.GetCityWeatherByZIP zipCode
let getZipCode(city, state) = 
    let result = sprintf "http://www.zip-codes.com/search.asp?fld-city=%s&fld-state=%s&selectTab=2&Submit=Find+ZIP+Codes" city state |> ZipCodes.Load
    if (result.Tables.Html.ToString().Contains "No records match your search parameters.") then None
    else
        result.Tables.``Free ZIP Code Finder``.Rows
        |> Seq.map(fun r -> r.``Zip Code``.ToString())
        |> Seq.tryHead
let getYahooJsonForecast(city:string, state:string) : int * string =
    let forecast = JsonWeather.Load ("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + city + "%2C%20" + state + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys")
    forecast.Query.Results.Channel.Item.Condition.Temp, forecast.Query.Results.Channel.Description
let getYahooXmlForecast(city:string, state:string) : int * string =
    let forecast = XmlWeather.Load ("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + city + "%2C%20" + state + "%22)&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys")
    forecast.Results.Channel.Item.Condition.Temp, forecast.Results.Channel.Description

/// Tries to get zip code from HTML, and if it got a result, tries to get weather forecast from Cdyne
let getWeatherByCityState = getZipCode >> (Option.map getCdyneForecast) >> Option.filter(fun res -> res.Success)

/// Types of result formats for Yahoo data
type YahooFormat = | JSON | XML
/// Different providers of weather data
type WeatherProvider = | Yahoo of YahooFormat | Cdyne

/// Get the current weather from a specific provider for a given city and state.
let getWeather provider (city, state) =
    match provider with
    | Yahoo XML ->
        let res = XmlWeather.Load(sprintf """https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text="%s, %s")&format=xml""" city state)
        Some(res.Results.Channel.Item.Condition.Temp, res.Results.Channel.Item.Condition.Text)
    | Yahoo JSON ->
        let res = JsonWeather.Load(sprintf """https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text="%s, %s")&format=json""" city state)
        Some(res.Query.Results.Channel.Item.Condition.Temp, res.Query.Results.Channel.Item.Condition.Text)
    | Cdyne ->
        getWeatherByCityState (city, state)
        |> Option.map(fun res -> int res.Temperature, res.Description)

let londonNow = getWeather (Yahoo JSON) ("London", "UK")
let beverlyHillsNow = getWeather Cdyne ("Beverly Hills", "CA")