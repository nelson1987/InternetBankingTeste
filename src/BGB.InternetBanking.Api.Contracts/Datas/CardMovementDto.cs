using System;
using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CardMovementDto
    {
        public int Id { get; set; }
        public FlagDto Flag { get; set; }
        public AcquirerDto Acquirer { get; set; }
        public CheckingAccountDto CheckingAccount { get; set; }
        public int BequestId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime MovementDate { get; set; }
        public DateTime? LiquidationDate { get; set; }
        public CardMovementEnumDto Type { get; set; }
        public EstablishmentDto Establishment { get; set; }
        public string SalePoint { get; set; }
        public decimal Amount { get; set; }
    }
}