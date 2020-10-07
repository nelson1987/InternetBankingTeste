using System.ComponentModel;

namespace BGB.InternetBanking.Entities.Enums
{
    public enum PaymentTypeEnum
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