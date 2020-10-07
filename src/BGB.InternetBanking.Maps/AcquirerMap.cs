using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class AcquirerMap : ClassMap<Acquirer>
    {
        public AcquirerMap()
        {
            Table("DMI_CREDENCIADORA");
            Id(x => x.Id, "IDT_CREDENCIADORA");
            Map(x => x.Code, "COD_CREDENCIADORA").Length(5).Not.Nullable();
            Map(x => x.Description, "NOM_CREDENCIADORA").Length(35).Not.Nullable();
        }
    }
}