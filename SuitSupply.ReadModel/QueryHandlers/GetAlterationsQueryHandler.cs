using SuitSupply.Framework.Core.Queries;
using SuitSupply.ReadModel.Contracts.Dtos;
using SuitSupply.ReadModel.Contracts.Filters;
using System;
using System.Linq;


namespace SuitSupply.ReadModel.QueryHandlers
{
    public class GetAlterationsQueryHandler : IQueryHandler<GetAlterationsFilter, CollectionQueryResult<GetAlterationsDto>>
    {
        public CollectionQueryResult<GetAlterationsDto> Handle(GetAlterationsFilter filter)
        {
            using (var context = new SuitSupplyReadContext())
            {
                var suitQuery = context.Suit.AsQueryable();
              
                if (filter != null)
                {
                    if (filter.SuitId != null && filter.SuitId != Guid.Empty)
                    {
                        suitQuery = suitQuery.Where(suit => suit.Id == filter.SuitId);
                    }
                }


                var result = suitQuery.Select(i => new GetAlterationsDto()
                {
                    SuitId = i.Id,
                    AlterationStatus = i.AlterationStatus,
                    AlteringTailor = i.AlteringTailor,
                    RightSleeveLength = i.Alteration.RightSleeveLength,
                    LeftSleeveLength = i.Alteration.LeftSleeveLength,
                    RighTrouserLength = i.Alteration.RighTrouserLength,
                    LeftTrouserLength = i.Alteration.LeftTrouserLength,
         

                }).ToList();
                return new CollectionQueryResult<GetAlterationsDto>(result);
            }
        }
    }
}
