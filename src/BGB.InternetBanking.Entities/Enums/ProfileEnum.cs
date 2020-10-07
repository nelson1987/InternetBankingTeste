using System.ComponentModel;

namespace BGB.InternetBanking.Entities.Enums
{
    public enum ProfileEnum
    {
        [Description("Master")]
        Master = 1,
        [Description("Operação")]
        Operation = 2,
        [Description("Visualização")]
        Visualization = 3
    }
}