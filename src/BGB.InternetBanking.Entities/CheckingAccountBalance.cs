using System;

namespace BGB.InternetBanking.Entities
{
    public class CheckingAccountBalance
    {
        public virtual int Id { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual DateTime ReferenceDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Blocked { get; set; }
        public virtual BusinessCheck BusinessCheck { get; set; }

        public virtual decimal Available
        {
            get
            {
                var balance = Amount - Blocked;

                balance += BusinessCheck.Limit;

                if (balance < 0)
                    balance = 0;

                return balance;
            }
        }
    }
}