using System;

namespace BGB.InternetBanking.Entities
{
    public class InvestmentBalance
    {
        public virtual int Id { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual DateTime ReferenceDate { get; set; }
        public virtual Paper Paper { get; set; }
        public virtual string Complement { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Ir { get; set; }
        public virtual decimal Iof { get; set; }
        public virtual decimal Applicated { get; set; }
        public virtual decimal LiquidAmount
        {
            get
            {
                return Amount - (Ir + Iof);
            }
        }
    }
}