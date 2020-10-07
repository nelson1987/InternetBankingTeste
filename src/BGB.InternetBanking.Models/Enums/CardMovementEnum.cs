using System.ComponentModel;

namespace BGB.InternetBanking.Models.Enums
{
    public enum CardMovementEnum
    {
        [Description("Crédito")]
        Credit = 1,
        
        [Description("Débito")]
        Debit = 2,

        [Description("ARV")]
        Anticipation = 3
    }
}