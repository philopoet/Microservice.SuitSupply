using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Contracts.Suits
{
    public class PayAlteraionCommand: ICommand
    {
        public Guid SuitId { get; set; }
    }
}
