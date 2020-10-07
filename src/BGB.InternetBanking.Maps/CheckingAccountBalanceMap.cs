using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class CheckingAccountBalanceMap : ClassMap<CheckingAccountBalance>
    {
        public CheckingAccountBalanceMap()
        {
            Table("VW_SALDO_CC");
            ReadOnly();

            Id(x => x.Id, "IDT_SALDO_CC");
            
            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.ReferenceDate, "DTA_REFERENCIA").Not.Nullable();
            Map(x => x.Amount, "VLR_SALDO").Not.Nullable();
            Map(x => x.Blocked, "VLR_BLOQUEADO").Not.Nullable();

            Component(x => x.BusinessCheck, c =>
            {
                c.Map(o => o.Limit).Column("VLR_LIMITE").Not.Nullable();
                c.Map(o => o.Start).Column("DTA_INICIO_LIMITE").Nullable();
                c.Map(o => o.End).Column("DTA_FIM_LIMITE").Nullable();
            });
            
        }
    }
}