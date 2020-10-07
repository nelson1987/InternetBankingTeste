using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("DMI_CLIENTE");
            Id(x => x.Id, "IDT_CLIENTE").GeneratedBy.Native();
            Map(x => x.Name, "NOM_CLIENTE").Length(50).Not.Nullable();
            Map(x => x.CpfCnpj, "NUM_CPF_CNPJ").Not.Nullable();
            Map(x => x.PersonType, "TPO_PESSOA").CustomType<int>();
            Map(x => x.Active, "FLG_ATIVO").Not.Nullable();

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            HasMany(x => x.BindedAccounts).Inverse()
                .Table("DMI_CONTA_VINCULADA")
                .KeyColumn("IDT_CLIENTE")
                .Not.LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}