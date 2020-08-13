using Suitsupply.Common.Enums;
using System;

namespace SuitSupply.ReadModel.Entities
{
  
    public class Suit
    {
        public Suit()
        {
            
        }
        public Guid Id { get; set; }
        public int LeftSleeve { get;set; }
        public int RightSleeve { get;set; }
        public int RighTrouser { get;set; }
        public int LeftTrouser { get;set; }
        public SuitAlterationStatus AlterationStatus { get;set; }
        public string Color { get;set; }
        public string Texture { get;set; }
        public Alteration Alteration { get; set; }
        public Guid AlteringTailor { get;set; }
        public Guid Owner { get;set; }
       

    }
}
