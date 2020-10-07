using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class InvestmentBalanceMap : ClassMap<InvestmentBalance>
    {
        public InvestmentBalanceMap()
        {
            Table("VW_SALDO_RF");
            ReadOnly();

            Id(x => x.Id, "IDT_SALDO_RF");

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.ReferenceDate, "DTA_REFERENCIA").Not.Nullable();

            Component(x => x.Paper, c =>
            {
                c.Map(o => o.Code).Column("COD_PAPEL").Not.Nullable();
                c.Map(o => o.Name).Column("NOM_PAPEL").Not.Nullable();
            });

            Map(x => x.Complement, "TXT_COMPLEMENTO").Not.Nullable();
            Map(x => x.Amount, "VLR_SALDO").Not.Nullable();

            Map(x => x.Ir, "VLR_IR").Not.Nullable();
            Map(x => x.Iof, "VLR_IOF").Not.Nullable();
            Map(x => x.Applicated, "VLR_APLICADO").Not.Nullable();
        }
    }
}