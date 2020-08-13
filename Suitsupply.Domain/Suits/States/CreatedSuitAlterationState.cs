using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits.Exceptions;

namespace Suitsupply.Domain.Suits.States
{
    class CreatedSuitAlterationState : SuitAlterationState
    {
        public CreatedSuitAlterationState(Suit suit) : base(suit)
        {
        }
        public override void Created()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Created, SuitAlterationStatus.Created);
        }
        public override void Altering()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Created, SuitAlterationStatus.Altering);
        }

        public override void Done()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Created, SuitAlterationStatus.Done);
        }
        public override void Paid()
        {
                Suit.SetStatus(SuitAlterationStatus.Paid);
            // TODO Publish an event to inform the tailors about new paid Altering Request
        }

        public override void Default()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Created, SuitAlterationStatus.Default);
        }
    }
}
