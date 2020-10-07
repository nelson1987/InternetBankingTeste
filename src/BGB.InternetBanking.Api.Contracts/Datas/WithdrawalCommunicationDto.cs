using System;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class WithdrawalCommunicationDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public StatusDto Status { get; set; }
        public string Protocol { get; set; }
        public string CoafProtocol { get; set; }
        public DateTime CommunicationDate { get; set; }
        public DateTime CommunicationDateValid { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string Finality { get; set; }
        public decimal Amount { get; set; }
        public PayeeDto Payee { get; set; }
    }
}