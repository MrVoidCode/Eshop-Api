using MediatR;

namespace Common.Query;

public interface IBaseQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IRequest<TResponse>
    where TResponse : class
{
}