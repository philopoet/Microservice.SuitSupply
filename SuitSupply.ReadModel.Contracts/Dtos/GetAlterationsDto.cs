using Suitsupply.Common.Enums;
using System;

namespace SuitSupply.ReadModel.Contracts.Dtos
{
    public class GetAlterationsDto
    {
        public Guid SuitId { get; set; }
        public Guid AlteringTailor { get; set; }
        public SuitAlterationStatus AlterationStatus { get; set; }
        public Guid MyProperty { get; set; }
        public int LeftSleeveLength { get; set; }
        public int RightSleeveLength { get; set; }
        public int RighTrouserLength { get; set; }
        public int LeftTrouserLength { get; set; }
    }
}
