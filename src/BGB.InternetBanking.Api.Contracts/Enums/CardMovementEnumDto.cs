using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum CardMovementEnumDto
    {
        [Description("Crédito")]
        Credit = 1,

        [Description("Débito")]
        Debit = 2,

        [Description("ARV")]
        Anticipation = 3
    }
}