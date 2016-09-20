using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.QueryBase
{
    public interface IQueryHandler<in TQuery, TQueryResult>
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
        Task<TQueryResult> Retrieve(TQuery query);
    }
}
