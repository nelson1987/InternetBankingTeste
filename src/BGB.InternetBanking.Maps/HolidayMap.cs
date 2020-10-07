using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class HolidayMap : ClassMap<Holiday>
    {
        public HolidayMap()
        {
            Table("DMI_FERIADO");
            Id(x => x.Id, "IDT_FERIADO").GeneratedBy.Native();
            Map(x => x.Date, "DTA_FERIADO").Not.Nullable();
            Map(x => x.Description, "DSC_FERIADO").Length(35).Not.Nullable();
            Map(x => x.IsNational, "FLG_NACIONAL").Not.Nullable();
            Map(x => x.IsVariableDate, "FLG_DATA_VARIAVEL").Not.Nullable();
        }
    }
}