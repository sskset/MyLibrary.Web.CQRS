using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.QueryBase
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery
            where TQueryResult : IQueryResult
        {
            var handler = ServiceLocator.Current.GetInstance<IQueryHandler<TQuery, TQueryResult>>();
            return await handler.Retrieve(query);
        }
    }
}
