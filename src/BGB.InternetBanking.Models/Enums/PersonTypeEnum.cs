using System.ComponentModel;

namespace BGB.InternetBanking.Models.Enums
{
    public enum PersonTypeEnum
    {
        [Description("Física")]
        Natural = 1,

        [Description("Jurídica")]
        Legal = 2
    }
}