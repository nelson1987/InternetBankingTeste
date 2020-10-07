using System;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class PresumedIncomeDto
    {
        public DateTime ReferenceDate { get; set; }
        public decimal BalancePrevious { get; set; }
        public decimal Application { get; set; }
        public decimal Income { get; set; }
        public decimal Rescue { get; set; }
        public decimal Ir { get; set; }
        public decimal Iof { get; set; }
        public decimal BalanceCurrent { get; set; }
    }
}