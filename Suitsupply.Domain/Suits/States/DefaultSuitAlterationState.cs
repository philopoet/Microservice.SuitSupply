using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits.Exceptions;

namespace Suitsupply.Domain.Suits.States
{
    public class DefaultSuitAlterationState : SuitAlterationState
    {
        public DefaultSuitAlterationState(Suit suit) : base(suit)
        {
        }
        public override void Altering()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Default, SuitAlterationStatus.Altering);
        }

        public override void Created()
        {
            Suit.SetStatus(SuitAlterationStatus.Created);
        }

        public override void Default()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Default, SuitAlterationStatus.Default);
        }

        public override void Done()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Default, SuitAlterationStatus.Done);
        }

        public override void Paid()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Default, SuitAlterationStatus.Paid);
        }
    }
}
