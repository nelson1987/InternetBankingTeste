using System;
using BGB.InternetBanking.Entities.Enums;

namespace BGB.InternetBanking.Entities
{
    public class InvestmentMovement
    {
        public virtual int Id { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual int BequestId { get; set; }
        public virtual DateTime MovementDate { get; set; }
        public virtual DateTime EmissionDate { get; set; }
        public virtual DateTime MaturityDate { get; set; }
        public virtual InvestmentMovementTypeEnum Type { get; set; }
        public virtual Paper Paper { get; set; }
        public virtual string Complement { get; set; }
        public virtual decimal Ir { get; set; }
        public virtual decimal Iof { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal LiquidAmount
        {
            get
            {
                return Amount - (Ir + Iof);
            }
        }
    }
}