using Suitsupply.Framework.Core.DependencyInjection;

namespace SuitSupply.Framework.Core.Queries
{
    public class QueryBus : IQueryBus
    {
        public TQueryResult Dispatch<TQueryFilter, TQueryResult>(TQueryFilter filter)
            where TQueryFilter : IQueryFilter
            where TQueryResult : IQueryResult
        {
            var handler = DotNetCoreServiceLocator.Current.Resolve<IQueryHandler<TQueryFilter, TQueryResult>>();
            var result = handler.Handle(filter);
            return result;
        }
    }
}
