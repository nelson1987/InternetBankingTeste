using System;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class IndexQuotationDto
    {
        public int Id { get; set; }
        public IndexDto Index { get; set; }
        public DateTime ReferenceDate { get; set; }
        public decimal Amount { get; set; }
    }
}