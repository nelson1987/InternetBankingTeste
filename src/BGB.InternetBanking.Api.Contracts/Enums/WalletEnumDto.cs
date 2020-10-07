using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum WalletEnumDto
    {
        [Description("Desconto")]
        Discount = 11,
        [Description("Cessão Crédito")]
        CreditAssignment = 12,
        [Description("Cobrança Simples")]
        SimpleCharging = 21,
        [Description("Vinculada")]
        Binded = 41
    }
}