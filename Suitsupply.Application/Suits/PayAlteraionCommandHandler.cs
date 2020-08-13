using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Domain.Contracts;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Framework.Core.Commands;
using System;

namespace Suitsupply.Application.Suits
{
    public class PayAlteraionCommandHandler : CommandHandler<PayAlteraionCommand>
    {
        private readonly ISuitRepository _suitRepository;

        public PayAlteraionCommandHandler(
            ISuitSupplyUnitOfWork unitOfWork,
            ISuitRepository suitRepository) : base(unitOfWork)
        {
            _suitRepository = suitRepository;
        }

        public override void Handle(PayAlteraionCommand command)
        {
            var suit = _suitRepository.Get(command.SuitId);
            if (suit == null)
            {
                throw new ApplicationException($"Invalid SuitId {command.SuitId}");
            }
            suit.Paid();

        }
    }
}
