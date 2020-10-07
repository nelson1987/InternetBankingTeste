using System;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class BusinessCheckDto
    {
        public decimal Limit { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}