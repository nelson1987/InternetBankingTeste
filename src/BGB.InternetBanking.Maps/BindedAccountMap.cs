using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class BindedAccountMap : ClassMap<BindedAccount>
    {
        public BindedAccountMap()
        {
            Table("DMI_CONTA_VINCULADA");
            Id(x => x.Id, "IDT_CONTA_VINCULADA").GeneratedBy.Native();
            References(x => x.Customer, "IDT_CLIENTE").Not.Nullable();

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.Active, "FLG_ATIVO").Not.Nullable();
        }
    }
}