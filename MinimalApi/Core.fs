namespace FSharp.MinimalApi

open Microsoft.AspNetCore.Builder

type ConfigurationSteps = ConfigurationSteps of (WebApplication -> WebApplication) list
type internal App = WebApplication

