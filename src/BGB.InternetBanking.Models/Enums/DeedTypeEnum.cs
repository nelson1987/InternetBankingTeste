using System.ComponentModel;

namespace BGB.InternetBanking.Models.Enums
{
    public enum DeedTypeEnum
    {
        [Description("Duplicata Mercantil")]
        Duplicate = 0,
        [Description("Nota Promissória")]
        PromissoryNote = 2,
        [Description("Recibo")]
        Receipt = 3,
        [Description("Apólice Seguro")]
        InsurancePolicy = 4,
        [Description("Cheque")]
        Check = 5,
        [Description("Outros")]
        Others = 9
    }
}