using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class GuaranteeMap : ClassMap<Guarantee>
    {
        public GuaranteeMap()
        {
            Table("VW_GARANTIA");
            ReadOnly();

            Id(x => x.Id, "IDT_GARANTIA");

            Component(x => x.CheckingAccount , c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Component(x => x.CheckingAccountGarantor, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA_GARANTIDOR").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA_GARANTIDOR").Not.Nullable();
            });

            Map(x => x.Contract, "COD_CONTRATO").Length(10).Not.Nullable();
            Map(x => x.CardAmount, "VLR_CARTAO").Not.Nullable();
            Map(x => x.RequiredAmount, "VLR_EXIGIDA").Not.Nullable();
            Map(x => x.DuplicateAmount, "VLR_DUPLICATA").Not.Nullable();
            Map(x => x.CheckAmount, "VLR_CHEQUE").Not.Nullable();
            Map(x => x.ExpiredAmount, "VLR_VENCIDA").Not.Nullable();
        }
    }
}