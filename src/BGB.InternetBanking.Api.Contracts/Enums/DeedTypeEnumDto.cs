using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum DeedTypeEnumDto
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