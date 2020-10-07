using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class CheckingAccountMovementMap : ClassMap<CheckingAccountMovement>
    {
        public CheckingAccountMovementMap()
        {
            Table("VW_MOVIMENTO_CC");
            ReadOnly();

            Id(x => x.Id, "IDT_MOVIMENTO_CC");
            Map(x => x.MovementDate, "DTA_MOVIMENTO").Not.Nullable();

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.BequestId, "IDT_LEGADO").Not.Nullable();
            Map(x => x.Document, "COD_DOCUMENTO").Nullable();

            Component(x => x.History, c =>
            {
                c.Map(o => o.Id).Column("IDT_HISTORICO").Nullable();
                c.Map(o => o.Description).Column("DSC_HISTORICO").Nullable();
            });

            Map(x => x.PaymentType, "TPO_PAGAMENTO").Not.Nullable().CustomType<int>();
            Map(x => x.CompensationDate, "DTA_COMPENSACAO").Nullable();
            Map(x => x.CategoryId, "IDT_CATEGORIA").Nullable();
            Map(x => x.Amount, "VLR_MOVIMENTO").Not.Nullable();
        }
    }
}