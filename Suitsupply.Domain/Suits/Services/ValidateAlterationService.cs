namespace Suitsupply.Domain.Suits.Services
{
    public class ValidateAlterationService : IValidateAlterationService
    {
        public bool HasAlteredBefore(Alteration suitAlteration)
        {
            return suitAlteration.RightSleeveLength != 0 ||
                   suitAlteration.LeftSleeveLength != 0 ||
                   suitAlteration.RighTrouserLength != 0 ||
                   suitAlteration.LeftTrouserLength != 0 ;
        }

        public bool IsAlterationMeasuresValid(Alteration alteration)
        {
            return IsMeasuresValid(alteration.RightSleeveLength) &&
                   IsMeasuresValid(alteration.LeftSleeveLength) &&
                   IsMeasuresValid(alteration.RighTrouserLength) &&
                   IsMeasuresValid(alteration.LeftTrouserLength);

        }

        private bool IsMeasuresValid(int measure)
        {
            return 5 >= measure && measure >= -5;
        }
    }
}
