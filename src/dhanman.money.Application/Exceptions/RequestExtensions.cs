using dhanman.money.Application.Abstractions.Messaging;
using MediatR;

namespace dhanman.money.Application.Exceptions;

public static class RequestExtensions
{
    public static bool IsCommand<TResponse>(this IRequest<TResponse> request)
        => request is ICommand<TResponse>;

    public static bool IsQuery<TResponse>(this IRequest<TResponse> request)
        => request is IQuery<TResponse>;

    public static bool IsCacheableQuery<TResponse>(this IRequest<TResponse> request)
        => request is ICacheableQuery<TResponse>;
}
