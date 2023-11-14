namespace FSharp.MinimalApi;

using Microsoft.FSharp.Core;
using Microsoft.AspNetCore.Http;

public static class AsParameters
{
    public static Delegate Of<TParam, TResult>(FSharpFunc<TParam, TResult> requestDelegate) =>
        ([AsParameters] TParam parameters) =>
            requestDelegate.Invoke(parameters);

    public static Delegate Of<TParam, TResult>(FSharpFunc<TParam, Task<TResult>> requestDelegate) =>
        ([AsParameters] TParam parameters) =>
            requestDelegate.Invoke(parameters);
}