namespace SuitSupply.Framework.Core.Queries
{
    public interface IQueryHandler<TQueryFilter, TQueryResult>
        where TQueryFilter : IQueryFilter
        where TQueryResult : IQueryResult
    {
        TQueryResult Handle(TQueryFilter filter);
    }
}
