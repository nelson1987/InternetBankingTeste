using System.Collections.Generic;

namespace BGB.InternetBanking.Models
{
    public class InvestmentStatement
    {
        public IEnumerable<InvestmentMovement> Applications { get; set; }
        public IEnumerable<InvestmentMovement> Rescues { get; set; }
        public IEnumerable<IndexQuotation> Indexes { get; set; }
    }
}