using Microsoft.EntityFrameworkCore;

namespace SuitSupply.Framework.Core.Queries
{
    public abstract class QueryHandlerBase
    {

        public QueryHandlerBase(DbContext context)
        {
            Context = context;
        }
        public DbContext Context { get; set; }
    }
}
