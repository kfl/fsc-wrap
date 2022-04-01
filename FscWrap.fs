open System.IO
open FSharp.Compiler.CodeAnalysis

// Create an interactive checker instance
let checker = FSharpChecker.Create()

[<EntryPoint>]
let main args =
    printfn "Arguments passed to fsc-wrap : %A" args
    let errors, exitCode =
        Array.append [| "fsc.exe" |] args
        |> checker.Compile
        |> Async.RunSynchronously
    printfn "Compiler errors %A" errors
    printfn "Compiler exit code was %i" exitCode
    exitCode
