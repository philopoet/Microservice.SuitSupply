using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Contracts.Suits
{
    public class CheckSuitOutToTailorCommand: ICommand
    {
        public Guid SuitId { get; set; }
        public Guid AlteringTailor { get; set; }
    }
}
