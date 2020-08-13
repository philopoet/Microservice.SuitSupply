using Suitsupply.Framework.Domain;


namespace Suitsupply.Domain.Suits
{

    public class Alteration: ValueObject<Alteration>
    {
      
        public Alteration()
        {

        }

        public Alteration(
            int rightSleeveLength,
            int leftSleeveLength, 
            int righTrouserLength, 
            int leftTrouserLength)
        {
            RightSleeveLength = rightSleeveLength;
            LeftSleeveLength = leftSleeveLength;
            RighTrouserLength = righTrouserLength;
            LeftTrouserLength = leftTrouserLength;
        }
        public int LeftSleeveLength{ get; private set; }
        public int RightSleeveLength { get; private set; }
        public int RighTrouserLength { get; private set; }
        public int LeftTrouserLength { get; private set; }
        public override bool Equals(Alteration other)
        {
            return RightSleeveLength == other.RightSleeveLength &&
                   LeftSleeveLength == other.LeftSleeveLength &&
                   RighTrouserLength == other.RighTrouserLength &&
                   LeftTrouserLength == other.LeftTrouserLength ;
        }
        internal bool HasData()
        {
            return !(RightSleeveLength == 0 &&
                   LeftSleeveLength == 0 &&
                   RighTrouserLength == 0 &&
                   LeftTrouserLength == 0);
        }
    }
}
