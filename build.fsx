#load "./build/helpers.fsx"

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Helpers
open Fake.Core.TargetOperators

initEnviroment ()

help "Run dotnet clean in everty project"

target "clean" (fun _ -> !! "**/bin" ++ "**/obj" |> Shell.cleanDirs)

help "Run dotnet build in every project"

target "build" (fun _ ->
    solutionDir
    |> DotNet.build (fun c ->
        { c with
            Configuration = DotNet.BuildConfiguration.Release }))

help "Run dotnet restore in everty project"

target "restore" (fun _ ->
    DotNet.restore id |> ignore
    DotNet.exec id "tool restore" |> ignore)

help "Run all tests"

target "test" (fun ctx ->
    !! "**/**.Tests*.*sproj"
    |> printFiles ctx.TargetInfo.Name
    |> Seq.iter dotnetTest)

help "Update all local tools"
target "update-tools" (run updateLocalTools)

help "Run all tests and generate coverage report"

target "report" (fun _ ->

    generateCoverageReport ()

    let explorer = if Environment.isWindows then "explorer" else "open"

    Shell.Exec(explorer, Path.combine testReportFolder "index.htm") |> ignore)


help "just generate the coverage report"
target' "generate-report" generateCoverageReport

help "check code formatting with fantomas"
target "lint" (run fantomasCheck)

help "format code"
target "format" (run fantomasFormat)


"clean" ?=> "restore" ==> "build"
"build" ==> "test"
"test" ==> "report"
"restore" ==> "lint"
"restore" ==> "format"

runWithDefaultTarget "help"
