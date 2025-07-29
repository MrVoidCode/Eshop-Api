using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Query
{
    public interface IBaseQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {
    }
}
