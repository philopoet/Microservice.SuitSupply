using Suitsupply.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuitSupply.Peresenation.WebUI.Models.Alteration
{
    public class AlterationModel
    {
        [Display(Name = "SuitId")]
        public Guid SuitId { get; set; }
        [Display(Name = "AlteringTailor")]
        public Guid AlteringTailor { get; set; }
        public SuitAlterationStatus AlterationStatus {  get; set; }
        [Display(Name = "AlterationStatus")]
        public string SuitAlterationStatusString => AlterationStatus.GetEnumDescription();
        public Guid MyProperty { get; set; }
        [Display(Name = "Alteration-LeftSleeve")]
        public int LeftSleeveLength { get; set; }
        [Display(Name = "Alteraion-RightSleeve")]
        public int RightSleeveLength { get; set; }
        [Display(Name = "Alteration-RighTrouser")]
        public int RighTrouserLength { get; set; }
        [Display(Name = "Alteration-LeftTrouser")]
        public int LeftTrouserLength { get; set; }
    }
}
