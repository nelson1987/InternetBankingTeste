using System.Collections.Generic;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class InvestmentStatementDto
    {
        public IEnumerable<InvestmentMovementDto> Applications { get; set; }
        public IEnumerable<InvestmentMovementDto> Rescues { get; set; }
        public IEnumerable<IndexQuotationDto> Indexes { get; set; }
    }
}