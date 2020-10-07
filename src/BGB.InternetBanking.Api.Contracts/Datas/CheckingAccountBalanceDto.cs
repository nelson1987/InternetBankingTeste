using System;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CheckingAccountBalanceDto
    {
        public virtual int Id { get; set; }
        public virtual CheckingAccountDto CheckingAccount { get; set; }
        public virtual DateTime ReferenceDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Blocked { get; set; }
        public virtual BusinessCheckDto BusinessCheck { get; set; }
        public decimal Available { get; set; }
    }
}