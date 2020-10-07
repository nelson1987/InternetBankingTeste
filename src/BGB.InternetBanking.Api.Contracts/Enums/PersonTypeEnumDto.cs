using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum PersonTypeEnumDto
    {
        [Description("Física")]
        Natural = 1,

        [Description("Jurídica")]
        Legal = 2
    }
}