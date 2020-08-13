namespace Suitsupply.Domain.Suits.Services
{
    public interface IValidateAlterationService
    {
        bool HasAlteredBefore(Alteration suitAlteration);
        bool IsAlterationMeasuresValid(Alteration alteration);
    }
}
