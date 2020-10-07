using System.ComponentModel;

namespace BGB.InternetBanking.Models.Enums
{
    public enum OperationDeedEnum
    {
        [Description("Liquidação Caixa")]
        CashLiquidation = 1,

        [Description("Baixa Normal")]
        NormalDischarge = 2,

        [Description("Transferência Carteira")]
        WalletTransfer = 3,

        [Description("Liquidação Cartorio")]
        RegistryLiquidation = 4,

        [Description("Baixa por Protesto")]
        ProtestDischarge = 5,

        [Description("Liquidação Correspondente")]
        CorrespondentLiquidation = 6,

        [Description("Baixa Doc")]
        DocDischarge = 11,

        [Description("Baixa Ted")]
        TedDischarge = 12,

        [Description("Cheque a compensar")]
        CheckCompensate = 15,

        [Description("Em Aberto")]
        Opened = 99
    }
}