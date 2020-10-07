using System;

namespace BGB.InternetBanking.Models
{
    public class BusinessCheck
    {
        public virtual decimal Limit { get; set; }
        public virtual DateTime? Start { get; set; }
        public virtual DateTime? End { get; set; }
    }
}