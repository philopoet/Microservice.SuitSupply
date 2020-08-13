using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Contracts.Suits
{
    public class CreateAlterationCommand : ICommand
    {
        public Guid SuitId { get; set; }
        public int LeftSleeveLength { get; set; }
        public int RightSleeveLength { get; set; }
        public int RighTrouserLength { get; set; }
        public int LeftTrouserLength { get; set; }
    }
}
