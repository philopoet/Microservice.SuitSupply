using Moq;
using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits;
using Suitsupply.Domain.Suits.Exceptions;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Domain.Suits.States;
using Suitsupply.Framework.Core.DependencyInjection;
using SuitSupply.Framework.Core.Events;
using System;
using Xunit;

namespace SuitSupply.UnitTest.Domain.Suits
{
   
    public class SuitAlterationStateTest
    {
        public SuitAlterationStateTest()
        {
            SetupServiceLocator();
            

        }
        [Theory]
        [InlineData(SuitAlterationStatus.Created)]
        [InlineData(SuitAlterationStatus.Paid)]
        [InlineData(SuitAlterationStatus.Altering)]
        [InlineData(SuitAlterationStatus.Done)]
        public void TestCreatedMethod_ThrowException_FromInLineData(SuitAlterationStatus currentState)
        {
            // Arrange
         
            var suit = GetSuitWithAlterationStatus(currentState);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            var actualResult = new Exception();

            // Act
            Action act = () => suitAlterationState.Created();
      
            // Asssert
            Assert.Throws<InvalidStateChangeException>(act);
        }
        [Theory]
        [InlineData(SuitAlterationStatus.Default)]
        [InlineData(SuitAlterationStatus.Paid)]
        [InlineData(SuitAlterationStatus.Altering)]
        [InlineData(SuitAlterationStatus.Done)]
        public void TestPaidMethod_ThrowException_FromInLineData(SuitAlterationStatus currentState)
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(currentState);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            var actualResult = new Exception();

            // Act
            Action act = () => suitAlterationState.Paid();

            // Asssert
            Assert.Throws<InvalidStateChangeException>(act);
        }
        [Theory]
        [InlineData(SuitAlterationStatus.Default)]
        [InlineData(SuitAlterationStatus.Created)]
        [InlineData(SuitAlterationStatus.Altering)]
        [InlineData(SuitAlterationStatus.Done)]
        public void TestAlteringMethod_ThrowException_FromInLineData(SuitAlterationStatus currentState)
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(currentState);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            var actualResult = new Exception();

            // Act
            Action act = () => suitAlterationState.Altering();

            // Asssert
            Assert.Throws<InvalidStateChangeException>(act);
        }
        [Theory]
        [InlineData(SuitAlterationStatus.Default)]
        [InlineData(SuitAlterationStatus.Created)]
        [InlineData(SuitAlterationStatus.Paid)]
        [InlineData(SuitAlterationStatus.Done)]
        public void TestDoneMethod_ThrowException_FromInLineData(SuitAlterationStatus currentState)
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(currentState);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            var actualResult = new Exception();

            // Act
            Action act = () => suitAlterationState.Done();

            // Asssert
            Assert.Throws<InvalidStateChangeException>(act);
        }
        [Fact]
        public void TestCreatedMethod_ChangeFromDefaultToCreated()
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(SuitAlterationStatus.Default);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            // Act
            suitAlterationState.Created();

            // Asssert
            Assert.Equal(SuitAlterationStatus.Created, suit.AlterationStatus);
        }
        [Fact]
        public void TestPaidMethod_ChangeFromCreatedToPaied()
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(SuitAlterationStatus.Created);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            // Act
            suitAlterationState.Paid();

            // Asssert
            Assert.Equal(SuitAlterationStatus.Paid, suit.AlterationStatus);
        }
        [Fact]
        public void TestAlteringMethod_ChangeFromPaiedToAltering()
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(SuitAlterationStatus.Paid);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            // Act
            suitAlterationState.Altering();

            // Asssert
            Assert.Equal(SuitAlterationStatus.Altering, suit.AlterationStatus);
        }
        [Fact]
        public void TestDoneMethod_ChangeFromAlteringToDone()
        {
            // Arrange

            var suit = GetSuitWithAlterationStatus(SuitAlterationStatus.Altering);
            var stateFactory = new SuitAlterationStateFactory();
            var suitAlterationState = SuitAlterationStateFactory.Create(suit);
            // Act
            suitAlterationState.Done();

            // Asssert
            Assert.Equal(SuitAlterationStatus.Done, suit.AlterationStatus);
        }
        private Suit GetSuitWithAlterationStatus(SuitAlterationStatus status)
        {
            var suit = new Suit(20,20,"blue","cotton");
            switch (status)
            {
                case SuitAlterationStatus.Default:
                    break;
                case SuitAlterationStatus.Created:
                     suit = GetSuitWithCreatedAlterationStatust(suit);
                    break;
                case SuitAlterationStatus.Paid:
                        suit = GetSuitWithCreatedAlterationStatust(suit);
                    suit = GetSuitWithPaiedAlterationStatust(suit);
                    break;
                case SuitAlterationStatus.Altering:
                    suit = GetSuitWithCreatedAlterationStatust(suit);
                    suit = GetSuitWithPaiedAlterationStatust(suit);
                    suit = GetSuitWithAlteringAlterationStatust(suit);
                    break;
                case SuitAlterationStatus.Done:
                    suit = GetSuitWithCreatedAlterationStatust(suit);
                    suit = GetSuitWithPaiedAlterationStatust(suit);
                    suit = GetSuitWithAlteringAlterationStatust(suit);
                    suit = GetSuitWithDoneAlterationStatust(suit);
                    break;

                default:
                    break;
            }
            return suit;
        }
        private Suit GetSuitWithCreatedAlterationStatust(Suit suitWithDefaultAlterationStatus)
        {
            var alteration = new Alteration(3, 3, 3, 3);
            suitWithDefaultAlterationStatus.CreateAlteration(alteration);
            return suitWithDefaultAlterationStatus;
        }
        private Suit GetSuitWithPaiedAlterationStatust(Suit suitWithCreatedAlterationStatus)
        {
             suitWithCreatedAlterationStatus.Paid();
            return suitWithCreatedAlterationStatus;
        }
        private Suit GetSuitWithAlteringAlterationStatust(Suit suitWithPaiedAlterationStatus)
        {
            suitWithPaiedAlterationStatus.Altering(Guid.NewGuid());
            return suitWithPaiedAlterationStatus;
        }
        private Suit GetSuitWithDoneAlterationStatust(Suit suitWithAlterinAlterationStatus)
        {
            suitWithAlterinAlterationStatus.AlterationIsDone();
            return suitWithAlterinAlterationStatus;
        }
        private void SetupServiceLocator()
        {
            var eventBus = new Mock<IEventBus>();

            var container = new Mock<IDotNetCoreServiceLocator>();
            container.Setup(s => s.Resolve<IEventBus>()).Returns(() => eventBus.Object);

            var alterationServiceValidator = new Mock<IValidateAlterationService>();
            var Alteration = new Alteration() ;
            alterationServiceValidator.Setup(validator => validator.HasAlteredBefore(Alteration)).Returns(false);
            alterationServiceValidator.Setup(validator => validator.IsAlterationMeasuresValid(Alteration)).Returns(true);
            container.Setup(s => s.Resolve<IValidateAlterationService>()).Returns(() => alterationServiceValidator.Object);
            DotNetCoreServiceLocator.Initial(container.Object);
        }
    }
}
