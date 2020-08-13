using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits.Exceptions;

namespace Suitsupply.Domain.Suits.States
{
    class PaidSuitAlterationState : SuitAlterationState
    {
        public PaidSuitAlterationState(Suit suit) : base(suit)
        {
        }
        public override void Created()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Paid, SuitAlterationStatus.Created);
        }
        public override void Altering()
        {
            // TODO Add some validation
            Suit.SetStatus(SuitAlterationStatus.Altering);
            // TODO publish an event to inform the customer and salesrep that the siut has been picked up by a tailor
        }

        public override void Done()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Paid, SuitAlterationStatus.Done);
        }

        public override void Paid()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Paid, SuitAlterationStatus.Paid);
        }

        public override void Default()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Paid, SuitAlterationStatus.Default);
        }
    }
}
