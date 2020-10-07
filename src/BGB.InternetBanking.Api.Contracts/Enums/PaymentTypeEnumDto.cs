using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum PaymentTypeEnumDto
    {
        [Description("Dinheiro")]
        Money = 0,
        [Description("Cheque")]
        Check = 1,
        [Description("Doc")]
        Doc = 2,
        [Description("Conta Corrente")]
        CheckingAccount = 3,
        [Description("Spb")]
        Spb = 4,
        [Description("Composta")]
        Composed = 5
    }
}