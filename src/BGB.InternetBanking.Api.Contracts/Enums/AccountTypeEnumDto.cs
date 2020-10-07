using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum AccountTypeEnumDto
    {
        [Description("NORMA")]
        Normal = 1,
        [Description("VINCL")]
        Binded = 2,
        [Description("OUTRS")]
        Others = 3
    }
}