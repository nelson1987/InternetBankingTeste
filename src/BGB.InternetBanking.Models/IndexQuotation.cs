using System;

namespace BGB.InternetBanking.Models
{
    public class IndexQuotation
    {
        public virtual int Id { get; set; }
        public virtual Index Index { get; set; }
        public virtual DateTime ReferenceDate { get; set; }
        public virtual decimal Amount { get; set; }
    }
}