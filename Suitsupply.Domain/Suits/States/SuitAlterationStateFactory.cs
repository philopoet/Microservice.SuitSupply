using Suitsupply.Common.Enums;
using System;


namespace Suitsupply.Domain.Suits.States
{
    public class SuitAlterationStateFactory
    {
        public static SuitAlterationState Create(Suit suit)
        {
            switch(suit.AlterationStatus)
            {
                case SuitAlterationStatus.Default:
                    return new DefaultSuitAlterationState(suit);
                case SuitAlterationStatus.Created:
                    return new CreatedSuitAlterationState(suit);
                case SuitAlterationStatus.Paid:
                    return new PaidSuitAlterationState(suit);
                case SuitAlterationStatus.Altering:
                    return new AlteringSuitAlterationState(suit);
                case SuitAlterationStatus.Done:
                    return new DoneSuitAlterationState(suit);
            }

            throw new NotImplementedException();
        }
    }
}
