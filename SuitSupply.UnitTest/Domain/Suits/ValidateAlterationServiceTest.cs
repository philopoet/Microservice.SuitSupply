using Suitsupply.Domain.Suits;
using Suitsupply.Domain.Suits.Services;
using Xunit;

namespace SuitSupply.UnitTest.Domain.Suits
{
    public class ValidateAlterationServiceTest
    {
        [Theory]
        [InlineData(-6, -5, 5, -5, false)]
        [InlineData(6, -5, -5, -5, false)]
        [InlineData(-5, -6, -5, -5, false)]
        [InlineData(-5, 6, -5, -5, false)]
        [InlineData(-5, 5, -6, -5, false)]
        [InlineData(-5, -5, 6, -5, false)]
        [InlineData(-5, -5, -5, -6, false)]
        [InlineData(-5, -5, 5, 6, false)]
        [InlineData(-5, -5, -5, -5, true)]
        public void ValidateAlterationService_FromInLineData(
            int LeftSleeveLength,
            int RightSleeveLength,
            int RighTrouserLength,
            int LeftTrouserLength,
            bool expected)
        {
            // Arrange
            var validationService = new ValidateAlterationService();
            var alterationMeasures = new Alteration(LeftSleeveLength, RightSleeveLength, RighTrouserLength, LeftTrouserLength);

            //Act
            var actual = validationService.IsAlterationMeasuresValid(alterationMeasures);
            // Asssert
            Assert.Equal(expected, actual);
        }
    }
}
