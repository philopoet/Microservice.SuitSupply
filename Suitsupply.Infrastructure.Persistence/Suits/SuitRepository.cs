using System;
using System.Collections.Generic;
using System.Linq;
using Suitsupply.Domain.Contracts;
using Suitsupply.Domain.Suits;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Framework.Core.Persistence;

namespace Suitsupply.Infrastructure.Persistence.Suits
{
    public class SuitRepository : Repository<Guid, Suit>, ISuitRepository
    {
        public SuitRepository(ISuitSupplyUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IEnumerable<string> GetIncludeExpressions()
        {
            return Enumerable.Empty<string>();
        }

        public Suit Get(Guid id)
        {
            return Query.FirstOrDefault(p => p.Id == id);
        }
    }
}
