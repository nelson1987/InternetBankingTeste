using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class DeedStatusMap : ClassMap<DeedStatus>
    {
        public DeedStatusMap()
        {
            Table("DMI_SITUACAO_TITULO");
            Id(x => x.Id, "IDT_SITUACAO_TITULO").GeneratedBy.Native();
            Map(x => x.Description, "DSC_SITUACAO_TITULO").Length(60).Not.Nullable();
        }
    }
}