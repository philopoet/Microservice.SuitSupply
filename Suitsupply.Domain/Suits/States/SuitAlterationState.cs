namespace Suitsupply.Domain.Suits.States
{
    public abstract class SuitAlterationState
    {
        protected Suit Suit;
        protected SuitAlterationState(Suit suit)
        {
            Suit = suit;
        }
        public abstract void Default();
        public abstract void Created();
        public abstract void Paid();
        public abstract void Altering();
        public abstract void Done();
    }
}
