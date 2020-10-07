using System.ComponentModel;

namespace BGB.InternetBanking.Api.Contracts.Enums
{
    public enum ProfileEnumDto
    {
        [Description("Master")]
        Master = 1,
        [Description("Operação")]
        Operation = 2,
        [Description("Visualização")]
        Visualization = 3
    }
}