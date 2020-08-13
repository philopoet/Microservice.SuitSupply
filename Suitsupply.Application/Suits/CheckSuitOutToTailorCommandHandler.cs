using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Domain.Contracts;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Suits
{
    public class CheckSuitOutToTailorCommandHandler:  CommandHandler<CheckSuitOutToTailorCommand>
    {

        private readonly ISuitRepository _suitRepository;

        public CheckSuitOutToTailorCommandHandler(
            ISuitSupplyUnitOfWork unitOfWork,
            ISuitRepository suitRepository) : base(unitOfWork)
        {
            _suitRepository = suitRepository;
        }

        public override void Handle(CheckSuitOutToTailorCommand command)
        {
            var suit = _suitRepository.Get(command.SuitId);
            if (suit == null)
            {
                throw new ApplicationException($"Invalid SuitId {command.SuitId}");
            }
            suit.Altering(command.AlteringTailor);

        }
    }
}
