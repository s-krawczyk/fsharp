namespace WebDemo

open Owin
open System.Web.Http
open Newtonsoft.Json.Serialization

type DefaultRoute = { id : RouteParameter }

type Startup() =
    member __.Configuration(appBuilder : IAppBuilder) =
        use config =
            let config = new HttpConfiguration()
            config.MapHttpAttributeRoutes()
            config.Formatters.Remove(config.Formatters.XmlFormatter) |> ignore
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- DefaultContractResolver()

            config.Routes.MapHttpRoute( 
                name = "DefaultApi", 
                routeTemplate = "api/{controller}/{id}", 
                defaults = { id = RouteParameter.Optional })
                |> ignore

            config.EnsureInitialized()
            config
        
        appBuilder.UseWebApi config |> ignore





















