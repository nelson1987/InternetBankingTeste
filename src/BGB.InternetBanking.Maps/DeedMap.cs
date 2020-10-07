using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class DeedMap : ClassMap<Deed>
    {
        public DeedMap()
        {
            Table("VW_TITULO");
            ReadOnly();

            Id(x => x.Id, "IDT_TITULO");
            Map(x => x.Assignor, "COD_CEDENTE").Not.Nullable();

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.Number, "NUM_TITULO").Not.Nullable();
            Map(x => x.OurNumber, "NUM_NOSSO_NUMERO").Not.Nullable();
            Map(x => x.WalletType, "TPO_CARTEIRA").CustomType<int>();
            Map(x => x.ReceiverNumber, "NUM_TITULO_COBRADOR").Nullable();
            Map(x => x.ReceiverDigit, "DIG_TITULO_COBRADOR").Nullable();
            Map(x => x.ReceiverWalletId, "IDT_CARTEIRA_COBRADOR").Not.Nullable();
            Map(x => x.ReceiverBank, "NUM_BANCO_COBRADOR").Not.Nullable();
            Map(x => x.ReceiverAgency, "NUM_AGENCIA_COBRADOR").Not.Nullable();

            Component(x => x.CheckingAccountReceiver, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA_COBRADOR").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA_COBRADOR").Nullable();
            });

            Map(x => x.EntryDate, "DTA_ENTRADA").Not.Nullable();
            Map(x => x.MaturityDate, "DTA_VENCIMENTO").Not.Nullable();
            Map(x => x.MaturityDateDayUtil, "DTA_VENCIMENTO_DIA_UTIL").Not.Nullable();
            Map(x => x.DischargeDate, "DTA_BAIXA").Nullable();
            Map(x => x.LossDate, "DTA_PREJUIZO").Nullable();
            Map(x => x.Type, "TPO_TITULO").CustomType<int>();

            Component(x => x.Payer, p =>
            {
                p.Map(o => o.CpfCnpj).Column("NUM_CPF_CNPJ_SACADO").Not.Nullable();
                p.Map(o => o.Name).Column("NOM_SACADO").Not.Nullable();
                p.Map(o => o.PersonType).Column("TPO_SACADO").CustomType<int>();
                p.Map(o => o.Address).Column("DSC_ENDERECO_SACADO").Nullable();
                p.Map(o => o.District).Column("DSC_BAIRRO_SACADO").Nullable();
                p.Map(o => o.City).Column("DSC_CIDADE_SACADO").Nullable();
                p.Map(o => o.ZipCode).Column("NUM_CEP_SACADO").Nullable();
                p.Map(o => o.State).Column("COD_UF_SACADO").Nullable();
            });
            
            Component(x => x.GuarantorPayer, p =>
            {
                p.Map(o => o.CpfCnpj).Column("NUM_CPF_CNPJ_SACADO").Nullable();
                p.Map(o => o.Name).Column("NOM_SACADO").Nullable();
            });
            
            Map(x => x.Amount, "VLR_TITULO").Not.Nullable();
            Map(x => x.Discount, "VLR_ABATIMENTO").Not.Nullable();
            Map(x => x.Mulct, "VLR_MULTA").Not.Nullable();
            Map(x => x.Interest, "VLR_JUROS_DIA").Not.Nullable();
            Map(x => x.PermanenceDay, "VLR_PERMANENCIA_DIA").Not.Nullable();
            Map(x => x.Liquidation, "VLR_LIQUIDACAO").Not.Nullable();
            Map(x => x.OperationDeed, "TPO_OPERACAO").CustomType<int>();
            References(x => x.DeedStatus, "IDT_SITUACAO_TITULO").Not.Nullable();

            Component(x => x.Instruction, p =>
            {
                p.Map(o => o.Id).Column("IDT_INSTRUCAO").Nullable();
                p.Map(o => o.Number).Column("NUM_INSTRUCAO").Nullable();
                p.Map(o => o.Bank).Column("NUM_BANCO_INSTRUCAO").Nullable();
                p.Map(o => o.BilletPhrase).Column("DSC_FRASE_BOLETO").Nullable();
            });

            Map(x => x.DayProtest, "QTD_DIA_PROTESTO").Nullable();
        }
    }
}