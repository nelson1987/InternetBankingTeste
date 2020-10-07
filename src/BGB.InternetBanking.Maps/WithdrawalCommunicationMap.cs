using BGB.InternetBanking.Models;
using FluentNHibernate.Mapping;

namespace BGB.InternetBanking.Maps
{
    public class WithdrawalCommunicationMap : ClassMap<WithdrawalCommunication>
    {
        public WithdrawalCommunicationMap()
        {
            Table("DMI_COMUNICACAO_SAQUE");
            Id(x => x.Id, "IDT_COMUNICACAO_SAQUE").GeneratedBy.Native();
            References(x => x.Customer, "IDT_CLIENTE").Not.Nullable();
            References(x => x.Status, "IDT_STATUS").Not.Nullable();
            
            Map(x => x.Protocol, "TXT_PROTOCOLO").Length(30).Not.Nullable();
            Map(x => x.CoafProtocol, "TXT_PROTOCOLO_COAF").Length(30).Nullable();
            Map(x => x.CommunicationDate, "DTA_COMUNICACAO").Not.Nullable();
            Map(x => x.CommunicationDateValid, "DTA_COMUNICACAO_VALIDA").Not.Nullable();
            Map(x => x.ExpectedDate, "DTA_PREVISTA").Not.Nullable();
            Map(x => x.EffectiveDate, "DTA_EFETIVA").Nullable();
            Map(x => x.Amount, "VLR_SAQUE").Not.Nullable();
            Map(x => x.Finality, "TXT_FINALIDADE").Length(150).Not.Nullable();

            Component(x => x.Payee, c =>
            {
                c.Map(o => o.Name).Column("NOM_SACADOR").Length(100).Not.Nullable();

                c.Component(o => o.Cpf, p =>
                {
                    p.Map(o => o.Number).Column("NUM_CPF_SACADOR").Nullable();

                });

                c.Map(o => o.Passport).Column("TXT_PASSAPORTE").Length(30).Nullable();
                c.Map(o => o.EmitterCountry).Column("NOM_PAIS_EMISSOR").Length(40).Nullable();
                c.Map(o => o.Foreign).Column("FLG_SACADOR_ESTRANGEIRO").Not.Nullable();
            });
        }
    }
}