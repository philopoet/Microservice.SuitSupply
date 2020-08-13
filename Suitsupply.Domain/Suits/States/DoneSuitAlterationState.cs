using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits.Exceptions;

namespace Suitsupply.Domain.Suits.States
{
    class DoneSuitAlterationState : SuitAlterationState
    {
        public DoneSuitAlterationState(Suit suit) : base(suit)
        {
        }
        public override void Created()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Done, SuitAlterationStatus.Created);
        }
        public override void Altering()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Done, SuitAlterationStatus.Altering);
        }

        public override void Done()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Done, SuitAlterationStatus.Done);
        }

        public override void Paid()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Done, SuitAlterationStatus.Paid);
        }

        public override void Default()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Done, SuitAlterationStatus.Default);
        }
    }
}
