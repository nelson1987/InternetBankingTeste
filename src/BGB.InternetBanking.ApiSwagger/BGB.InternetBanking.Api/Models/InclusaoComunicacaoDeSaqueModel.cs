using System;

namespace BGB.InternetBanking.Api.Models
{
    public class InclusaoComunicacaoDeSaqueModel
    {
        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int StatusId { get; set; }
        public virtual string Protocol { get; set; }
        public virtual string CoafProtocol { get; set; }
        public virtual DateTime CommunicationDate { get; set; }
        public virtual DateTime CommunicationDateValid { get; set; }
        public virtual DateTime ExpectedDate { get; set; }
        public virtual DateTime? EffectiveDate { get; set; }
        public virtual string Finality { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual int PayeeId { get; set; }
        public virtual DateTime ExpectedDateValid { get; set; }
        public virtual decimal MinimumAmount { get; set; }
        public virtual int DaysInAdvance { get; set; }
    }
}
