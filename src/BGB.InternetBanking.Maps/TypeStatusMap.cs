using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class TypeStatusMap : ClassMap<TypeStatus>
    {
        public TypeStatusMap()
        {
            Table("DMI_TIPO_STATUS");
            Id(x => x.Id, "IDT_TIPO_STATUS").GeneratedBy.Native();
            Map(x => x.Code, "COD_TIPO_STATUS").Length(5).Not.Nullable();
            Map(x => x.Description, "DSC_TIPO_STATUS").Length(30).Not.Nullable();
        }
    }
}