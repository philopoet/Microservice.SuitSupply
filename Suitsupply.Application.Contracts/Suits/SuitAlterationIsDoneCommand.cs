using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Contracts.Suits
{
    public class SuitAlterationIsDoneCommand: ICommand
    {
        public Guid SuitId { get; set; }
    }
}
