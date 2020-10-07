using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum InvestmentMovementTypeEnumDto
    {
        [Description("Aplicação")]
        Application = 1,

        [Description("Resgate")]
        Rescue = 2
    }
}