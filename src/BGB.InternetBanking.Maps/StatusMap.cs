using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class StatusMap : ClassMap<Status>
    {
        public StatusMap()
        {
            Table("DMI_STATUS");
            Id(x => x.Id, "IDT_STATUS").GeneratedBy.Native();
            References(x => x.TypeStatus, "IDT_TIPO_STATUS").Not.Nullable();
            Map(x => x.Code, "COD_STATUS").Length(5).Not.Nullable();
            Map(x => x.Description, "DSC_STATUS").Length(30).Not.Nullable();
        }
    }
}