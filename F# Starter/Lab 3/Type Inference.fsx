let printName(theName, timeOfDay) =
    let calculateLightLevel(name, time) =
        if name = "Isaac" then "rainy day"
        elif time = "AM" then "sunny day"
        else "dark night"
    let theString =
        let lightLevel = calculateLightLevel(theName, timeOfDay)
        sprintf "Hello, %s on this %s" theName lightLevel
    printfn "%s" theString

let name = printName("Isaac", "rainyday")