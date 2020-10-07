using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class CardMovementMap : ClassMap<CardMovement>
    {
        public CardMovementMap()
        {
            Table("VW_MOVIMENTO_CARTAO");
            ReadOnly();

            Id(x => x.Id, "IDT_MOVIMENTO_CARTAO");

            Component(x => x.Flag, c =>
            {
                c.Map(o => o.Id).Column("IDT_BANDEIRA").Not.Nullable();
                c.Map(o => o.Code).Column("COD_BANDEIRA").Not.Nullable();
                c.Map(o => o.Description).Column("DSC_BANDEIRA").Not.Nullable();
            });

            Component(x => x.Acquirer, c =>
            {
                c.Map(o => o.Id).Column("IDT_CREDENCIADORA").Not.Nullable();
                c.Map(o => o.Code).Column("COD_CREDENCIADORA").Not.Nullable();
                c.Map(o => o.Description).Column("DSC_CREDENCIADORA").Not.Nullable();
            });

            Component(x => x.CheckingAccount, c =>
            {
                c.Map(o => o.Number).Column("NUM_CONTA").Not.Nullable();
                c.Map(o => o.Digit).Column("DIG_CONTA").Not.Nullable();
            });

            Map(x => x.BequestId, "IDT_LEGADO").Not.Nullable();
            Map(x => x.EntryDate, "DTA_ENTRADA").Not.Nullable();
            Map(x => x.MovementDate, "DTA_MOVIMENTO").Not.Nullable();
            Map(x => x.LiquidationDate, "DTA_LIQUIDACAO").Nullable();
            Map(x => x.Type, "TPO_MOVIMENTO").CustomType<int>();

            Component(x => x.Establishment, c =>
            {
                c.Map(o => o.Cnpj).Column("NUM_CNPJ_ESTABELECIMENTO").Not.Nullable();
                c.Map(o => o.Name).Column("NOM_ESTABELECIMENTO").Not.Nullable();
            });
            
            Map(x => x.SalePoint, "COD_PONTO_VENDA").Not.Nullable();
            Map(x => x.Amount, "VLR_MOVIMENTO").Not.Nullable();
        }
    }
}