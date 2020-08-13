using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits.Exceptions;

namespace Suitsupply.Domain.Suits.States
{
    class AlteringSuitAlterationState : SuitAlterationState
    {
        public AlteringSuitAlterationState(Suit suit) : base(suit)
        {
        }
        public override void Created()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Altering, SuitAlterationStatus.Created);
        }
        public override void Altering()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Altering, SuitAlterationStatus.Altering);
        }


        public override void Done()
        {
            Suit.SetStatus(SuitAlterationStatus.Done);
            // TODO publishe and event to notify owner that alteration is done 
        }

        public override void Paid()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Altering, SuitAlterationStatus.Paid);
        }

        public override void Default()
        {
            throw new InvalidStateChangeException(SuitAlterationStatus.Altering, SuitAlterationStatus.Default);
        }
    }
}
