using SuitSupply.Framework.Core.Queries;
using System;

namespace SuitSupply.ReadModel.Contracts.Filters
{
    public class GetAlterationsFilter: IQueryFilter
    {
        public Guid? SuitId { get; set; }
    }
}
