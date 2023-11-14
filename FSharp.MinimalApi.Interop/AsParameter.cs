namespace FSharp.MinimalApi;

using Microsoft.FSharp.Core;
using Microsoft.AspNetCore.Http;

public static class AsParameters
{
    public static Delegate Of<TParam, TResult>(FSharpFunc<TParam, TResult> requestDelegate) =>
        typeof(TParam) == typeof(Unit)
            ? typeof(TResult) == typeof(Unit)
                ? void () => requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                : () => requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
            : typeof(TResult) == typeof(Unit)
                ? void ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters)
                : ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters);

    public static Delegate OfTask<TParam, TResult>(
        FSharpFunc<TParam, Task<TResult>> requestDelegate) =>
        typeof(TParam) == typeof(Unit)
            ? typeof(TResult) == typeof(Unit)
                ? Task ([AsParameters] TParam parameters) =>
                requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                : ([AsParameters] TParam parameters) =>
                requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
            : typeof(TResult) == typeof(Unit)
                ? Task ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters)
                : ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters);
}