using System.Reflection;
using Microsoft.FSharp.Control;

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
        IsTask<TResult>()
            ? CreateDynamic(nameof(OfTask), requestDelegate)
            : IsAsync<TResult>()
                ? CreateDynamic(nameof(OfAsync), requestDelegate)
                : typeof(TParam) == typeof(Unit)
                    ? typeof(TResult) == typeof(Unit)
                        ? void () => requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                        : () => requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                    : typeof(TResult) == typeof(Unit)
                        ? void ([AsParameters] TParam parameters) =>
                        requestDelegate.Invoke(parameters)
                        : ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters);

    /// <summary>
    /// Creates task delegates with AsParametersAttribute
    /// </summary>
    public static Delegate OfTask<TParam, TResult>(
        FSharpFunc<TParam, Task<TResult>> requestDelegate) =>
        typeof(TParam) == typeof(Unit)
            ? typeof(TResult) == typeof(Unit)
                ? Task ([AsParameters] TParam parameters) =>
                requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
                : Task<TResult> ([AsParameters] TParam parameters) =>
                requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>())
            : typeof(TResult) == typeof(Unit)
                ? Task ([AsParameters] TParam parameters) => requestDelegate.Invoke(parameters)
                : Task<TResult> ([AsParameters] TParam parameters) => requestDelegate
                    .Invoke(parameters);

    /// <summary>
    /// Creates async delegates with AsParametersAttribute
    /// </summary>
    public static Delegate OfAsync<TParam, TResult>(
        FSharpFunc<TParam, FSharpAsync<TResult>> requestDelegate) =>
        typeof(TParam) == typeof(Unit)
            ? typeof(TResult) == typeof(Unit)
                ? Task ([AsParameters] TParam parameters, CancellationToken cancellationToken) =>
                FSharpAsync.StartImmediateAsTask(
                    requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>()),
                    cancellationToken)
                : Task<TResult> ([AsParameters] TParam parameters,
                        CancellationToken cancellationToken) =>
                    FSharpAsync.StartImmediateAsTask(
                        requestDelegate.Invoke(Operators.Unchecked.DefaultOf<TParam>()),
                        cancellationToken)
            : typeof(TResult) == typeof(Unit)
                ? Task ([AsParameters] TParam parameters, CancellationToken cancellationToken) =>
                FSharpAsync.StartImmediateAsTask(
                    requestDelegate.Invoke(parameters),
                    cancellationToken)
                : ([AsParameters] TParam parameters, CancellationToken cancellationToken) =>
                FSharpAsync.StartImmediateAsTask(requestDelegate.Invoke(parameters),
                    cancellationToken);

    static bool IsTask<T>() =>
        typeof(T) == typeof(Task) ||
        (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Task<>));

    static bool IsAsync<T>() =>
        (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(FSharpAsync<>));

    static Delegate CreateDynamic<TParam, TResult>(string methodName,
        FSharpFunc<TParam, TResult> requestDelegate)
    {
        var underType = typeof(TResult).GetGenericArguments()[0];
        var method = typeof(AsParameters)
            .GetMethod(methodName, BindingFlags.Public | BindingFlags.Static)!
            .MakeGenericMethod(typeof(TParam), underType);

        return (Delegate) method.Invoke(null, new object?[] {requestDelegate})!;
    }
}