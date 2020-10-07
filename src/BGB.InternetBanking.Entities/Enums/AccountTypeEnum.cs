using System.ComponentModel;

namespace BGB.InternetBanking.Entities.Enums
{
    public enum AccountTypeEnum
    {
        [Description("NORMA")]
        Normal = 1,
        [Description("VINCL")]
        Binded = 2,
        [Description("OUTRS")]
        Others = 3
    }
}