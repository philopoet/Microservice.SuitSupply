using System.ComponentModel;

namespace Suitsupply.Common.Enums
{
    public enum SuitAlterationStatus
    {
        [Description("Default")]
        Default = 0,
        [Description("Created")]
        Created = 1,
        [Description("Paid")]
        Paid = 2,
        [Description("Altering")]
        Altering = 3,
        [Description("Done")]
        Done = 4,
    }
}
