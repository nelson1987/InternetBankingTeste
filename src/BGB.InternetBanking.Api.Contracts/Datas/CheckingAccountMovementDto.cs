using System;
using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class CheckingAccountMovementDto
    {
        public long Id { get; set; }
        public DateTime MovementDate { get; set; }
        public CheckingAccountDto CheckingAccount { get; set; }
        public int BequestId { get; set; }
        public string Document { get; set; }
        public DateTime? CompensationDate { get; set; }
        public CheckingAccountHistoryDto History { get; set; }
        public PaymentTypeEnumDto PaymentType { get; set; }
        public int? CategoryId { get; set; }
        public decimal Amount { get; set; }
    }
}