using Suitsupply.Application.Contracts.Suits;
using Suitsupply.Domain.Suits;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Framework.Core.Commands;
using Suitsupply.Domain.Contracts;
using System;

namespace Suitsupply.Application.Suits
{
    public class CreateAlterationCommandHandler : CommandHandler<CreateAlterationCommand>
    {
        private readonly ISuitRepository _suitRepository;

        public CreateAlterationCommandHandler(
            ISuitSupplyUnitOfWork unitOfWork,
            ISuitRepository suitRepository): base(unitOfWork)
        {
            _suitRepository = suitRepository;
        }

        public override void Handle(CreateAlterationCommand command)
        {
            var suit = _suitRepository.Get(command.SuitId);
            if (suit == null)
            {
                throw new ApplicationException($"Invalid SuitId {command.SuitId}");
            }
            suit.CreateAlteration(new Alteration(
                command.RightSleeveLength,
                command.LeftSleeveLength,
                command.RighTrouserLength,
                command.LeftTrouserLength
                ));

        }

    }
}
