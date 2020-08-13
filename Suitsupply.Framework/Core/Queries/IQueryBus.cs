using SuitSupply.Framework.Core.Queries;

namespace SuitSupply.Framework.Core.Queries
{
    public interface IQueryBus
    {
        TQueryResult Dispatch<TQueryFilter, TQueryResult>(TQueryFilter filter)
            where TQueryFilter : IQueryFilter
            where TQueryResult : IQueryResult;
    }
}
