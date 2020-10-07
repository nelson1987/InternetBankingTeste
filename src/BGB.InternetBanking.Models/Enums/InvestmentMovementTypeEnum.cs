using System.ComponentModel;

namespace BGB.InternetBanking.Models.Enums
{
    public enum InvestmentMovementTypeEnum
    {
        [Description("Aplicação")]
        Application = 1,

        [Description("Resgate")]
        Rescue = 2
    }
}