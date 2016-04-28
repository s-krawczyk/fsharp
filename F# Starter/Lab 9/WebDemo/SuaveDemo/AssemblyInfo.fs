namespace SuaveDemo.AssemblyInfo

open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[<assembly: AssemblyTitle("SuaveDemo")>]
[<assembly: AssemblyDescription("")>]
[<assembly: AssemblyConfiguration("")>]
[<assembly: AssemblyCompany("")>]
[<assembly: AssemblyProduct("SuaveDemo")>]
[<assembly: AssemblyCopyright("Copyright ©  2015")>]
[<assembly: AssemblyTrademark("")>]
[<assembly: AssemblyCulture("")>]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[<assembly: ComVisible(false)>]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[<assembly: Guid("001a2419-fcf6-4010-8cbe-4b97cca8f005")>]

// Version information for an assembly consists of the following four values:
// 
//       Major Version
//       Minor Version 
//       Build Number
//       Revision
// 
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [<assembly: AssemblyVersion("1.0.*")>]
[<assembly: AssemblyVersion("1.0.0.0")>]
[<assembly: AssemblyFileVersion("1.0.0.0")>]

do
    ()

namespace global

[<AutoOpen>]
module Helpers =
    open Newtonsoft.Json
    open Suave.Http
    open Suave.Http.Successful

    let JSON v =
      JsonConvert.SerializeObject(v, JsonSerializerSettings()) |> OK
      >>= Writers.setMimeType "application/json; charset=utf-8"

    let JSONAsync workflow ctx =
        async {
            let! result = workflow
            return! (result |> JSON) ctx
        } 