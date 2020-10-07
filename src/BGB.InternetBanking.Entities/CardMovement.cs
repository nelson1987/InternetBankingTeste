using System;
using BGB.InternetBanking.Entities.Enums;

namespace BGB.InternetBanking.Entities
{
    public class CardMovement
    {
        public virtual int Id { get; set; }
        public virtual Flag Flag { get; set; }
        public virtual Acquirer Acquirer { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual int BequestId { get; set; }
        public virtual DateTime EntryDate { get; set; }
        public virtual DateTime MovementDate { get; set; }
        public virtual DateTime? LiquidationDate { get; set; }
        public virtual CardMovementEnum Type { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual string SalePoint { get; set; }
        public virtual decimal Amount { get; set; }
    }
}