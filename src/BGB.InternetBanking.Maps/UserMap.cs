using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("DMI_USUARIO");
            Id(x => x.Id, "IDT_USUARIO").GeneratedBy.Native();
            References(x => x.Customer, "IDT_CLIENTE").Not.Nullable();
            Map(x => x.Name, "NOM_USUARIO").Length(50).Not.Nullable();
            Map(x => x.Email, "TXT_EMAIL").Length(100).Not.Nullable();
            Map(x => x.Profile, "TPO_PERFIL").CustomType<int>();
            Map(x => x.Active, "FLG_ATIVO").Not.Nullable();

            Component(x => x.Credential, c =>
            {
                c.Map(o => o.Login).Column("NOM_LOGIN").Length(30).Not.Nullable();
                c.Map(o => o.Key).Column("KEY_USUARIO").Length(250).Not.Nullable();
                c.Map(o => o.TemporaryKey).Column("FLG_KEY_TEMPORARIA").Not.Nullable();
            });
        }
    }
}