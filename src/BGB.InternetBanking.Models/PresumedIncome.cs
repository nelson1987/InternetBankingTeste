using System;

namespace BGB.InternetBanking.Models
{
    public class PresumedIncome
    {
        public DateTime ReferenceDate { get; set; }
        public decimal BalancePrevious { get; set; }
        public decimal Application { get; set; }
        public decimal Income {
            get
            {
                return ((BalanceCurrent - BalancePrevious) - Application) + Rescue;
            }
        }
        public decimal Rescue { get; set; }
        public decimal Ir { get; set; }
        public decimal Iof { get; set; }
        public decimal BalanceCurrent { get; set; }
    }
}