using System;
using Suitsupply.Common.Enums;
using Suitsupply.Domain.Suits.Exceptions;
using Suitsupply.Domain.Suits.Services;
using Suitsupply.Domain.Suits.States;
using Suitsupply.Framework.Core.DependencyInjection;
using Suitsupply.Framework.Domain;

namespace Suitsupply.Domain.Suits
{
  
    public class Suit: AggregateRoot<Guid, Suit>
    {
        public Suit()
        {
           
        }
        public Suit(
            int sleeveLength, 
            int trouserLength, 
            string color, 
            string texture)
        {
            Id = Guid.NewGuid();
            RightSleeve = LeftSleeve = sleeveLength;
            RighTrouser = LeftTrouser = trouserLength;
            Color = color;
            Texture = texture;
            AlterationStatus = SuitAlterationStatus.Default;
            Alteration = new Alteration(0, 0, 0, 0);
        }
        public int LeftSleeve { get;private set; }
        public int RightSleeve { get;private set; }
        public int RighTrouser { get;private set; }
        public int LeftTrouser { get;private set; }
        public SuitAlterationStatus AlterationStatus { get;private set; }
        public string Color { get;private set; }
        public string Texture { get;private set; }
        public Alteration Alteration { get; private set; }
        public Guid AlteringTailor { get;private set; }
        public Guid Owner { get;private set; }
        public void Bought(Guid owner)
        {
            Owner = owner;
        }
        public void CreateAlteration(Alteration alteration)
        {
            if (alteration.HasData())
            {
                var validitor = DotNetCoreServiceLocator.Current.Resolve<IValidateAlterationService>();
                if (!validitor.HasAlteredBefore(Alteration) && validitor.IsAlterationMeasuresValid(Alteration))
                {
                    Alteration = alteration;
                    var currentState = SuitAlterationStateFactory.Create(this);
                    currentState.Created();
                    AlterationStatus = SuitAlterationStatus.Created;
                }
                else
                {
                    throw new InvalidAlterationRequestException();
                }

            }

        }
        public void Paid()
        {
            var currentState = SuitAlterationStateFactory.Create(this);
            currentState.Paid();
        }
        public void Altering(Guid tailor)
        {
            AlteringTailor = tailor;
            var currentState = SuitAlterationStateFactory.Create(this);
            currentState.Altering();
        }
        public void AlterationIsDone()
        {
            var currentState = SuitAlterationStateFactory.Create(this);
            currentState.Done();
        }
        internal void SetStatus(SuitAlterationStatus status)
        {
            AlterationStatus = status;
        }

    }
}
