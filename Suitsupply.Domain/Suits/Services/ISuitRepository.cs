using System;

namespace Suitsupply.Domain.Suits.Services
{
    public interface ISuitRepository
    {
        Suit Get(Guid id);
        void Create(Suit suit);
    }
}
