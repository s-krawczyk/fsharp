#load "load-references-debug.fsx"

open FSharp.Data.TypeProviders
open FSharp.Data

/// Here are URIs to generate a live schema from.
[<Literal>]
let CdyneSoapUri = "http://wsf.cdyne.com/WeatherWS/Weather.asmx?WSDL"
[<Literal>]
let ZipCodesHtmlUri = "http://www.zip-codes.com/search.asp?fld-city=beverly+hills&fld-state=CA&selectTab=2&Submit=Find+ZIP+Codes"
[<Literal>]
let YahooJsonUri = """https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22dallas%2C%20tx%22)&format=json"""
[<Literal>]
let YahooXmlUri = """https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22dallas%2C%20tx%22)&format=xml"""

// 1. TODO: Populate all of the web services using the URI strings above.
type WeatherWsdl = WsdlService<CdyneSoapUri> // <- done for you
type ZipCodes = HtmlProvider<"put the URL to the HTML web page here!">
type JsonWeather = JsonProvider< """put the URL to the JSON service here!""">
type XmlWeather = XmlProvider< """put the URL to the XML service here!""">

// 2. Explore the four URIs above e.g.
let cdyneResult = WeatherWsdl.GetWeatherSoap().GetCityWeatherByZIP("90210") // <- done for you
let htmlTableResult = ZipCodes.GetSample()
let jsonResult = JsonWeather.GetSample()
let xmlResult = XmlWeather.GetSample()

// TODO: Write functions that will parameterise all four services. First one is done for you.
let getCdyneForecast zipCode =
    let client = WeatherWsdl.GetWeatherSoap()
    client.GetCityWeatherByZIP zipCode
let getZipCode(city:string, state:string) : string option = None
let getYahooJsonForecast(city:string, state:string) : int * string = 75, "Sunny"
let getYahooXmlForecast(city:string, state:string) : int * string = 75, "Sunny"

// 4. Review the function below to see how we can compose two different services together.

/// Tries to get zip code from HTML, and if it got a result, tries to get weather forecast from Cdyne
let getWeatherByCityState = getZipCode >> (Option.map getCdyneForecast) >> Option.filter(fun res -> res.Success)

/// Same as above but longhand.
let getWeatherByCityStateLongHand (city,state) =
    let zipCode = getZipCode(city, state)
    let forecast =
        match zipCode with
        | Some zipCode -> Some(getCdyneForecast zipCode)
        | None -> None
    match forecast with
    | Some forecast -> if forecast.Success then Some forecast else None
    | None -> None

// 5. Write an API function that allows you to get the current weather as a temperature and description
// You should be able to choose which service provider you want to use and get back a result.

/// Types of result formats for Yahoo data
type YahooFormat = | JSON | XML
/// Different providers of weather data
type WeatherProvider = | Yahoo of YahooFormat | Cdyne

/// Get the current weather from a specific provider for a given city and state.
/// TODO: Fill this in!!!
let getWeather (provider:WeatherProvider) (city:string, state:string) : (int * string) option =
    match provider with
    | Cdyne ->
        // call cdyne here via composed function
        None
    | Yahoo JSON ->
        // call Yahoo JSON api here
        None
    //TODO: Fill in the missing case here!
    


let londonNow = getWeather (Yahoo JSON) ("London", "UK")
let beverlyHillsNow = getWeather Cdyne ("Beverly Hills", "CA")