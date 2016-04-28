type Direction = | North | East | South | West
type WeatherDetails = 
    | Sunny
    | Raining of rainfallCm : int
    | Windy of windSpeed : int * Direction
    | Snowing of snowFallCm : int

type Weather = { Temperature : int; Details : WeatherDetails }

let weather = { Temperature = 19; Details = Windy(5, North) }

let printForecast weather =
    let forecast =
        match weather.Details with
        | Sunny -> "sunny with clear skies"
        | Raining 1 -> "cloudy with light rain"
        | Raining rainfall -> sprintf "raining approx %dcm" rainfall
        | Windy(speed, North) -> sprintf "windy with a North-facing breeze of %dmph" speed
        | Windy(speed, direction) -> sprintf "windy with a %Aernly breeze of %dmph" direction speed
        | Snowing fall when fall < 3 -> "light snow"
        | Snowing fall -> sprintf "heavy snow of %dcm" fall
    printfn "Today's weather will be %d degrees and %s." weather.Temperature forecast

printForecast weather