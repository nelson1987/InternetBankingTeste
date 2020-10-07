using System.ComponentModel;

namespace BGB.InternetBanking.Entities.Enums
{
    public enum InvestmentMovementTypeEnum
    {
        [Description("Aplicação")]
        Application = 1,

        [Description("Resgate")]
        Rescue = 2
    }
}