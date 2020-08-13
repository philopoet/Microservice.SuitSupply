using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Domain.Contracts;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Suits
{
    public class SuitAlterationIsDoneCommandHandler
    : CommandHandler<SuitAlterationIsDoneCommand>
    {

        private readonly ISuitRepository _suitRepository;

        public SuitAlterationIsDoneCommandHandler(
            ISuitSupplyUnitOfWork unitOfWork,
            ISuitRepository suitRepository) : base(unitOfWork)
        {
            _suitRepository = suitRepository;
        }

        public override void Handle(SuitAlterationIsDoneCommand command)
        {
            var suit = _suitRepository.Get(command.SuitId);
            if (suit == null)
            {
                throw new ApplicationException($"Invalid SuitId {command.SuitId}");
            }
            suit.AlterationIsDone();

        }
    }
}
