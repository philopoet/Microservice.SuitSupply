using Suitsupply.Common.Enums;
using Suitsupply.Framework.Domain;

namespace Suitsupply.Domain.Suits.Exceptions
{
    public class InvalidStateChangeException: DomainException
    {
        // TO DO add resource for excpetions
        public InvalidStateChangeException(SuitAlterationStatus changeFrom, SuitAlterationStatus changeTo)
            : base($"Can not change state from {changeFrom.GetEnumDescription()} to {changeTo.GetEnumDescription()}")
        {

        }
    }
}
