using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class ParameterMap : ClassMap<Parameter>
    {
        public ParameterMap()
        {
            Table("DMI_PARAMETRO");
            Id(x => x.Id, "IDT_PARAMETRO").GeneratedBy.Native();
            Map(x => x.Code, "COD_PARAMETRO").Length(5).Not.Nullable();
            Map(x => x.Description, "DSC_PARAMETRO").Length(60).Not.Nullable();
            Map(x => x.Value, "TXT_VALOR").Length(50).Not.Nullable();
        }
    }
}