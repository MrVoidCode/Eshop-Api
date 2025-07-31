using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Query.Filter;
using MediatR;

namespace Common.Query
{
    public interface IBaseQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {
    }
    public class QueryFilter<TResponse, TParam> : IRequest<TResponse>
        where TResponse : BaseFilter
        where TParam : BaseFilterParam
    {
        public TParam FilterParams { get; set; }
        public QueryFilter(TParam filterParams)
        {
            FilterParams = filterParams;
        }
    }
}
