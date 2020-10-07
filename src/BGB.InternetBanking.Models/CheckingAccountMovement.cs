using System;
using BGB.InternetBanking.Models.Enums;

namespace BGB.InternetBanking.Models
{
    public class CheckingAccountMovement
    {
        public virtual long Id { get; set; }
        public virtual DateTime MovementDate { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual int BequestId { get; set; }
        public virtual string Document { get; set; }
        public virtual DateTime? CompensationDate { get; set; }
        public virtual CheckingAccountHistory History { get; set; }
        public virtual PaymentTypeEnum PaymentType { get; set; }
        public virtual int? CategoryId { get; set; }
        public virtual decimal Amount { get; set; }
    }
}