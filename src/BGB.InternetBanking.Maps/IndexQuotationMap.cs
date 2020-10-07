using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class IndexQuotationMap : ClassMap<IndexQuotation>
    {
        public IndexQuotationMap()
        {
            Table("VW_INDICE_COTACAO");
            ReadOnly();

            Id(x => x.Id, "IDT_INDICE_COTACAO");

            Component(x => x.Index, c =>
            {
                c.Map(o => o.Id).Column("IDT_INDICE").Not.Nullable();
                c.Map(o => o.Code).Column("COD_INDICE").Not.Nullable();
                c.Map(o => o.Description).Column("DSC_INDICE").Not.Nullable();
                c.Map(o => o.Active).Column("FLG_ATIVO").Not.Nullable();
            });

            Map(x => x.ReferenceDate, "DTA_COTACAO").Not.Nullable();
            Map(x => x.Amount, "VLR_COTACAO").Not.Nullable();
        }
    }
}