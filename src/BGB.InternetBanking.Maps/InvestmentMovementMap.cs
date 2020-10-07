using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class InvestmentMovementMap : ClassMap<InvestmentMovement>
    {
        public InvestmentMovementMap()
        {
            Table("VW_MOVIMENTO_RF");
            ReadOnly();

            Id(x => x.Id, "IDT_MOVIMENTO_RF");

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.BequestId, "IDT_LEGADO").Not.Nullable();
            Map(x => x.MovementDate, "DTA_MOVIMENTO").Not.Nullable();
            Map(x => x.EmissionDate, "DTA_EMISSAO").Not.Nullable();
            Map(x => x.MaturityDate, "DTA_VENCIMENTO").Not.Nullable();
            Map(x => x.Type, "TPO_MOVIMENTO").CustomType<int>();

            Component(x => x.Paper, c =>
            {
                c.Map(o => o.Code).Column("COD_PAPEL").Not.Nullable();
                c.Map(o => o.Name).Column("NOM_PAPEL").Not.Nullable();
            });

            Map(x => x.Complement, "TXT_COMPLEMENTO").Not.Nullable();
            Map(x => x.Ir, "VLR_IR").Not.Nullable();
            Map(x => x.Iof, "VLR_IOF").Not.Nullable();
            Map(x => x.Amount, "VLR_MOVIMENTO").Not.Nullable();
        }
    }
}