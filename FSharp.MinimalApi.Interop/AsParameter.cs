using System.Reflection;

namespace FSharp.MinimalApi;

using Microsoft.FSharp.Core;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Creates a delegate with AsParametersAttribute
/// </summary>
public static class AsParameters
{
    /// <summary>
    /// Creates delegates with AsParametersAttribute
    /// </summary>
    public static Delegate Of<TParam, TResult>(FSharpFunc<TParam, TResult> requestDelegate) =>
        typeof(TResult).IsGenericType &&
        typeof(TResult).GetGenericTypeDefinition() == typeof(Task<>)
            ? CreateAsTask(requestDelegate)
            : typeof(TParam) == typeof(Unit)
                ? typeof(TResult) == typeof(Unit)
                    ? void () => requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                    : () => requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                : typeof(TResult) == typeof(Unit)
                    ? void ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters)
                    : ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters);

    /// <summary>
    /// Creates async delegates with AsParametersAttribute
    /// </summary>
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

    static Delegate CreateAsTask<TParam, TResult>(FSharpFunc<TParam, TResult> requestDelegate)
    {
        var underType = typeof(TResult).GetGenericArguments()[0];
        var method =
            typeof(AsParameters).GetMethod(nameof(OfTask),
                    BindingFlags.Public | BindingFlags.Static)!
                .MakeGenericMethod(typeof(TParam), underType);

        return (Delegate) method.Invoke(null, new object?[] {requestDelegate})!;
    }
}