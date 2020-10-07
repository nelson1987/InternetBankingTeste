using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class FlagMap : ClassMap<Flag>
    {
        public FlagMap()
        {
            Table("DMI_BANDEIRA");
            Id(x => x.Id, "IDT_BANDEIRA");
            Map(x => x.Code, "COD_BANDEIRA").Length(5).Not.Nullable();
            Map(x => x.Description, "NOM_BANDEIRA").Length(35).Not.Nullable();
        }
    }
}